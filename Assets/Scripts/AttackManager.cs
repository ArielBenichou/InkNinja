using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    private AudioManager audioManager;
    PlayerStats playerStats;
    PowerBar powerbar;
    bool canSlash = true;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerStats = gameObject.GetComponent<PlayerStats>();
        powerbar = playerStats.powerBar;
    }


    public void Onfire(InputAction.CallbackContext context)
    {
        //context.action.triggered;
        if (canSlash)
        {

            if (powerbar.UsePowerBar())
            {
                //distance to go: 7
                gameObject.GetComponent<PlayerMovement>().SlashForward(7);
                audioManager.Play("Run");
                //fire
            }
            else
            {
                Debug.Log("cannot fire not enough fill");
                audioManager.Play("SkillError");
            }
            canSlash = false;
            Invoke("resetSlash", 2.0f);
        }

    }
    private void resetSlash()
    {
        canSlash = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStats>()&& playerStats.slashing)
        {
            
            
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;


            audioManager.Stop("Run",0);
            audioManager.Play("Slash");
            //collision.gameObject.SetActive(false);
            //destroy(Player);
        }
    }
    public void ResetPlayer(Player player)
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Rigidbody2D>().simulated = true;
    }

}

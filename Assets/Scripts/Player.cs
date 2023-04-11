using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string pName="gray";
    public Color pColor=Color.gray;
    public float pSpeed=15f;
    public PowerBar powerBar;
    

    void Start()
    {
        PlayerManager.addPlayer(gameObject);
        powerBar  = GameObject.Find("Powerbar").GetComponent<PowerBar>();



    }

    // Update is called once per frame
    void Update()
    {

    }
}

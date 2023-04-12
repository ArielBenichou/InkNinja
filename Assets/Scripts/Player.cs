using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(TilePainter))]
public class Player : MonoBehaviour
{
    public string pName="gray";
    public Color pColor=Color.gray;
    [Range(1, 40)]
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

using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public static List<GameObject> playerList;

    private static List<Color> playerColors;
    void Start()
    {
        if (playerColors == null)
        {
            playerColors = new List<Color>();
            playerColors.Add(Color.magenta);
            playerColors.Add(Color.red);
            playerColors.Add(Color.cyan);
            playerColors.Add(Color.green);
        }
        if (playerList == null)
        {
            playerList = new List<GameObject>();
        }


    }

    public static void addPlayer(GameObject playerGameObject)
    {
        playerList.Add(playerGameObject);
        playerGameObject.name = "Player" + playerList.Count;

        PlayerStats PlayerStats = playerGameObject.GetComponent<PlayerStats>();
        PlayerStats.pColor = playerColors[playerList.Count-1];
        //PlayerScript.powerBar = PowerBar.createPowerBar(PlayerScript.pColor);

        string ClipName = "P" + (playerList.Count) + "Join";
        FindObjectOfType<AudioManager>().Play(ClipName); ;

        
    }


}

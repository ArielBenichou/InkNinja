using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static List<GameObject> playerList;

    private static List<string> playerNames;

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
            playerColors.Add(Color.gray);


            playerNames = new List<string>();
            playerNames.Add("magenta");
            playerNames.Add("cyan");
            playerNames.Add("green");
            playerNames.Add("red");
            playerNames.Add("gray-Error");

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

        Player player = playerGameObject.GetComponent<Player>();
        player.pColor = playerColors[playerList.Count - 1];
        player.pName = playerNames[playerList.Count - 1];

        player.powerBar = PlayerManager.spawnPowerBar(playerList.Count - 1, player.pColor).GetComponent<PowerBar>();

        string ClipName = "P" + (playerList.Count) + "Join";
        FindObjectOfType<AudioManager>().Play(ClipName); ;


    }

    public static void addPlayer1(GameObject playerGameObject)
    {
        playerList.Add(playerGameObject);
        playerGameObject.name = "Player" + playerList.Count;

        PlayerStats PlayerStats = playerGameObject.GetComponent<PlayerStats>();
        PlayerStats.pColor = playerColors[playerList.Count - 1];
        PlayerStats.pName = playerNames[playerList.Count - 1];

        PlayerStats.powerBar = PlayerManager.spawnPowerBar(playerList.Count-1, PlayerStats.pColor).GetComponent<PowerBar>();

        string ClipName = "P" + (playerList.Count) + "Join";
        FindObjectOfType<AudioManager>().Play(ClipName); ;


    }

    public static GameObject spawnPowerBar(int player, Color color)
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject PowerBar = Resources.Load<GameObject>("UI/Powerbar");

        GameObject bar = Instantiate(PowerBar, new Vector3(
              canvas.GetComponent<RectTransform>().rect.width * (player + 1) / 5 // set position relative to the left
            , canvas.GetComponent<RectTransform>().rect.height * 15 / 16, 0)       //  set position relative to the bottom
            , Quaternion.identity, canvas.transform);                            // rotate 0 and set canvas as parent
        bar.GetComponent<PowerBar>().SetColor(color);
        return bar;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SpawnPowerBar : MonoBehaviour
{


    public static GameObject spawnPowerBar(int player,Color color)
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject PowerBar = Resources.Load<GameObject>("UI/Powerbar");

        Debug.Log(PowerBar);
        GameObject bar = Instantiate(PowerBar, new Vector3(
              canvas.GetComponent<RectTransform>().rect.width * (player + 1) / 5 // set position relative to the left
            , canvas.GetComponent<RectTransform>().rect.height * 7 / 8, 0)       //  set position relative to the bottom
            , Quaternion.identity, canvas.transform);                            // rotate 0 and set canvas as parent
        bar.GetComponent<PowerBar>().SetColor(color);
        return bar;
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerBar : MonoBehaviour
{
    public GameObject PowerBar;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {

        //Instantiate(PowerBar, new Vector3(100, 100, 100), Quaternion.identity);
        //PowerBar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        //GameObject PowerBar = PowerBar.
        float canvas_height = canvas.GetComponent<RectTransform>().rect.height;
        float canvas_width = canvas.GetComponent<RectTransform>().rect.width;
        Instantiate(PowerBar, new Vector3(canvas_width* 1/5, canvas_height * 3 / 4, 0), Quaternion.identity, canvas.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

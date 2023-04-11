using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
    public string playerColor;
    public Tilemap floorTilemap;
    public Color colorToPaint = Color.black;
    public PowerBar powerBar;

    private static Dictionary<Vector2, string> tileTracker;

    void Start()
    {
        tileTracker = new() { }; 
        if (floorTilemap == null)
        {
        }
        floorTilemap = GameObject.Find("Floor Tilemap").GetComponent<Tilemap>();
        powerBar = gameObject.GetComponent<Player>().powerBar;
        colorToPaint = gameObject.GetComponent<Player>().pColor;


    }

    void FixedUpdate()
    {
        Vector2 myPos = transform.position;
        myPos.y = Mathf.Floor(myPos.y);
        myPos.x = Mathf.Floor(myPos.x);
        this.ChangeTileColor(Vector2Int.RoundToInt(myPos), colorToPaint);

        if (!IsPlayerAlreadyPaintedTile(myPos))
        {
            powerBar.FillPowerBar(1);
        }
        tileTracker[myPos] = playerColor;
    }

    private void ChangeTileColor(Vector2Int tilePos, Color color)
    {
        Vector3Int myPos = (Vector3Int)tilePos;
        floorTilemap.SetTileFlags(myPos, TileFlags.None);
        floorTilemap.SetColor(myPos, color);
    }

    private bool IsPlayerAlreadyPaintedTile(Vector2 pos)
    {
        if (tileTracker.ContainsKey(pos))
        {
            return tileTracker[pos] == playerColor;
        }

        return false;
    }
}

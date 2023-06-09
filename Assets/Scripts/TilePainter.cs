using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
    public Tilemap floorTilemap;
    Player player;
    private static Dictionary<Vector2, string> tileTracker;

    void Start()
    {
        if (tileTracker == null)
        {
            tileTracker = new() { }; 
        }
        floorTilemap = GameObject.Find("Floor Tilemap").GetComponent<Tilemap>();
        player = gameObject.GetComponent<Player>();


    }

    void FixedUpdate()
    {
        Vector2 myPos = transform.position;
        myPos.y = Mathf.Floor(myPos.y);
        myPos.x = Mathf.Floor(myPos.x);
        this.ChangeTileColor(Vector2Int.RoundToInt(myPos), player.pColor);

        if (!IsPlayerAlreadyPaintedTile(myPos))
        {
            player.powerBar.FillPowerBar(1);
            
        }
        tileTracker[myPos] = player.pName;
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
            return tileTracker[pos] == player.pName;
        }

        return false;
    }
}

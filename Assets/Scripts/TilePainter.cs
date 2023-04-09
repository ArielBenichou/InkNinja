using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
    public Tilemap floorTilemap;
    public Color colorToPaint = Color.magenta;

    void FixedUpdate()
    {
        Vector2 myPos = transform.position;
        myPos.y = Mathf.Floor(myPos.y);
        myPos.x = Mathf.Floor(myPos.x);
        this.ChangeTileColor(Vector2Int.RoundToInt(myPos), colorToPaint);
    }

    void ChangeTileColor(Vector2Int tilePos, Color color)
    {
        Vector3Int myPos = (Vector3Int)tilePos;
        floorTilemap.SetTileFlags(myPos, TileFlags.None);
        floorTilemap.SetColor(myPos, color);
    }
}

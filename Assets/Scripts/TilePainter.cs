using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
    public Tilemap floorTilemap;
    // Start is called before the first frame update
    void Start()
    {
        this.ChangeTileColor(new Vector2(-2,0), Color.magenta);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ChangeTileColor(Vector2 tilePos, Color color)
    {
        Vector3Int myPos = Vector3Int.RoundToInt((Vector3)tilePos);
        floorTilemap.SetTileFlags(myPos, TileFlags.None);
        floorTilemap.SetColor(myPos, color);
    }
}

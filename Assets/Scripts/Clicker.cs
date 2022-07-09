using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    int x;
    int z;
    TileInfo tile;
    MapGenerator mg;
    public GameObject tg;
    void Start()
    {
        tg = GameObject.Find("TileGenerator");
        mg = tg.GetComponent<MapGenerator>();
        tile = GetComponent<TileInfo>();
        x = tile.x;
        z = tile.z;    
    }
    void OnMouseDown()
    {
        if(tile.wall==false)
        {
            mg.map[x,z] = false;
            tile.wall = true;
            mg.CreateWall(x,z);
        }
    }

    
}

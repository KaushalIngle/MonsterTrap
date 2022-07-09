using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public GameObject Monster;
    public RuntimeAnimatorController AnimatorController;
    public GameObject FloorTile;
    public GameObject Wall;
    [SerializeField] int mapWidth = 4;

    public float tileXOffset = 0.5F;
    public float tileZOffset = 0.866F;


    public bool[,] map;
    public GameObject[,] tiles;
    public GameObject s;
    public GameObject monster;
    public int monsterX, monsterY;

    void Start()
    {
        InstantiatePlatform();
    }
    void InstantiatePlatform()
    {
        tiles = new GameObject[mapWidth,mapWidth];
        map = new bool[mapWidth,mapWidth];
        monster = GameObject.Instantiate(Monster);
        Animator animator = monster.GetComponent<Animator>(); 
        animator.runtimeAnimatorController = AnimatorController;
        monsterX = 0;
        monsterY = 0;
        for(int x=0;x<mapWidth;x++){
            for(int z=0;z<mapWidth;z++){

                map[x,z] = true;
                tiles[x,z]= Instantiate(FloorTile);
                tiles[x,z].transform.position = xCube(x,z);
                tiles[x,z].transform.localScale = new Vector3(0.95f,0.95f,0.95f);
                tiles[x,z].name = ("Tile "+x+" "+z);
                tiles[x,z].AddComponent<BoxCollider>();
                TileInfo tile = tiles[x,z].AddComponent<TileInfo>();
                tile.x = x;
                tile.z = z;
                tile.wall = false;
                Clicker cl = tiles[x,z].AddComponent<Clicker>();
                
            }
        }
        
    }

    public void CreateWall(int x, int z){
        GameObject newWall = GameObject.Instantiate(Wall);
        newWall.transform.position = xCube(x,z);
        newWall.transform.localScale = new Vector3(0.65f,3,0.65f);
    }

    public void PlayMonster(){

    }

    public void CalcDistance(){
        while(true){

        }
    }
    public void MoveScores(){

    }
    
    Vector3 xCube(int x, int z){
        var row = z;
        var col = x;

        if((Mathf.Abs(row))%2==0){
            return new Vector3(col,0,row*tileZOffset);
        }
        else{
            return new Vector3(col-tileXOffset,0,row*tileZOffset);
        }

    }

}

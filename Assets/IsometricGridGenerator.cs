using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class IsometricGridGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] tile;
    [SerializeField] private GridDataLoader _gridDataLoader;
    [SerializeField] private int gridheight = 10;
    [SerializeField] private int gridwidth = 10;
    [SerializeField] private float tilesize = 1f;
    
    void Start()
    {
      //  GenerateGrid();
    }

    // Update is called once per frame

  
    [Button]
    void GenerateGrid()
    {
        Terrain grid = _gridDataLoader.LoadTerrainJSON();
        for (int i = 0; i < grid.TerrainGrid.Count ; i++)
        {
            for (int j = 0; j < grid.TerrainGrid[i].Count; j++)
            {
                GameObject newtile = Instantiate(tile[grid.TerrainGrid[i][j].TileType], transform);
                float posX = (i * tilesize + j * tilesize) / 2f;
                float posY = (i * tilesize - j * tilesize) / 2f;

                newtile.transform.position = new Vector2(posX, posY);
                newtile.name = i + "," + j;
            }
        }
    }
}

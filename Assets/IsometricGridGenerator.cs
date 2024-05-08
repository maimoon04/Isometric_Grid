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
    [SerializeField] private List<TileCells> TilesInGrid;
    
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
              

                newtile.transform.position = new Vector2(i,j);
                newtile.name = i + "," + j;
                TilesInGrid.Add(newtile.GetComponent<TileCells>());
            }
        }
    }
   
    [Button]
    void FindNeighborsTiles()
    {
        for (int i = 0; i < TilesInGrid.Count;i++)
        {
            TilesInGrid[i].AddNeighbor(TilesInGrid);
        }
    }
}

    


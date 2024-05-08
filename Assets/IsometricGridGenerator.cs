using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricGridGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject tile;
    [SerializeField] private int gridheight = 10;
    [SerializeField] private int gridwidth = 10;
    [SerializeField] private float tilesize = 1f;
    
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame

    void GenerateGrid()
    {
        for (int i = 0; i < gridwidth; i++)
        {
            for (int j = 0; j < gridheight; j++)
            {
                GameObject newtile = Instantiate(tile, transform);
                float posX = (i * tilesize + j * tilesize) / 2f;
                float posY = (i * tilesize - j * tilesize) / 2f;

                newtile.transform.position = new Vector2(posX, posY);
                newtile.name = i + "," + j;
            }
        }
    }
}

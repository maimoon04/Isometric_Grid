using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{

    public GameObject Table;
    public TableData tableData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //To Detect the mouse Click
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity);
            if (hit.collider != null)
            {
                // Object with "Table" layer was hit
                Debug.Log("Object selected: " + hit.collider.gameObject.name);
                TileCells tile = hit.collider.GetComponent<TileCells>();
                if(tile.Is_Placeable && tile.CanBePlaced())
                {
                    tile.Is_Placeable = false;
                  

                    if (tile.IsHorizontalNeighbor(tile.AdjacentTile()))
                    {
                        tile.neededneighbors.Is_Placeable = false;
                        tableData = PlaceTable(tile.transform);
                        tableData.IsHorizantalDirection = true;
                        tableData.SetTableRotation();
                    }
                    else
                    {
                        tableData = PlaceTable(tile.transform);
                        tableData.IsHorizantalDirection = false;
                        tableData.SetTableRotation();
                    }
                }
                else
                {
                    Debug.LogError("Cant be placed");
                }
                
              
            }


        }
      
     
    }

    TableData PlaceTable(Transform obj)
    {
        GameObject table = Instantiate(Table, transform);
        table.transform.position = new Vector2(obj.position.x, obj.position.y);

        return table.GetComponent<TableData>();
    }
}

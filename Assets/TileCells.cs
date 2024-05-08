using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCells : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<TileCells> neighbors;
    [SerializeField] private string tag;
    [SerializeField] private bool IsPlaceable = true;
    void Start()
    {
        tag = gameObject.tag;
    }

    // Update is called once per frame
    public void AddNeighbor(List<TileCells> tiles)
    {
        foreach (var tile in tiles)
        {
            var t = tile;
            if (IsAdjacent(t))
            {
                neighbors.Add(t);
            }
        }
        // Check if the neighbor is not already in the list
        //if (!neighbors.Contains(neighbor))
        //{
        //    // Add the neighbor to the list
        //    neighbors.Add(neighbor);
        //}
    }

    bool IsAdjacent(TileCells tile)
    {
        // Get the positions of the current tile and the tile to check adjacency with
        Vector3 currentPosition = transform.position;
        Vector3 neighborPosition = tile.transform.position;

        // Calculate the absolute difference in x and y coordinates
        float deltaX = Mathf.Abs(currentPosition.x - neighborPosition.x);
        float deltaY = Mathf.Abs(currentPosition.y - neighborPosition.y);

        // Tiles are adjacent if the absolute difference in both x and y coordinates is 1,
        // and they are not the same tile (deltaX > 0 || deltaY > 0 ensures they are not the same tile)
        if ((deltaX == 1 && deltaY == 0) || (deltaX == 0 && deltaY == 1) && (deltaX > 0 || deltaY > 0))
        {
            return true;
        }

        return false;
    }

    // Method to clear the list of neighbors
    public void ClearNeighbors()
    {
        // Clear the list of neighbors
        neighbors.Clear();
    }

   
}

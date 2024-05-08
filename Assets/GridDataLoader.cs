using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class GridDataLoader : MonoBehaviour
{
   
    public string jsonFilePath;
    [SerializeField] private Terrain _terrain;
    void Start()
    {
       // LoadJSON();
    }

    public Terrain LoadTerrainJSON()
    {
        // Load the JSON file as a TextAsset
        TextAsset jsonTextAsset = Resources.Load<TextAsset>(jsonFilePath);
        if (jsonTextAsset == null)
        {
            Debug.LogError("Failed to load JSON file at path: " + jsonFilePath);
            return null;
        }

        // Deserialize JSON content
        string jsonContent = jsonTextAsset.text;
        if (string.IsNullOrEmpty(jsonContent))
        {
            Debug.LogError("JSON file is empty or malformed");
            return null;
        }

        // Deserialize JSON into your custom data structure
        _terrain = JsonConvert.DeserializeObject<Terrain>(jsonContent);

        // Now you can use 'data' as your loaded JSON object
        Debug.Log("Loaded JSON: " + _terrain);

        return _terrain;
    }
}

[System.Serializable]
public class Terrain
{
    public List<List<Tile>> TerrainGrid;
}

[System.Serializable]
public class Tile
{
    public int TileType;
}

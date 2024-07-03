using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    System.Random random = new System.Random();

    [SerializeField] GameObject[] StartingTiles;
    [SerializeField] GameObject[] Tiles;

    [SerializeField] int totalTiles = 10;

    int spawnCount = 0;
    float TotalLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(Tiles.Length != 0, "MapGenerator Prefabs are not set");

        foreach (GameObject tile in StartingTiles)
        {
            spawnTile(tile, false);
        }

        while (spawnCount < totalTiles)
        {
            spawnTile(Tiles[random.Next(Tiles.Length)], true);
        }
    }

    void spawnTile(GameObject Tile, bool addToSpawnCount)
    {
        GameObject TileInstance = Instantiate(Tile);
        TileInstance.transform.SetLocalPositionAndRotation(transform.position + new Vector3(0, 0, TotalLength), transform.rotation);
        TotalLength += TileInstance.transform.Find("Floor").localScale.z;
        if (addToSpawnCount)
            spawnCount++;
    }
}

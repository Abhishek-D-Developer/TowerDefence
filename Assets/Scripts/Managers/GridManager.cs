using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public int gridWidth = 16;
    public int gridHeight = 8;

    public GameObject pathTile;

    [SerializeField] PathGenerator pathGenerator;

    // Start is called before the first frame update
    void Start()
    {
        pathGenerator = new PathGenerator(gridWidth, gridHeight);
        List<Vector2Int> pathCells = pathGenerator.GeneratePath();

        StartCoroutine(LayPathCells(pathCells));
    }

    IEnumerator LayPathCells(List<Vector2Int> pathCells)
    {
        foreach (Vector2Int pathcells in pathCells)
        {
            Instantiate(pathTile, new Vector3(pathcells.x, 0f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

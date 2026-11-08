using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public int treeCount = 100;
    public Vector2 minBounds = new Vector2(-150f, -150f);
    public Vector2 maxBounds = new Vector2(150f, 200f);
    public LayerMask terrainLayer;
    public float treeClearanceRadius = 6f;

    void Start()
    {
        List<Vector3> placed = new List<Vector3>();
        int attempts = 0;
        
        //Tree count * 1000 to acoount for whole range where land is not
        while (placed.Count < treeCount && attempts < treeCount * 1000)
        {
            attempts++;

            Vector3 origin = new Vector3(Random.Range(minBounds.x, maxBounds.x), 150f, Random.Range(minBounds.y, maxBounds.y));

            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, 300f, terrainLayer))
            {
                bool tooClose = false;
                foreach (Vector3 existingPos in placed)
                {
                    if (Vector3.Distance(existingPos, hit.point) < treeClearanceRadius)
                    {
                        tooClose = true;
                        Debug.Log("Tree to0 close" + existingPos);
                        break;
                    }
                }

                if (!tooClose)
                {
                    Instantiate(treePrefab, hit.point, Quaternion.identity);
                    placed.Add(hit.point);
                }
            }
        }
    }
}
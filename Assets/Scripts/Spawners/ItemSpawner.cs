using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] itemLocations;
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private int spawnAmount;

    void Start()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject location = itemLocations[Random.Range(0, itemLocations.Length)];
            GameObject item = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
            Instantiate(item, location.transform.position, location.transform.rotation);
        }
    }
}

using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;

    private void OnEnable()
    {
        Pickup.OnPickupCollected += SpawnPickup;
    }

    private void OnDisable()
    {
        Pickup.OnPickupCollected -= SpawnPickup;
    }

    private void Start()
    {
        SpawnPickup();
    }

    private void SpawnPickup()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
    }
}

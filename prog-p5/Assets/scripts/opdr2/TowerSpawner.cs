using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerPrefab;
    public Camera mainCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnTower();
        }
    }

    void SpawnTower()
    {
     
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

     
        if (Physics.Raycast(ray, out hit))
        {
         
            Vector3 spawnPosition = hit.point;
            Instantiate(towerPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float distance = 5.0f;
    public float height = 2.0f;
    public float cameraSpeed = 2.0f;

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position - player.forward * distance + Vector3.up * height;
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
            transform.LookAt(player.position + Vector3.up * height / 2);
        }
    }
}

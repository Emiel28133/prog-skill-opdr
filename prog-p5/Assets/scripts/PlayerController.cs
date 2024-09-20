using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 100f;

    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float turnHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = transform.forward * moveVertical * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        float turn = turnHorizontal * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);
    }
}

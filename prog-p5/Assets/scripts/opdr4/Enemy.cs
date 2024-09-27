using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f; // Snelheid

    private void Update()
    {
        // Verplaats de vijand
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

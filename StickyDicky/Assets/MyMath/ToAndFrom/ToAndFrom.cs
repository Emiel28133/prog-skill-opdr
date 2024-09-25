using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAndFrom : MonoBehaviour
{

    [SerializeField] GameObject Base;
    [SerializeField] GameObject Target;
    [SerializeField] Arrow arrow;


    Vector3 velocity = new Vector3(0, -2, 0);
    void Start()
    {
        arrow.transform.position = Base.transform.position;
        velocity = Target.transform.position - Base.transform.position;


        velocity = velocity.normalized;
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Target.transform.position - arrow.transform.position;
        arrow.myVector = velocity;
        arrow.transform.position += velocity * Time.deltaTime;
    }
}

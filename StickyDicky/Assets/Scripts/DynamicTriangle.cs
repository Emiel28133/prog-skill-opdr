using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTriangle : MonoBehaviour
{
    [SerializeField] Transform A;
    [SerializeField] Transform B;
    [SerializeField] Transform C;

    [SerializeField] LineRenderer AB;
    [SerializeField] LineRenderer BC;
    [SerializeField] LineRenderer AC;
    void Start()
    {

    }


    void Update()
    {
        AB.SetPosition(0, A.position);
        AB.SetPosition(1, B.position);
        BC.SetPosition(0, B.position);
        BC.SetPosition(1, C.position);
        AC.SetPosition(0, A.position);
        AC.SetPosition(1, C.position);
    }
}
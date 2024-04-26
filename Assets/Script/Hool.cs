using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Hool : MonoBehaviour
{
    public float speed;
    
 
    void Update()
    {
        transform.Rotate(Vector3.forward, speed, Space.Self);

    }
}

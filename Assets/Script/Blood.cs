using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{


    [Header("Particle")]
    public ParticleSystem blood;
    // public Transform Tblood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gasi")
        {
            Debug.Log("Ãæµ¹");
            blood.transform.position = GetComponent<Collider2D>().bounds.center;
            blood.Play();
        }
    }


    




}

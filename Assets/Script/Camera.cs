using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform player;//플레이어 위치

    public float speed;//속도

    public Vector3 offest;//위치 조정


    private void Update()
    {
        //플레이어 위치 + offest  = 새로운 위치 
        Vector3 newpos = player.position + offest;

        //현재 개체의 위치
        transform.position = Vector3.Lerp(transform.position, newpos, speed);

    }



}

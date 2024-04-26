using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform player;//�÷��̾� ��ġ

    public float speed;//�ӵ�

    public Vector3 offest;//��ġ ����


    private void Update()
    {
        //�÷��̾� ��ġ + offest  = ���ο� ��ġ 
        Vector3 newpos = player.position + offest;

        //���� ��ü�� ��ġ
        transform.position = Vector3.Lerp(transform.position, newpos, speed);

    }



}

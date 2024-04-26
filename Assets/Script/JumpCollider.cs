using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour
{
    [Header("Jump power")]
    public float jumpPower = 1.2f;//�����Ŀ�

    [Header("particle")]
    private Rigidbody2D rb;
    public  ParticleSystem Jumpparticle;
    public ParticleSystem Groundpaticle;
    public Transform JumpT;

    public AudioClip jumpGround;

    private bool isGround = false;
    
    private void Awake()
    {
       
        rb = GetComponent<Rigidbody2D>();
       
    }

    // ���� ����� �� ȣ��Ǵ� �̺�Ʈ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = true; // ���� ��������� ����
        }
    }

    // ������ ����� �� ȣ��Ǵ� �̺�Ʈ
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = false; // ������ ����� ����
        }
    }


    private void Update()
    {
        if (isGround && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
            Audio.instance.PlayerJumpGround("JumpG", jumpGround);
            Jumpparticle.Play();
            Groundpaticle.Play();
        }
    }
    
    private void Jump()
    {
         rb.velocity = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z) * Vector2.up * jumpPower;
    }

  
}

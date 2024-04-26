using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour
{
    [Header("Jump power")]
    public float jumpPower = 1.2f;//점프파워

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

    // 땅에 닿았을 때 호출되는 이벤트
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = true; // 땅에 닿아있음을 설정
        }
    }

    // 땅에서 벗어났을 때 호출되는 이벤트
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = false; // 땅에서 벗어남을 설정
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

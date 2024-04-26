
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    [Header("Speed")]
    public  float speed = 0.5f;
    public float Hoolspeed = 1000;
    private float hinputspeede;

    [Header("springjump")]
    public float springjump = 1.2f;

    [Header("GameManager")]
    public GameManager gamemanager;


    [Header("GameObject")]
    public GameObject BaObject;//바 오브젝트

    [Header("slowMotion")]
    public float slowMotionSpeed = 0.7f;

    [Header("Audioclip")]
    public AudioClip jumpClip;
    public AudioClip jumpClip1;
    public AudioClip deadClip;
    public AudioClip groundClip;
    public AudioClip gasiClip;
    public AudioClip gasiClip1;
    public AudioClip springClip;


    private bool isDead = false;
    private bool isHool = false;
    private bool isGround = false;

    private Rigidbody2D rb;
    private Animator ani;
    private Animator springani;

   
    private void Awake()
    {
       
        //초기화 
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        springani = GameObject.Find("spring").GetComponent<Animator>();
       
        
    }

    //땅일때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Audio.instance.Ground("ground" , groundClip);
            isGround = true;
            hinputspeede = 1.5f;//회전시 앞으로 이동속도
        }
    }
    //땅에서 벗어났을때
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = false;
            hinputspeede = 0.2f;//회전시 앞으로 이동속도
        }
    }

    private void Update()
    {
        //죽음
        if (isDead)
        {
            return;
        }

        //포탈
        if (isHool)
        {
            transform.Rotate(Vector3.forward, Hoolspeed, Space.Self);
            return;
        }


        // 회전
        float hinput = Input.GetAxis("Horizontal");
    
        transform.Rotate(Vector3.forward * -hinput * speed * Time.deltaTime);

        rb.AddForce(new Vector2(hinputspeede, 0) * hinput);


        
        //점프 애니메이션
        if (Input.GetKeyDown(KeyCode.W))
        {
            int ranjump =  Random.Range(0, 2);
            Debug.Log(ranjump);
            if (ranjump == 0)
            {
                Audio.instance.PlayerJump("jump", jumpClip);
            }
            else if (ranjump == 1)
            {
                Audio.instance.PlayerJump2("jump1", jumpClip1);
            }

            ani.SetFloat("Jump", 1);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            ani.SetFloat("Jump", 0);
        }


    }

    //죽음
    public void Die()
    {
       
        ani.SetTrigger("Die");
        rb.velocity = Vector3.zero;
        isDead = true;

        //슬로우모션!!!!!dndhkd
        Time.timeScale = slowMotionSpeed;
        
        Invoke("restart", 1);
       
    }


    public void restart()
    {
        SceneManager.LoadScene("map1");
        Time.timeScale = 1f;
    }

    public void Hool()
    {
       ani.SetTrigger("Hool");
       rb.velocity = Vector3.zero;
       isHool = true;
       BaObject.gameObject.SetActive(true);//바 활성화 

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //충돌한 오브젝트의 태그가 Dead일 경우 && 죽지 않았을때
        if (other.tag == "Dead" && !isDead)
        {
            Audio.instance.PlayerDead("dead", deadClip);
            Die();
        }
        if (other.tag == "Gasi" && !isDead)
        {
           int randgasi = Random.Range(0, 2);

            if (randgasi == 0)
            {
                Audio.instance.Gasi("gasi", gasiClip);
            }
            else if (randgasi == 1)
            {
                Audio.instance.Gasi1("gasi1", gasiClip1);
            }
            Die();
        }

        //충돌한 오브젝트의 캐그가 Hool일 겨우 && 실행이 안되어 있을 걍우
        if (other.tag == "Hool" && !isHool)
        {
            gamemanager.Timestop();
            Hool();
        }
       
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        //스프링에 닿았을때 
        if (collision.collider.CompareTag("Spring"))
        {
            Audio.instance.Spring("spring", springClip);
            rb.velocity = Quaternion.Euler(0, 0, 3) * Vector2.up * springjump * 10f;
            springani.SetTrigger("new Spring");
        }

       

    }
 

  


}
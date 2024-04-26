
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
    public GameObject BaObject;//�� ������Ʈ

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
       
        //�ʱ�ȭ 
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        springani = GameObject.Find("spring").GetComponent<Animator>();
       
        
    }

    //���϶�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Audio.instance.Ground("ground" , groundClip);
            isGround = true;
            hinputspeede = 1.5f;//ȸ���� ������ �̵��ӵ�
        }
    }
    //������ �������
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = false;
            hinputspeede = 0.2f;//ȸ���� ������ �̵��ӵ�
        }
    }

    private void Update()
    {
        //����
        if (isDead)
        {
            return;
        }

        //��Ż
        if (isHool)
        {
            transform.Rotate(Vector3.forward, Hoolspeed, Space.Self);
            return;
        }


        // ȸ��
        float hinput = Input.GetAxis("Horizontal");
    
        transform.Rotate(Vector3.forward * -hinput * speed * Time.deltaTime);

        rb.AddForce(new Vector2(hinputspeede, 0) * hinput);


        
        //���� �ִϸ��̼�
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

    //����
    public void Die()
    {
       
        ani.SetTrigger("Die");
        rb.velocity = Vector3.zero;
        isDead = true;

        //���ο���!!!!!dndhkd
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
       BaObject.gameObject.SetActive(true);//�� Ȱ��ȭ 

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //�浹�� ������Ʈ�� �±װ� Dead�� ��� && ���� �ʾ�����
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

        //�浹�� ������Ʈ�� ĳ�װ� Hool�� �ܿ� && ������ �ȵǾ� ���� ����
        if (other.tag == "Hool" && !isHool)
        {
            gamemanager.Timestop();
            Hool();
        }
       
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        //�������� ������� 
        if (collision.collider.CompareTag("Spring"))
        {
            Audio.instance.Spring("spring", springClip);
            rb.velocity = Quaternion.Euler(0, 0, 3) * Vector2.up * springjump * 10f;
            springani.SetTrigger("new Spring");
        }

       

    }
 

  


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [Header("GameObject")]
    public GameObject Player;//�÷��̾�
    public GameObject Hool;//Ȧ
   
    [Header("TMP_Text")]
    public TMP_Text text;//UI �ؽ�Ʈ(TextMeshPro)�� ����
    public TMP_Text swdowtext;

    //���� �ִϸ��̼�
    [Header("Coin anime")]
    public GameObject TimeCoinObject;
    public GameObject baObject;
    public GameObject TimeCoinObject2;


    private float time; //���� �ð��� ��Ÿ���� ���� 
    private int Hour;//�� ����
    private int minute;//�� ����
    private int second;//�� ����
    private bool isTime = false;

    int coinTime = 0;
    int coinTime1 = 0;

    private void Awake()
    {
        time = 3600f;
        isTime = true;//����
        coinTime = PlayerPrefs.GetInt("CoinTime", 0);

        coinTime1 = PlayerPrefs.GetInt("CoinTime1", 0);


        StartCoroutine(UpdateTimer());//Ÿ�̸� ������Ʈ �ڷ�ƾ

    }

    private void Update()
    {
        //ESC�ʱ�ȭ
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("ESC");
            PlayerPrefs.DeleteAll();
            
        }

        //10�� ���ϸ� && �� Ȱ��ȭ
        if (time <= 30 && baObject.activeSelf)
        {
            TimeCoinObject.gameObject.SetActive(true);
            PlayerPrefs.SetInt("CoinTime", 1);
            PlayerPrefs.SetInt("CoinTime1", 1);
        }

      
        if (coinTime == 1 && baObject.activeSelf)
        {
            TimeCoinObject.SetActive(true);

        }

        if (coinTime1 == 1 && baObject.activeSelf)
        {
            TimeCoinObject2.SetActive(true);         

        }

    }

    public void Timestop()
    {
        isTime = false;
    }

    //�ð� �� 
    IEnumerator UpdateTimer()
    {
        while (isTime) 
        {
            time += Time.deltaTime;//��� �ð� ����

            //���� �ð� ��, ��, �ʷ� ��ȯ�Ͽ� UIǥ��
            Hour = (int)(time / 3600);
            minute = (int)(time % 3600 / 60);
            second = (int)(time % 60);
            text.text = Hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
            swdowtext.text = Hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");

            
            yield return null;
            
        }

    }

}

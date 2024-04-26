using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [Header("GameObject")]
    public GameObject Player;//플레이어
    public GameObject Hool;//홀
   
    [Header("TMP_Text")]
    public TMP_Text text;//UI 텍스트(TextMeshPro)에 접근
    public TMP_Text swdowtext;

    //코인 애니메이션
    [Header("Coin anime")]
    public GameObject TimeCoinObject;
    public GameObject baObject;
    public GameObject TimeCoinObject2;


    private float time; //현재 시간을 나타내는 변수 
    private int Hour;//시 저장
    private int minute;//분 저장
    private int second;//초 저장
    private bool isTime = false;

    int coinTime = 0;
    int coinTime1 = 0;

    private void Awake()
    {
        time = 3600f;
        isTime = true;//시작
        coinTime = PlayerPrefs.GetInt("CoinTime", 0);

        coinTime1 = PlayerPrefs.GetInt("CoinTime1", 0);


        StartCoroutine(UpdateTimer());//타이머 업데이트 코루틴

    }

    private void Update()
    {
        //ESC초기화
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("ESC");
            PlayerPrefs.DeleteAll();
            
        }

        //10초 이하면 && 바 활성화
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

    //시간 초 
    IEnumerator UpdateTimer()
    {
        while (isTime) 
        {
            time += Time.deltaTime;//경과 시간 누적

            //걍과 시간 시, 분, 초로 변환하여 UI표시
            Hour = (int)(time / 3600);
            minute = (int)(time % 3600 / 60);
            second = (int)(time % 60);
            text.text = Hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
            swdowtext.text = Hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");

            
            yield return null;
            
        }

    }

}

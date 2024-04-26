using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin1 : MonoBehaviour
{
    //당근 오브젝트
    [Header("Coin")]
    public GameObject HoolCoinObjct1;
    public GameObject CarrotCoinObjrct1;


    [Header("GameObject")]
    public GameObject CarrotObject1;
    public GameObject BaObject1;


    int carrotCoin1 = 0;
    int hoolCoin1 = 0;
   

    private void Start()
    {
        //0으로 초기화 
        carrotCoin1 = PlayerPrefs.GetInt("CarrotCoin1", 0);
        hoolCoin1 = PlayerPrefs.GetInt("HoolCoin1", 0);
      
    }


    private void Update()
    {
        //ESC초기화
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("ESC");
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("map2");
        }


        //당근이 비활성화 상태 && 바가 활성화라면
        if (CarrotObject1 != null && !CarrotObject1.activeSelf && BaObject1.activeSelf)
        {
            //코인 활성화 
            CarrotCoinObjrct1.gameObject.SetActive(true);

            //CarrotCoin = 1
            PlayerPrefs.SetInt("CarrotCoin1", 1);

        }
        else if (BaObject1.activeSelf)
        {
           
            HoolCoinObjct1.gameObject.SetActive(true);

            PlayerPrefs.SetInt("HoolCoin1", 1);
        }
       
        //Debug.Log("carrotCoin : " + carrotCoin);

        //만약 1인면  && 바가 활성화면 
        if (carrotCoin1 == 1 && BaObject1.activeSelf)
        {
            CarrotCoinObjrct1.SetActive(true);
        }
        else if (hoolCoin1 == 1 && BaObject1.activeSelf)
        {
            
            HoolCoinObjct1.SetActive(true);

        }

    }

}

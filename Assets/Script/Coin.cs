using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    //당근 오브젝트
    [Header("Coin")]
    public GameObject HoolCoinObjct;
    public GameObject CarrotCoinObjrct;


    [Header("GameObject")]
    public GameObject CarrotObject;
    public GameObject BaObject;


    int carrotCoin = 0;
    int hoolCoin = 0;
   

    private void Start()
    {
        //0으로 초기화 
        carrotCoin = PlayerPrefs.GetInt("CarrotCoin", 0);
        hoolCoin = PlayerPrefs.GetInt("HoolCoin", 0);
      
    }

    private void Update()
    {
        //ESC초기화
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("ESC");
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("map1");
        }


        //당근이 비활성화 상태 && 바가 활성화라면
        if (CarrotObject != null && !CarrotObject.activeSelf && BaObject.activeSelf)
        {
            //코인 활성화 
            CarrotCoinObjrct.gameObject.SetActive(true);

            //CarrotCoin = 1
            PlayerPrefs.SetInt("CarrotCoin", 1);

        }
        else if (BaObject.activeSelf)
        { 

            HoolCoinObjct.gameObject.SetActive(true);

            PlayerPrefs.SetInt("HoolCoin", 1);
        }
       

        //만약 1인면  && 바가 활성화면 
        if (carrotCoin == 1 && BaObject.activeSelf)
        {
            CarrotCoinObjrct.SetActive(true);
        }
        else if (hoolCoin == 1 && BaObject.activeSelf)
        {
            
            HoolCoinObjct.SetActive(true);

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mcoin : MonoBehaviour
{
    [Header("map1")]
    public GameObject HoolCoinObject1;
    public GameObject CarrotCoinObject1;
    public GameObject TimeCoinObject1;

    [Header("map2")]
    public GameObject HoolCoinObject2;
    public GameObject CarrotCoinObject2;
    public GameObject TimeCoinObject2;

    [Header("map3")]
    public GameObject HoolCoinObject3;
    public GameObject CarrotCoinObject3;
    public GameObject TimeCoinObject3;

    [Header("map4")]
    public GameObject HoolCoinObject4;
    public GameObject CarrotCoinObject4;
    public GameObject TimeCoinObject4;

    int carrotCoin = 0;
    int hoolCoin = 0;
    int coinTime = 0;

    int carrotCoin1 = 0;
    int hoolCoin1 = 0;
    int coinTime1 = 0;
    private void Start()
    {
        //0으로 초기화 
       carrotCoin = PlayerPrefs.GetInt("CarrotCoin", 0);
       hoolCoin = PlayerPrefs.GetInt("HoolCoin", 0);
        coinTime = PlayerPrefs.GetInt("CoinTime", 0);


        carrotCoin1 = PlayerPrefs.GetInt("CarrotCoin1", 0);
             coinTime1 = PlayerPrefs.GetInt("CoinTime1", 0);

    }

    private void Update()
    {
        if (carrotCoin == 1)
        { 
          CarrotCoinObject1.SetActive(true);
        }
        if (hoolCoin == 1)
        {
            HoolCoinObject1.SetActive(true);
        }
        if (coinTime == 1)
        { 
           TimeCoinObject1.SetActive(true);
        }


        if (carrotCoin1 == 1)
        {
            CarrotCoinObject2.SetActive(true);
        }
        if (hoolCoin1 == 1)
        {
            HoolCoinObject2.SetActive(true);
        }
        if (coinTime1 == 1)
        {
            TimeCoinObject2.SetActive(true);
        }



    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    //��� ������Ʈ
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
        //0���� �ʱ�ȭ 
        carrotCoin = PlayerPrefs.GetInt("CarrotCoin", 0);
        hoolCoin = PlayerPrefs.GetInt("HoolCoin", 0);
      
    }

    private void Update()
    {
        //ESC�ʱ�ȭ
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("ESC");
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("map1");
        }


        //����� ��Ȱ��ȭ ���� && �ٰ� Ȱ��ȭ���
        if (CarrotObject != null && !CarrotObject.activeSelf && BaObject.activeSelf)
        {
            //���� Ȱ��ȭ 
            CarrotCoinObjrct.gameObject.SetActive(true);

            //CarrotCoin = 1
            PlayerPrefs.SetInt("CarrotCoin", 1);

        }
        else if (BaObject.activeSelf)
        { 

            HoolCoinObjct.gameObject.SetActive(true);

            PlayerPrefs.SetInt("HoolCoin", 1);
        }
       

        //���� 1�θ�  && �ٰ� Ȱ��ȭ�� 
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

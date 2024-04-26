using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class carrot : MonoBehaviour
{
    public Image Carrotimage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
           
            gameObject.SetActive(false);

            Carrotimage.gameObject.SetActive(true);

            //PlayerPrefs.SetInt("carrot", 1);
            //PlayerPrefs.Save();

            int abc = PlayerPrefs.GetInt("carrot");            
            Debug.Log("abc : " + abc);

        }
    }

}

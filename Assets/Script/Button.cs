using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject Settingimag;//세팅 이미지

    public GameObject AudioOffImage;
    public GameObject AudioOnImage;

    public void OnButton()
    {
        Settingimag.SetActive(!Settingimag.activeSelf);
    }


    public void onmap1()
    {
        SceneManager.LoadScene("map1");
    
    }

    public void onMapchoice()
    {
        SceneManager.LoadScene("Mapchoice");
    
    }

    public void OffImage()
    {
        AudioOffImage.SetActive(true);
        AudioOnImage.SetActive(false);
    }


    public void OnImage()
    {
        AudioOnImage.SetActive(true);
        AudioOffImage.SetActive(false);
    }

    public void onmap2()
    {
        SceneManager.LoadScene("map2");

    }


}





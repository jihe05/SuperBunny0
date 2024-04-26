using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Audio : MonoBehaviour
{
    public AudioSource BgSound;
    public  static Audio instance;//Audio�� �ν��Ͻ� ����
    public AudioClip[] bglist;

    private void Awake()
    {
        if (instance == null)//���������
        {
            instance = this;//���� ��ũ��Ʈ�� ����
            DontDestroyOnLoad(gameObject); //���� ��Ȳ �ǵ� �ı����� ����
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);//�ƴϸ� �ı�
        }

    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {

        for(int i = 0; i < bglist.Length; i++)
        {
            if (arg0.name == bglist[i].name)
            {
                Debug.Log(i);
                BgSoundplay(bglist[i]);
            }
           
        }

    }


    //string Jumpname  : ����� �̸�
    // AudioClip jumpClip : ����� Ŭ��
    public void PlayerJump(string Jumpname , AudioClip jumpClip)
    {
        //���ο� �� ���� ������Ʈ�� �����ϰ� �̸��� ����
        GameObject jump = new GameObject(Jumpname + "Sound");
        //����� ���۳�Ʈ �߰�
        AudioSource jumpsource = jump.AddComponent<AudioSource>();
        jumpsource.clip = jumpClip;
        jumpsource.Play();

        //����� Ŭ���� ���� �Ŀ� ���� ������Ʈ�� ���� 
        Destroy(jump, jumpClip.length);
    }

    public void PlayerJump2(string Jumpname1, AudioClip jumpClip1)
    {


        GameObject jump1 = new GameObject(Jumpname1 + "Sound");

        AudioSource jumpsource1 = jump1.AddComponent<AudioSource>();
        jumpsource1.clip = jumpClip1;
        jumpsource1.Play();

        //����� Ŭ���� ���� �Ŀ� ���� ������Ʈ�� ���� 
        Destroy(jump1, jumpClip1.length);

    }


    public void PlayerJumpGround(string JumpnameG, AudioClip jumpClipG)
    {


        GameObject jumpG = new GameObject(JumpnameG + "Sound");

        AudioSource jumpsourceG = jumpG.AddComponent<AudioSource>();
        jumpsourceG.clip = jumpClipG;
        jumpsourceG.Play();

        //����� Ŭ���� ���� �Ŀ� ���� ������Ʈ�� ���� 
        Destroy(jumpG, jumpClipG.length);

    }


    public void PlayerDead(string dead, AudioClip deadclip)
    {


        GameObject Dead = new GameObject(dead + "Sound");

        AudioSource deadsource = Dead.AddComponent<AudioSource>();
        deadsource.clip = deadclip;
        deadsource.Play();

        //����� Ŭ���� ���� �Ŀ� ���� ������Ʈ�� ���� 
        Destroy(Dead, deadclip.length);

    }

    public void Ground(string ground, AudioClip groundclip)
    {


        GameObject Ground = new GameObject(ground + "Sound");

        AudioSource goundsource = Ground.AddComponent<AudioSource>();
        goundsource.clip = groundclip;
        goundsource.Play();

        //����� Ŭ���� ���� �Ŀ� ���� ������Ʈ�� ���� 
        Destroy(Ground, groundclip.length);

    }

    public void Gasi(string gasi, AudioClip gasiclip)
    {

        GameObject Gasi = new GameObject(gasi + "Sound");

        AudioSource gasisource = Gasi.AddComponent<AudioSource>();
        gasisource.clip = gasiclip;
        gasisource.Play();

        //����� Ŭ���� ���� �Ŀ� ���� ������Ʈ�� ���� 
        Destroy(Gasi, gasiclip.length);

    }
    public void Gasi1(string gasi1, AudioClip gasiclip1)
    {

        GameObject Gasi1 = new GameObject(gasi1 + "Sound");

        AudioSource gasisource1 = Gasi1.AddComponent<AudioSource>();
        gasisource1.clip = gasiclip1;
        gasisource1.Play();

        //����� Ŭ���� ���� �Ŀ� ���� ������Ʈ�� ���� 
        Destroy(Gasi1, gasiclip1.length);

    }

    public void Spring(string spring, AudioClip springclip)
    {

        GameObject Spring = new GameObject(spring + "Sound");

        AudioSource springsource = Spring.AddComponent<AudioSource>();
        springsource.clip = springclip;
        springsource.Play();

        //����� Ŭ���� ���� �Ŀ� ���� ������Ʈ�� ���� 
        Destroy(Spring, springclip.length);

    }


    public void BgSoundplay(AudioClip clip)
    {
        BgSound.clip = clip;//Ŭ������
        BgSound.loop = true;//�ݺ����
        BgSound.volume = 10f;//����
        BgSound.Play();
    }

}

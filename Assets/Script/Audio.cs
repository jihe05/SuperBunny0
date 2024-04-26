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
    public  static Audio instance;//Audio의 인스턴스 저장
    public AudioClip[] bglist;

    private void Awake()
    {
        if (instance == null)//비어있으면
        {
            instance = this;//현재 스크립트의 저장
            DontDestroyOnLoad(gameObject); //씬이 전황 되도 파괴되지 않음
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);//아니면 파괴
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


    //string Jumpname  : 오디오 이름
    // AudioClip jumpClip : 오디오 클립
    public void PlayerJump(string Jumpname , AudioClip jumpClip)
    {
        //새로운 빈 게임 오브젝트를 생성하고 이름을 지정
        GameObject jump = new GameObject(Jumpname + "Sound");
        //오디오 컴퍼넌트 추가
        AudioSource jumpsource = jump.AddComponent<AudioSource>();
        jumpsource.clip = jumpClip;
        jumpsource.Play();

        //오디오 클립의 길이 후에 게임 오브젝트를 제거 
        Destroy(jump, jumpClip.length);
    }

    public void PlayerJump2(string Jumpname1, AudioClip jumpClip1)
    {


        GameObject jump1 = new GameObject(Jumpname1 + "Sound");

        AudioSource jumpsource1 = jump1.AddComponent<AudioSource>();
        jumpsource1.clip = jumpClip1;
        jumpsource1.Play();

        //오디오 클립의 길이 후에 게임 오브젝트를 제거 
        Destroy(jump1, jumpClip1.length);

    }


    public void PlayerJumpGround(string JumpnameG, AudioClip jumpClipG)
    {


        GameObject jumpG = new GameObject(JumpnameG + "Sound");

        AudioSource jumpsourceG = jumpG.AddComponent<AudioSource>();
        jumpsourceG.clip = jumpClipG;
        jumpsourceG.Play();

        //오디오 클립의 길이 후에 게임 오브젝트를 제거 
        Destroy(jumpG, jumpClipG.length);

    }


    public void PlayerDead(string dead, AudioClip deadclip)
    {


        GameObject Dead = new GameObject(dead + "Sound");

        AudioSource deadsource = Dead.AddComponent<AudioSource>();
        deadsource.clip = deadclip;
        deadsource.Play();

        //오디오 클립의 길이 후에 게임 오브젝트를 제거 
        Destroy(Dead, deadclip.length);

    }

    public void Ground(string ground, AudioClip groundclip)
    {


        GameObject Ground = new GameObject(ground + "Sound");

        AudioSource goundsource = Ground.AddComponent<AudioSource>();
        goundsource.clip = groundclip;
        goundsource.Play();

        //오디오 클립의 길이 후에 게임 오브젝트를 제거 
        Destroy(Ground, groundclip.length);

    }

    public void Gasi(string gasi, AudioClip gasiclip)
    {

        GameObject Gasi = new GameObject(gasi + "Sound");

        AudioSource gasisource = Gasi.AddComponent<AudioSource>();
        gasisource.clip = gasiclip;
        gasisource.Play();

        //오디오 클립의 길이 후에 게임 오브젝트를 제거 
        Destroy(Gasi, gasiclip.length);

    }
    public void Gasi1(string gasi1, AudioClip gasiclip1)
    {

        GameObject Gasi1 = new GameObject(gasi1 + "Sound");

        AudioSource gasisource1 = Gasi1.AddComponent<AudioSource>();
        gasisource1.clip = gasiclip1;
        gasisource1.Play();

        //오디오 클립의 길이 후에 게임 오브젝트를 제거 
        Destroy(Gasi1, gasiclip1.length);

    }

    public void Spring(string spring, AudioClip springclip)
    {

        GameObject Spring = new GameObject(spring + "Sound");

        AudioSource springsource = Spring.AddComponent<AudioSource>();
        springsource.clip = springclip;
        springsource.Play();

        //오디오 클립의 길이 후에 게임 오브젝트를 제거 
        Destroy(Spring, springclip.length);

    }


    public void BgSoundplay(AudioClip clip)
    {
        BgSound.clip = clip;//클립선언
        BgSound.loop = true;//반복재생
        BgSound.volume = 10f;//볼륨
        BgSound.Play();
    }

}

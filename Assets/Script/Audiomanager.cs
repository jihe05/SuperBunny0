using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{

    public AudioSource source;

    public void Music(float volume)
    { 
      source.volume = volume;
    
    }


}

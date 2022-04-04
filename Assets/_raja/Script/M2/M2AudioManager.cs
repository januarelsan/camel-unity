using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        clip.LoadAudioData();
        source.clip = clip;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySong() {
        source.Play();
    }
    public void StopSong()
    {
        source.Stop();
    }
    public void EndScene() { 
        clip.UnloadAudioData();
    }
}

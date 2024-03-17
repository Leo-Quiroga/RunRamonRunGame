using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] music;
    public AudioSource[] sfx;

    public int random;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, 3);
        PlayMusic(random);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void PlayMusic(int musicToPlay)
    {
        music[musicToPlay].Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Play();
    }

    public void StopPlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
    }

    public void StopPlayMusic(int musicStop)
    {
        music[musicStop].Stop();
    }
}

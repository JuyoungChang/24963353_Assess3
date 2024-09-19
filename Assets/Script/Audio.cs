using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip introClip;
    public AudioClip backgroundClip;

    private AudioSource introSource;
    private AudioSource bgmSource;


    private
    // Start is called before the first frame update
    void Start()
    {
        introSource = gameObject.AddComponent<AudioSource>();
        bgmSource = gameObject.AddComponent<AudioSource>();

        introSource.clip = introClip;
        bgmSource.clip = backgroundClip;

        bgmSource.loop = true;

        introSource.Play();
        Invoke("playBgm", introClip.length);

    }

    private void playBgm()
    {
        bgmSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

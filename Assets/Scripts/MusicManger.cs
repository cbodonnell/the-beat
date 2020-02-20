using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManger : MonoBehaviour
{
    [SerializeField]
    private TheBeat beat;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float volume = 0.2f;

    private bool startedMusic = false;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSource.volume = this.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startedMusic && this.beat.startedBeat) {
            this.audioSource.Play();
            this.startedMusic = true;
        }
    }
}

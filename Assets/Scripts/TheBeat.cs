using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.Events;

public class TheBeat : MonoBehaviour
{
    [SerializeField]
    private int beatsPerMinute = 128;
    [SerializeField]
    private int significantBeat = 4;
    [SerializeField]
    private int significantBar = 4;
    
    private float currentRunStartTime;

    private int beat = 0;
    private int bar = 0;
    private int passage = 0;

    [HideInInspector]
    public BeatEvent beatEvent;
    [HideInInspector]
    public bool startedBeat = false;

    // Start is called before the first frame update
    void Start()
    {
        this.ConfigureBeatEvent();
        this.currentRunStartTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        this.BeatCheck();
    }

    private void ConfigureBeatEvent()
    {
        if (this.beatEvent == null) {
            this.beatEvent = new BeatEvent();
        }
    }

    private void BeatCheck()
    {
        float timeElapsed = Time.time - currentRunStartTime;
        int thisBeat = Mathf.CeilToInt(this.beatsPerMinute * (timeElapsed / 60));
        if (thisBeat > this.beat) {
            // Trigger the first beat
            if (thisBeat == 1) {
                this.startedBeat = true;
                Debug.Log("Started: " + Time.time.ToString());
            }
            this.beat = thisBeat;
            // Beat logic...
            bool isBeatSignificant = thisBeat % this.significantBeat == 1;
            if (isBeatSignificant) {
                this.bar += 1;
                // Bar logic...
                
                bool isBarSignificant = this.bar % this.significantBar == 1;
                if (isBarSignificant) {
                    this.passage += 1;
                    this.beatEvent.Invoke("passage");
                    // Passage logic...
                    Debug.Log("Passage: " + this.passage.ToString());
                } else {
                    this.beatEvent.Invoke("bar");
                    Debug.Log("Bar: " + this.bar.ToString());
                }
            } else {
                this.beatEvent.Invoke("beat");
                Debug.Log("Beat: " + this.beat.ToString());
                bool isOffBeat = this.beat % (this.significantBeat / (this.significantBeat / 2)) == 0;
                bool isHalfBeat = this.beat % this.significantBeat == (this.significantBeat / 2) + 1;
                bool isUpBeat = (this.bar % this.significantBar == 0 && this.beat % this.significantBeat == 0);
                if (isOffBeat) {
                    if (isUpBeat) {
                        this.beatEvent.Invoke("upBeat");
                        Debug.Log("UpBeat: " + this.beat.ToString());
                    } else {
                        this.beatEvent.Invoke("offBeat");
                        Debug.Log("OffBeat: " + this.beat.ToString());
                    }
                }
                if (isHalfBeat) {
                    this.beatEvent.Invoke("halfBeat");
                    Debug.Log("HalfBeat: " + this.beat.ToString());
                }
            }
        } else {
            // not a new beat... do nothing
        }
    }
}

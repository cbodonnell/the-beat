using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;

public class AnimateOnBeat : MonoBehaviour
{
    [SerializeField]
    private TheBeat beat;
    [SerializeField]
    private Animation objectAnimation;
    

    // Start is called before the first frame update
    void Start()
    {
        this.beat.beatEvent.AddListener(OnBeat);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeat(string type)
    {
        switch (type)
        {
            case "beat":
                this.objectAnimation.Play("BeatAnimation");
                break;
            case "bar":
                this.objectAnimation.Play("BarAnimation");
                break;
            case "passage":
                this.objectAnimation.Play("PassageAnimation");
                break;
            case "offBeat":
                this.objectAnimation.Play("OffBeatAnimation");
                break;
            case "halfBeat":
                this.objectAnimation.Play("HalfBeatAnimation");
                break;
            case "upBeat":
                this.objectAnimation.Play("UpBeatAnimation");
                break;
            default:
                Debug.Log("Invalid type!");
                break;
        }
    }
}

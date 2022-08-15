using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;


public class push2talk : MonoBehaviour
{
    public Recorder rec;

    void Start()
    {
        rec.TransmitEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            rec.TransmitEnabled = true;

        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            rec.TransmitEnabled = false;

        }
    }

}

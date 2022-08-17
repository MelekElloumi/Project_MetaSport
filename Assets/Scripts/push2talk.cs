
using UnityEngine;
using Photon.Voice.Unity;


public class push2talk : MonoBehaviour
{
    Recorder rec;

    void Start()
    {
        rec=GetComponent<Recorder>();
        rec.TransmitEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (NonUIInput.GetKeyDown(KeyCode.T))
        {
            rec.TransmitEnabled = true;

        }
        if (NonUIInput.GetKeyUp(KeyCode.T))
        {
            rec.TransmitEnabled = false;

        }
    }

}

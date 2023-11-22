using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    // Start is called before the first frame update
    SpikeController[] spikeControllers;
    public bool isSpikeUp;


    void Start()
    {
        spikeControllers = FindObjectsOfType<SpikeController>();

    }

    // Update is called once per frame
    public void SpikeMove()
    {
        foreach (SpikeController spike in spikeControllers)
        {
            BoxCollider rbSpike = spike.GetComponent<BoxCollider>();
            rbSpike.enabled = false;
            rbSpike.enabled = true;

        }
        if (isSpikeUp)
        {
            foreach (SpikeController spike in spikeControllers)
            {
                if(spike.isFixed == false) spike.SpikeDown();
            }
            isSpikeUp = false;
        }
        else
        {
            foreach (SpikeController spike in spikeControllers)
            {
                if (spike.isFixed == false) spike.SpikeUp();
            }
            isSpikeUp = true;
        }

    }
}

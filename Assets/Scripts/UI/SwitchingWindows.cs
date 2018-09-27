using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingWindows : MonoBehaviour {

    public GameObject leftCam;
    public GameObject rightCam;
    public GameObject midCam;
    public GameObject player;

    public GameObject stockUI;
    public void turnLeft()
    {
        if (midCam.active == true)
        {
            midCam.SetActive(false);
            leftCam.SetActive(true);
        } else{
            midCam.SetActive(true);
            rightCam.SetActive(false);
        }
    }
    public void turnRight()
    {
        if (midCam.active == true)
        {
            midCam.SetActive(false);
            rightCam.SetActive(true);
        }
        else
        {
            midCam.SetActive(true);
            leftCam.SetActive(false);
        }

    }

    public void leaveDesk()
    {
        midCam.SetActive(false);
        stockUI.SetActive(false);
        player.SetActive(true);

    }
}

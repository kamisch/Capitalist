using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuButtons : MonoBehaviour {
    public GameObject menu;
    
    public void QuitApp()
    {
        Application.Quit();
    }

     public void resume()
    {
		GameObject.Find("Menu").SetActive(false);
        Time.timeScale = 1;
    }

    public void option()
    {

    }
}

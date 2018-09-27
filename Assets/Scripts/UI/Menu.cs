using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject menu;

	// Use this for initialization
	void Start () {
        hideMenu();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
            {
                showMenu();
            } else
            {
                hideMenu();
            }
        }
	}

    private void hideMenu()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        

    }
    private void showMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0;

    }
}

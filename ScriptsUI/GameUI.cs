using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (pauseMenu.activeSelf == false)
            {
                pauseMenu.SetActive(true);
            }

            if (optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(false);
            }

        }

    }
}


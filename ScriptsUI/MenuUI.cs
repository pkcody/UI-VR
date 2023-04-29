using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject paintingMenu;
    public GameObject soundMusic;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
            }

            if (paintingMenu.activeSelf)
            {
                paintingMenu.SetActive(false);
                soundMusic.SetActive(true);
            }

        }

    }
}

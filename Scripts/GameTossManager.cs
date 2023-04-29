using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTossManager : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;

    public GameObject player;

    public Image blackScreen;

    public float countdown = 20f;

    public TextMeshProUGUI instructions;
    public TextMeshProUGUI time;
    public TextMeshProUGUI scoreUI;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = pos1.position;
        instructions.text = "Hurry and build some towers before time runs out!";
        time.text = ""+ countdown;
        scoreUI.text = "Score: " + score;
    }

    public void GameStart()
    {
        blackScreen.gameObject.SetActive(true);
        player.transform.position = pos2.position;
        instructions.text = "Knock over your towers, but be careful of the obsticles!";

        //StartCoroutine(Fade(true));

    }
    IEnumerator Fade(bool fadeAway)
    {
        // fade to transparent
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                blackScreen.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade to opaque
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                blackScreen.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            time.text = "" + countdown;
            


        }
        else
        {
            time.text = "";

            //StartCoroutine(Fade(false));
            GameStart();

        }
    }

    public void UpdateScore()
    {
        scoreUI.text = "Score: " + score;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MazeCheck : MonoBehaviour
{
    public ParticleSystem ActivateParticle;
    public float timeToSelect = 2.0f;
    public int score;

    Transform camera;
    private float countDown;

    public TextMeshProUGUI ScoreText;

    bool CanPlay = false;

    //all umbs
    public bool umbrella1 = false;
    public bool umbrella2 = false;
    public bool umbrella3 = false;
    public bool umbrella4 = false;

    //audio
    public AudioSource _as;
    public List<AudioClip> audioClips;


    void Start()
    {
        camera = Camera.main.transform;
        score = 0;
        ScoreText.text = "Score: " + score;
        countDown = timeToSelect;
        

        Restart();
    }
    public void Restart()
    {
        GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, .5f);
        StartCoroutine(delaygamestart());
        score = 0;
        ScoreText.text = "Score: " + score;

        umbrella1 = false;
        umbrella2 = false;
        umbrella3 = false;
        umbrella4 = false;


    }

    IEnumerator delaygamestart()
    {
        CanPlay = false;
        yield return new WaitForSeconds(5.0f);
        CanPlay = true;
        GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 1f);

    }

    public void TryFirework()
    {
        if (umbrella1 && umbrella2 && umbrella3 && umbrella4)
        {
            _as.clip = audioClips.Find(clipName => clipName.name == "fireworks");
            _as.PlayOneShot(_as.clip, 0.5f);

            umbrella1 = false;
            umbrella2 = false;
            umbrella3 = false;
            umbrella4 = false;
        }
    }

    void Update()
    {
        if (CanPlay)
        {
            bool isHitting = false;

            Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "PowerUp")
                {
                    isHitting = true;

                    
                }
                else if (hit.collider.gameObject.tag == "Walls")
                {
                    Restart();
                }
            }
            if (isHitting)
            {
                if (countDown > 0.0f)
                {
                    // on target
                    countDown -= Time.deltaTime;
                    print(countDown);
                    ActivateParticle.transform.position = hit.point;
                    if (ActivateParticle.isStopped)
                    {
                        ActivateParticle.Play();
                    }
                }
                else
                {
                    // killed
                    //Instantiate(killEffect, target.transform.position, target.transform.rotation);
                    score += 1;

                    _as.clip = audioClips.Find(clipName => clipName.name == "waterdrop");
                    _as.PlayOneShot(_as.clip, 0.5f);

                    ScoreText.text = "Score: " + score;
                    countDown = timeToSelect;

                    if (hit.transform.name.Contains("Umb1"))
                    {
                        umbrella1 = true;
                        TryFirework();
                    }
                    else if (hit.transform.name.Contains("Umb2"))
                    {
                        umbrella2 = true;
                        TryFirework();
                    }
                    else if (hit.transform.name.Contains("Umb3"))
                    {
                        umbrella3 = true;
                        TryFirework();
                    }
                    else if (hit.transform.name.Contains("Umb4"))
                    {
                        umbrella4 = true;
                        TryFirework();
                    }

                    //SetRandomPosition();
                }
            }
            else
            {
                // reset
                countDown = timeToSelect;
                ActivateParticle.Stop();
            }
        }

    }


}

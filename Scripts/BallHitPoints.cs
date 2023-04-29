using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitPoints : MonoBehaviour
{
    public GameTossManager manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Hoop"))
        {
            manager.score += 1;
        }
        else if (other.tag.Contains("Buckets"))
        {
            manager.score += 3;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        manager.UpdateScore();

    }
}

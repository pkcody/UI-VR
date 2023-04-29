using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalloonController : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float floatStrength = 20f;
    
    private GameObject balloon;
    public float growRate = 1.5f;
    private Rigidbody rb;

    //private void Start()
    //{
    //    buttonController.ButtonDownEvent.AddListener(CreateBalloon);
    //    buttonController.ButtonUpEvent.AddListener(ReleaseBalloon);

    //}
    public void CreateBalloon(GameObject parentHand)
    {
        balloon = Instantiate(balloonPrefab, parentHand.transform);
        balloon.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        rb = balloon.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    public void ReleaseBalloon()
    {
        rb.isKinematic = false;

        //Rigidbody rb = balloon.GetComponent<Rigidbody>();
        //Vector3 force = Vector3.up * floatStrength;
        //rb.AddForce(force);
        balloon.transform.parent = null;
        balloon.GetComponent <Rigidbody>().AddForce(Vector3.up * floatStrength);

        GameObject.Destroy(balloon, 10f);
        balloon = null;
    }
    public void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (balloon != null)
        {
            GrowBalloon();
        }

    }
}

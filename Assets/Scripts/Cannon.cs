using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Cannon : MonoBehaviour
{
    public GameObject ballPrefab1, ballPrefab2, ballPrefab3, spherePos, readyBall;
    public bool shoot, autoShoot;
    public int force = 1000;
    public GameObject forceText;


    void Update()
    {
        // Force deðerini TextMeshPro ile ekranda göster
        forceText.GetComponent<TextMeshPro>().text = "Force:" + force.ToString();
        if (autoShoot == false)
        {
            if (Input.GetMouseButtonDown(0) && shoot == true)
            {
                shoot = false;
                readyBall.transform.parent = null;
                readyBall.GetComponent<Rigidbody>().isKinematic = false;
                readyBall.GetComponent<Rigidbody>().AddForce(transform.up * force);
                readyBall.GetComponent<Rigidbody>().useGravity = true;
                StartCoroutine(NewBallActivate());
            }
        }
        else if (autoShoot == true)
        {
            if (Input.GetMouseButton(0) && shoot == true)
            {
                shoot = false;
                readyBall.transform.parent = null;
                readyBall.GetComponent<Rigidbody>().isKinematic = false;
                readyBall.GetComponent<Rigidbody>().AddForce(transform.up * force);
                readyBall.GetComponent<Rigidbody>().useGravity = true;
                StartCoroutine(NewBallActivate());
            }
        }
    }

    IEnumerator NewBallActivate()
    {
        yield return new WaitForSeconds(0.1f);
        int x = Random.Range(0, 3);
        GameObject selectedBall;
        if (x == 0)
        {
            selectedBall = ballPrefab1;
            force = 1100; // ballPrefab1 için force deðeri
        }
        else if (x == 1)
        {
            selectedBall = ballPrefab2;
            force = 1000; // ballPrefab2 için force deðeri
        }
        else
        {
            selectedBall = ballPrefab3;
            force = 1200;
        }
        GameObject newBall = Instantiate(selectedBall, spherePos.transform.position, Quaternion.identity);
        newBall.transform.parent = spherePos.transform.parent;
        newBall.GetComponent<SphereCollider>().enabled = true;
        newBall.SetActive(true);
        shoot = true;
        readyBall = newBall;
    }

}

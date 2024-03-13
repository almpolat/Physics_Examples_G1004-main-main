using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject ballPrefab1, ballPrefab2, ballPrefab3, spherePos, readyBall;
    public bool shoot, autoShoot;
    public int force = 1000;

    void Update()
    {
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
            selectedBall = ballPrefab1;
        else if (x == 1)
            selectedBall = ballPrefab2;
        else
            selectedBall = ballPrefab3;
        GameObject newBall = Instantiate(selectedBall, spherePos.transform.position, Quaternion.identity);
        newBall.transform.parent = spherePos.transform.parent;
        newBall.GetComponent<SphereCollider>().enabled = true;
        newBall.SetActive(true);
        shoot = true;
        readyBall = newBall;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            //do something like score or penalty and Destroy the ball or make it SetActive(false)
            Destroy(this.gameObject);
        }
    }

}

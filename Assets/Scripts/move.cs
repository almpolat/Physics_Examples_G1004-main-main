using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{
    public int speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1)*Time.deltaTime*speed);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "finish line")
        speed = 0;

        if(other.tag == "checkpoint")
        speed = 20;
    }
    
}

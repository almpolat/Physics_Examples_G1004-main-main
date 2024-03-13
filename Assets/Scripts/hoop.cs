using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hoop : MonoBehaviour
{
    public int score = 0;
    public GameObject scoreText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball1")//Blue
        {
            score += 1;
        }
        if (other.tag == "Ball2")//Red
        {
            score -= 8;

        }
        if (other.tag == "Ball3")//Yellow
        {
            score += 3;
        }
        scoreText.GetComponent<TextMeshPro>().text = score.ToString();
    }
}
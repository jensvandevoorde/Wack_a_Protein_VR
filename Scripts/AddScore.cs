using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    public int Score;
    public Text ScoreText;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Protein")
        {
            Add();
        }
    }

    void Add()
    {
        //Om score te tonen in het text box
        Score += 1;
        ScoreText.text = Score.ToString("Score: " + Score);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addTime : MonoBehaviour
{
    [SerializeField] Text countDownTimer;
    float addedTime;

    void Start()
    {
        addedTime = 10f;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Protein"))
        {
            countDownTimer.text += addedTime.ToString("0");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteinAnimation : MonoBehaviour
{
    Vector3 startPos;
    Vector3 destinationPos;
    float totalTime = 10f;
    float timePassed;
    bool isMoving = false;

    bool bulletEffect = false;
    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        destinationPos = new Vector3(startPos.x, 2, startPos.z);
    }

    // Update is called once per frame
    void Update()
    {

        isMoving = true;


        if (isMoving && !bulletEffect)
        {
            timePassed += Time.deltaTime;
            AnimateProtein();
        }



    }
    //this makes the proteins move from the floor the ceiling
    void AnimateProtein()
    {

        if (timePassed < totalTime)
        {
            float percentagePassed = timePassed / totalTime;
            transform.position = Vector3.Lerp(startPos, destinationPos, percentagePassed);

        }
        else
        {
            transform.position = destinationPos;
            isMoving = false;
        }
        if (!isMoving)
        {
            Destroy(gameObject);
        }
    }
    // Stops the Protein from moving
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            bulletEffect = true;
        }
    }
}

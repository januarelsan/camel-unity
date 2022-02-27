using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fasion1Manager : MonoBehaviour
{
    public Transform objectss;
    public int counter=0;
    public GameObject next;
    public GameObject prev;
    // Start is called before the first frame update
    void Start()
    {
                objectss.position = new Vector3(-0.01f, objectss.position.y, objectss.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActiionsButton(int actions) {
        if (actions == 0)
        {
            counter--;
        }
        else
        {
            counter++;

        }

        switch (counter)
        {
            case 0:
                objectss.position = new Vector3(-0.01f, objectss.position.y, objectss.position.z);
                prev.SetActive(false);
                next.SetActive(true);

                break;
            case 1:
                objectss.position = new Vector3(-2.031f, objectss.position.y, objectss.position.z);
                prev.SetActive(true);
                next.SetActive(true);
                break;
            case 2:
                objectss.position = new Vector3(-4.054f, objectss.position.y, objectss.position.z);
                prev.SetActive(true);
                next.SetActive(true);
                break;
            case 3:
                objectss.position = new Vector3(-6.067f, objectss.position.y, objectss.position.z);
                prev.SetActive(true);
                next.SetActive(false);
                break;
        }
        
    }
    public void PrevButton()
    {
        counter--;




        if (counter > 1)
        {
            objectss.position = new Vector3(objectss.position.x + 1, objectss.position.y, objectss.position.z);
            next.SetActive(true);
        }
        else if (counter == 0)
        {
            objectss.position = new Vector3(objectss.position.x + 1, objectss.position.y, objectss.position.z);
            prev.SetActive(false);

        }
    }
}

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
                objectss.position = new Vector3(-0.024f, objectss.position.y, objectss.position.z);
                prev.SetActive(false);
                next.SetActive(true);

                break;
            case 1:
                objectss.position = new Vector3(-1.524f, objectss.position.y, objectss.position.z);
                prev.SetActive(true);
                next.SetActive(true);
                break;
            case 2:
                objectss.position = new Vector3(-3.024f, objectss.position.y, objectss.position.z);
                prev.SetActive(true);
                next.SetActive(true);
                break;
            case 3:
                objectss.position = new Vector3(-4.524f, objectss.position.y, objectss.position.z);
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

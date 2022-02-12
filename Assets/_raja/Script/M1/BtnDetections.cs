using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDetections : MonoBehaviour
{
    public bool stat= false;
    public bool down = true;
    public bool outBorder = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().interactable = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enters");
        if (collision.gameObject.tag == "border")
        {
            stat = true;
            down = false;
            outBorder = false;
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("enters");
        if (collision.gameObject.tag == "border")
        {
            stat = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "border")
        {
            stat = false;
        }
    }
    //public void OnTriggerExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "border")
    //    {
    //        //stat = false;
    //    }
    //}
    public void ButtonActions() {
        gameObject.GetComponent<Button>().interactable = false;
        if (stat) {
            Debug.Log("Hit True");
            //GameObject.FindGameObjectWithTag("Manager").GetComponent<Music1Manager>().score += 5;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<Music1Manager>().AddPoint();
        }
        else { 
            Debug.Log("Hit False");

        }
    }
}

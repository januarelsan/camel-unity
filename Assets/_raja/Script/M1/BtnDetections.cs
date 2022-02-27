using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDetections : MonoBehaviour
{
    public enum kindColor { blue,green,orange};
    public kindColor kindColors;
    public bool stat= false;
    public bool miss = true;
    public bool outBorder = false;
    public bool hadAction = false;
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
            miss = false;

            outBorder = false;
        }
        if (collision.gameObject.tag == "miss")
        {
            stat = false;
            miss = true;

            outBorder = false;
        }
        if (collision.gameObject.tag == "limit")
        {
            stat = false;
            miss = true;

            outBorder = true;
            ButtonActions();
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "border")
        {
            stat = false;
        }
        if (collision.gameObject.tag == "miss")
        {
            miss = false;
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
        if (hadAction == false) {
            gameObject.GetComponent<Button>().interactable = false;
            if (stat == true && miss == false & outBorder == false)
            {
                Debug.Log("Hit True");
                //GameObject.FindGameObjectWithTag("Manager").GetComponent<Music1Manager>().score += 5;
                GameObject.FindGameObjectWithTag("Manager").GetComponent<Music1Manager>().AddPoint();
                GameObject.FindGameObjectWithTag("Manager").GetComponent<Music1Manager>().TrueFalseLine(kindColors.ToString(), stat);
            }
            else
            {
                Debug.Log("Hit False");
                GameObject.FindGameObjectWithTag("Manager").GetComponent<Music1Manager>().TrueFalseLine(kindColors.ToString(), stat);
            }
            hadAction = true;
        }
        
    }
}

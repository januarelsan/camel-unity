using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapbutton : MonoBehaviour
{
    
    public GameObject door;
    public GameObject door2;
    public GameObject baju;
    //public Animator anim;
    private Material m_Mat;
    public Music3Manager music3Manager;
    public ApiManagerR apiManagerR;

    void OnEnable()
    {
        Renderer r = transform.GetComponent<Renderer>();
        if (r != null) {
            m_Mat = transform.GetComponent<Renderer>()?.material;
        }
        
        apiManagerR = GameObject.FindGameObjectWithTag("UrlManager").GetComponent<ApiManagerR>();
    }

    public void OnMouseDown()
    {
        if (m_Mat != null)
        {
            apiManagerR = GameObject.FindGameObjectWithTag("UrlManager").GetComponent<ApiManagerR>();

            //anim.SetTrigger("pintu");
            if (door != null)
            {
                door.SetActive(true);
            }
            if (door2 != null)
            {
                door2.SetActive(true);
            }
            if (baju != null)
            {
                baju.SetActive(false);
            }
            if (music3Manager == null)
            {
                apiManagerR.DirectLinkparam();


            }
            else if (music3Manager != null)
            {
                music3Manager.StopSound();
            }
        }
        else { 
                apiManagerR.DirectLinkparam();


        }
    }
}

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

    void OnEnable()
    {
        m_Mat = transform.GetComponent<Renderer>()?.material;
    }

    public void OnMouseDown()
    {
        if (m_Mat != null)
        {
            
            //anim.SetTrigger("pintu");
            door.SetActive(true);
            door2.SetActive(true);
            baju.SetActive(false);
        }
    }
}

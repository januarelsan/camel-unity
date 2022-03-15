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
    public A1Manager a1Manager;
    public Art3 a3Manager;
    public Fasion1Manager f1Manager;
    [SerializeField]
    public F2Manager f2Manager;
    public F3Manager f3Manager;



    public ApiManagerR apiManagerR;
    public bool isCorrectAns;

    public Vector3 corrects;
    public Vector3 falses;


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
            if (music3Manager != null)
            {
                //apiManagerR.DirectLinkparam();
                //CheckAns();
                music3Manager.ScoreM2(isCorrectAns);

            }
            if (a1Manager != null)
            {
                a1Manager.DoActions(isCorrectAns);
            }
            else if (music3Manager != null)
            {
                music3Manager.StopSound();
            }
            else if (a3Manager != null)
            {
                Vector3 newPos;
                if (isCorrectAns == true) {
                    newPos = corrects;
                }
                else {
                    newPos = falses;
                }
                a3Manager.DoScoress(isCorrectAns,transform,newPos);
            }
            else if (f1Manager != null)
            {
                f1Manager.DoAct();
            }
            else if (f2Manager != null)
            {
                Debug.Log("linked1");

                f2Manager.DoAct();//
            }
            else if (f3Manager != null)
            {
               

                f3Manager.DoAct();//
            }
            //else if (f3Manager != null)
            //{


            //    f3Manager.DoAct();//
            //}
        }
        else {
            //apiManagerR.DirectLinkparam();
            //CheckAns();
            if (f2Manager != null)
            {
                Debug.Log("linked1");

                f2Manager.DoAct();//
            }
        }
    }
    public void CheckAns() {
        apiManagerR.DirectLinkparam();

        if (isCorrectAns)
        {
            //apiManagerR.DirectLinkparam(isCorrectAns);
        }
        else {

            //apiManagerR.DirectLinkparam();
        }
    
    }
}

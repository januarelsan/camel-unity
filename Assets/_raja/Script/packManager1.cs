using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;
using Zappar;
using DG.Tweening;
public class packManager1 : MonoBehaviour
{
    public List<GameObject> zapparImageTrackingTargets;
    public bool status;
    public bool showPack;
    public bool needTurnOnBelowPreviewImage;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject zpr in zapparImageTrackingTargets)
        {
            if (showPack)
            {
                zpr.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;

            }
            if (needTurnOnBelowPreviewImage)
            {
                zpr.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ManageTarget(GameObject gameObject) {
        status = true;

        //foreach (ZapparImageTrackingTarget game in zapparImageTrackingTargets) { 
        foreach (GameObject zpr in zapparImageTrackingTargets) {
            if (zpr.name != gameObject.name)
            {
                zpr.SetActive(false);
                if (showPack)
                {
                    zpr.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                }

            }
            else { 
                zpr.SetActive(true);
                if (showPack)
                {
                    zpr.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                }
                if (needTurnOnBelowPreviewImage)
                {
                    zpr.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

                }
            }
        }   

        if (status == false) {
            int curIndex = 0;
            switch (gameObject.name) {
                case "Pack CMA":
                    curIndex = 0;
                    break;
                case "Pack Blue":
                    curIndex = 1;
                    break;
                case "Pack Purple":
                    curIndex = 2;
                    break;
                case "Pack White":
                    curIndex = 3;
                    break;
                case "Pack Yellow":
                    curIndex = 4;
                    break;
                case "Pack Yellow (2)":
                    curIndex = 5;
                    break;

                default:
                    break;
            }
        }

    }
    public void Stopping() {
        if (status == true)
        {
            status = false;
            foreach (GameObject zpr in zapparImageTrackingTargets)
            {
                zpr.SetActive(true);
                zpr.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;


                if (needTurnOnBelowPreviewImage)
                {
                    zpr.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);

                }

            }
        }
        
        
    }
}

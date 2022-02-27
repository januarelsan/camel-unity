using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;
using Zappar;
using DG.Tweening;
public class packManager : MonoBehaviour
{
    public List<GameObject> zapparImageTrackingTargets;
    public bool status;
    public GameObject objects;
    public GameObject outsideParrent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ManageTarget(GameObject gameObject) {

        //foreach (ZapparImageTrackingTarget game in zapparImageTrackingTargets) { 
        foreach (GameObject zpr in zapparImageTrackingTargets) {
            if (zpr.name != gameObject.name)
            {
                zpr.SetActive(false);
            }
            else { 
                zpr.SetActive(true);

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
            objects.transform.parent = zapparImageTrackingTargets[curIndex].transform.GetChild(0).transform;
            objects.transform.localScale = Vector3.one;
            objects.transform.localPosition = Vector3.zero;
            objects.transform.localRotation =Quaternion.Euler(Vector3.zero);
            objects.transform.GetChild(0).GetComponent<rotate>().ReRotate();
            objects.transform.GetChild(1).GetComponent<rotate>().ReRotate();
            status = true;
        }

    }
    public void Stopping() {
        if (status == true)
        {
            objects.transform.parent = outsideParrent.transform;
            objects.transform.localPosition = Vector3.zero;
            objects.transform.localRotation = Quaternion.Euler(Vector3.zero);


            status = false;
            objects.transform.GetChild(0).GetComponent<rotate>().ReRotate();
            objects.transform.GetChild(1).GetComponent<rotate>().ReRotate();
            foreach (GameObject zpr in zapparImageTrackingTargets)
            {

                    zpr.SetActive(true);

            }
        }
        
        
    }
}

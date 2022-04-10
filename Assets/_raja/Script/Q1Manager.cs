using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Q1Manager : MonoBehaviour
{
    public Transform referTo;
    public Camera cameras;
    public GameObject rope;
    public bool allowShow;
    public List<Transform> listOfObj;
    public GameObject tracker;


    // Start is called before the first frame update
    void Start()
    {
        rope = referTo.gameObject;
        StopScans();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Transform transformsss;
    public void DoRefer(Transform transformss) {
        rope.SetActive(true);
        allowShow = true;
        transformsss = transformss;
        Invoke("ReRefer", 0);
    }
    void ReRefer() {
        Vector3 refe = cameras.WorldToScreenPoint(transformsss.position);//
        //Debug.Log(refe);
        referTo.localPosition = new Vector2(referTo.localPosition.x, (refe.y - Screen.height/2));
        //referTo.Rotate(Quaternion.(new Vector3(referTo.localRotation.x, referTo.localRotation.y, refe.z)), 0f);
        referTo.DOLocalRotate((new Vector3(referTo.localRotation.x, referTo.localRotation.y, -1*tracker.transform.rotation.z)), 0);

        if (allowShow) {
            Invoke("ReRefer", 0);
        }
        
    }

    public void StopScans() {
        rope.SetActive(false);
        allowShow = false;
        CancelInvoke("ReRefer");


    }
    public void DoAct(bool stat)
    {
        Debug.Log(stat);
        for (int i = 0; i < listOfObj.Count; i++)
        {
            listOfObj[i].GetComponent<BoxCollider>().enabled = false;

        }
        ScoringManager scoringManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoringManager>();
        scoringManager.DecisionMaking(stat);

    }
}

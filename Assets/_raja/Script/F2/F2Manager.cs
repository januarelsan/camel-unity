using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoAct(bool stat)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;

        }

        //Debug.Log("linked2");
        //ApiManagerR apiManagerR;
        //apiManagerR = GameObject.FindGameObjectWithTag("UrlManager").GetComponent<ApiManagerR>();
        //apiManagerR.DirectLinkparam();
        ScoringManager scoringManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoringManager>();
        scoringManager.DecisionMaking(stat);

    }
}

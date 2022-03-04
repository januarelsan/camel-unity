using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A1Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
    public void DoActions(bool stat)
    {
        ScoringManager scoringManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoringManager>();
        scoringManager.DecisionMaking(stat);
    }
}

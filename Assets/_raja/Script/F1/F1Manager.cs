using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> gameObjectData;
    void Start()
    {
        foreach (GameObject objects1 in gameObjectData) {
            objects1.SetActive(false);
        }
        foreach (GameObject objects2 in gameObjectData)
        {
            objects2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoAct(bool stat) {
        ScoringManager scoringManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoringManager>();
        scoringManager.DecisionMaking(stat);
    }
}

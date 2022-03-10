using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A2Manager : MonoBehaviour
{
    public InputField answerInput;
    public ScoringManager scoringManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreA2() {
        string answ = answerInput.text;
        answ = answ.ToLower();
        if (answ == "art") {
            scoringManager.DecisionMaking(true);
        }
        else { 
            scoringManager.DecisionMaking(false);

        }

    }
}

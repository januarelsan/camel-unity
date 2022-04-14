using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A1Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> listGB;
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("lobbyCode"));
        FinishedGameController.Instance.SetupFirstGame();
       
        int statBool = PlayerPrefController.Instance.GetStatusGame();
        Debug.Log(statBool);
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
    public void DoActions(bool stat)
    {
        foreach (GameObject gb in listGB) {
            gb.GetComponent<BoxCollider>().enabled = false;
        
        }
        ScoringManager scoringManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoringManager>();
        scoringManager.DecisionMaking(stat);
    }
}

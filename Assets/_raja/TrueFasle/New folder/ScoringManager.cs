using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Web;
using System.Runtime.InteropServices;
public class ScoringManager : MonoBehaviour
{
    public CanvasGroup falseUI;
    public CanvasGroup trueUI;
    public Button buttonAct;
    public string id;
    public string lobbyCode;
    public bool notDoCheck;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
        Debug.Log(PlayerPrefs.GetString("lobbyCode"));
        Debug.Log(PlayerPrefs.GetInt("currentGameID"));

        if (notDoCheck == false) {
            DoCheck();
        }

    }
    public void DoCheck() {
        falseUI = transform.GetChild(0).GetComponent<CanvasGroup>();
        trueUI = transform.GetChild(1).GetComponent<CanvasGroup>();
        buttonAct = transform.GetChild(2).GetComponent<Button>();
        id = GetParam("identity_no");
        lobbyCode = GetParam("lobbyCode");
        ApiManagerR apiManagerR = GameObject.FindGameObjectWithTag("UrlManager").GetComponent<ApiManagerR>();
        apiManagerR.id = id;
        apiManagerR.lobbyCode = lobbyCode;
        apiManagerR.WaitID();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecisionMaking(bool status) {


        //Finish this game, and setup next game
        FinishedGameController.Instance.SetupNextGame();
        FinishedGameController.Instance.CheckAllUserFinished();

        CanvasGroup currectCG;
        Debug.Log(status);
        if (status == true)
        {
            currectCG = trueUI;
        }
        else { 
            currectCG = falseUI;

        }
        CanvasGroup parrentCG = GetComponent<CanvasGroup>();
        parrentCG.DOFade(1, .5f).OnComplete(delegate {
            parrentCG.interactable = true;
            parrentCG.blocksRaycasts = true;
            buttonAct.interactable = true;
            buttonAct.onClick.AddListener(recievers);
            Debug.Log("start attaching");
        }); ;
        currectCG.DOFade(1, .5f).OnComplete(delegate {
            //buttonAct.interactable = true;
            //buttonAct.onClick.AddListener(recievers);
        });
        //Invoke("DoSecondCheck", .5f);
        InvokeRepeating("DoSecondCheck", .5f, 3f);
    }

    public void DoSecondCheck() { 
        FinishedGameController.Instance.CheckAllUserFinished();
    }


    public void recievers() {
        ApiManagerR apiManagerR = GameObject.FindGameObjectWithTag("UrlManager").GetComponent<ApiManagerR>();
        apiManagerR.id = id;
        apiManagerR.lobbyCode = lobbyCode;
        apiManagerR.DirectLinkparam();

    }
    public string GetFullURL()
    {
        return Application.absoluteURL;
    }

    public string GetParam(string name)
    {
        string url = Application.absoluteURL;
#if UNITY_EDITOR
        string example = "https://ihzv.zappar.io/3941965431407901021/1.0.Art1.17/?lobbyCode=CNPUR&identity_no=1234567890";
        url = example;
#endif
        Uri myUri = new Uri(url);
        string value = HttpUtility.ParseQueryString(myUri.Query).Get(name);
        return value;
    }

}

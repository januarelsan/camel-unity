using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Q5Manager : MonoBehaviour
{
    public List<Transform> listOfPos;
    public List<Transform> listOfObj;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("doanimates", 0);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doanimates(){
        CancelInvoke("doanimates");

        listOfObj[0].DOKill();
        listOfObj[1].DOKill();
        listOfObj[2].DOKill();
        listOfObj[3].DOKill();
        
        listOfObj[0].DOLocalMove(listOfPos[1].localPosition, 0).SetEase(Ease.Linear);
        listOfObj[1].DOLocalMove(listOfPos[2].localPosition, 0).SetEase(Ease.Linear);
        listOfObj[2].DOLocalMove(listOfPos[3].localPosition, 0).SetEase(Ease.Linear);
        listOfObj[3].DOLocalMove(listOfPos[4].localPosition, 0).SetEase(Ease.Linear);


        listOfObj[0].DOLocalMove(listOfPos[0].localPosition, speed).SetEase(Ease.Linear);
        listOfObj[1].DOLocalMove(listOfPos[1].localPosition, speed).SetEase(Ease.Linear);
        listOfObj[2].DOLocalMove(listOfPos[2].localPosition, speed).SetEase(Ease.Linear);
        listOfObj[3].DOLocalMove(listOfPos[3].localPosition, speed).SetEase(Ease.Linear).OnComplete(delegate {

            listOfObj[0].DOLocalMove(listOfPos[4].localPosition, 0).SetEase(Ease.Linear).OnComplete(delegate {
                listOfObj[1].DOLocalMove(listOfPos[0].localPosition, speed).SetEase(Ease.Linear);
                listOfObj[2].DOLocalMove(listOfPos[1].localPosition, speed).SetEase(Ease.Linear);
                listOfObj[3].DOLocalMove(listOfPos[2].localPosition, speed).SetEase(Ease.Linear);
                listOfObj[0].DOLocalMove(listOfPos[3].localPosition, speed).SetEase(Ease.Linear).OnComplete(delegate {

                    listOfObj[1].DOLocalMove(listOfPos[4].localPosition, 0).SetEase(Ease.Linear).OnComplete(delegate {
                        listOfObj[2].DOLocalMove(listOfPos[0].localPosition, speed).SetEase(Ease.Linear);
                        listOfObj[3].DOLocalMove(listOfPos[1].localPosition, speed).SetEase(Ease.Linear);
                        listOfObj[0].DOLocalMove(listOfPos[2].localPosition, speed).SetEase(Ease.Linear);
                        listOfObj[1].DOLocalMove(listOfPos[3].localPosition, speed).SetEase(Ease.Linear).OnComplete(delegate {

                            listOfObj[2].DOLocalMove(listOfPos[4].localPosition, 0).SetEase(Ease.Linear).OnComplete(delegate {
                                listOfObj[3].DOLocalMove(listOfPos[0].localPosition, speed).SetEase(Ease.Linear);
                                listOfObj[0].DOLocalMove(listOfPos[1].localPosition, speed).SetEase(Ease.Linear);
                                listOfObj[1].DOLocalMove(listOfPos[2].localPosition, speed).SetEase(Ease.Linear);
                                listOfObj[2].DOLocalMove(listOfPos[3].localPosition, speed).SetEase(Ease.Linear).OnComplete(delegate {
                                    listOfObj[3].DOLocalMove(listOfPos[4].localPosition, 0).SetEase(Ease.Linear);

                                    doanimates();
                                    Invoke("doanimates",0);
                                });

                            });


                        });

                    });


                });

            });

        });


        


    }


    public void StopAnimate() {

        listOfObj[0].DOKill();
        listOfObj[1].DOKill();
        listOfObj[2].DOKill();
        listOfObj[3].DOKill();

        listOfObj[0].DOLocalMove(listOfPos[1].position, 0).SetEase(Ease.Linear);
        listOfObj[1].DOLocalMove(listOfPos[2].position, 0).SetEase(Ease.Linear);
        listOfObj[2].DOLocalMove(listOfPos[3].position, 0).SetEase(Ease.Linear);
        listOfObj[3].DOLocalMove(listOfPos[4].position, 0).SetEase(Ease.Linear);

    }
    public void DoAct(bool stat) {
        for (int i = 0; i < listOfObj.Count; i++)
        {
            listOfObj[i].GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = false;

        }
        ScoringManager scoringManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoringManager>();
        scoringManager.DecisionMaking(stat);

    }
}

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doanimates(){
        listOfObj[0].DOKill();
        listOfObj[1].DOKill();
        listOfObj[2].DOKill();
        listOfObj[3].DOKill();
        
        listOfObj[0].DOMove(listOfPos[1].position, 0).SetEase(Ease.Linear);
        listOfObj[1].DOMove(listOfPos[2].position, 0).SetEase(Ease.Linear);
        listOfObj[2].DOMove(listOfPos[3].position, 0).SetEase(Ease.Linear);
        listOfObj[3].DOMove(listOfPos[4].position, 0).SetEase(Ease.Linear);


        listOfObj[0].DOMove(listOfPos[0].position, speed).SetEase(Ease.Linear);
        listOfObj[1].DOMove(listOfPos[1].position, speed).SetEase(Ease.Linear);
        listOfObj[2].DOMove(listOfPos[2].position, speed).SetEase(Ease.Linear);
        listOfObj[3].DOMove(listOfPos[3].position, speed).SetEase(Ease.Linear).OnComplete(delegate {

            listOfObj[0].DOMove(listOfPos[4].position, 0).SetEase(Ease.Linear).OnComplete(delegate {
                listOfObj[1].DOMove(listOfPos[0].position, speed).SetEase(Ease.Linear);
                listOfObj[2].DOMove(listOfPos[1].position, speed).SetEase(Ease.Linear);
                listOfObj[3].DOMove(listOfPos[2].position, speed).SetEase(Ease.Linear);
                listOfObj[0].DOMove(listOfPos[3].position, speed).SetEase(Ease.Linear).OnComplete(delegate {

                    listOfObj[1].DOMove(listOfPos[4].position, 0).SetEase(Ease.Linear).OnComplete(delegate {
                        listOfObj[2].DOMove(listOfPos[0].position, speed).SetEase(Ease.Linear);
                        listOfObj[3].DOMove(listOfPos[1].position, speed).SetEase(Ease.Linear);
                        listOfObj[0].DOMove(listOfPos[2].position, speed).SetEase(Ease.Linear);
                        listOfObj[1].DOMove(listOfPos[3].position, speed).SetEase(Ease.Linear).OnComplete(delegate {

                            listOfObj[2].DOMove(listOfPos[4].position, 0).SetEase(Ease.Linear).OnComplete(delegate {
                                listOfObj[3].DOMove(listOfPos[0].position, speed).SetEase(Ease.Linear);
                                listOfObj[0].DOMove(listOfPos[1].position, speed).SetEase(Ease.Linear);
                                listOfObj[1].DOMove(listOfPos[2].position, speed).SetEase(Ease.Linear);
                                listOfObj[2].DOMove(listOfPos[3].position, speed).SetEase(Ease.Linear).OnComplete(delegate {
                                    listOfObj[3].DOMove(listOfPos[4].position, 0).SetEase(Ease.Linear);

                                    doanimates();

                                });

                            });


                        });

                    });


                });

            });

        });


        


    }
}

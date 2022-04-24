using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Q6 : MonoBehaviour
{
    public Sprite correctSprite;
    public Sprite falseSprite;
    public int correctAnswer;
    public int countAnswer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoScoress(bool answers, Transform objectss,Vector3 vector3) {
        objectss.GetComponent<BoxCollider>().enabled = false;

        Debug.Log(answers);
//        Debug.Log(objectss.name);
        Vector3 nexpos;
        nexpos = vector3;
        CanvasGroup canvasGroup = objectss.GetChild(0).GetChild(0).GetComponent<CanvasGroup>();
        Image img = canvasGroup.transform.GetChild(0).GetComponent<Image>();
        canvasGroup.DOKill();


        //objectss.DOLocalMove(nexpos, .6f); 0.05
        if (answers == true)
        {
            //nexpos = objectss.GetChild(0).transform.position;
            //nexpos = vector3;
            objectss.GetChild(0).transform.DOLocalMoveY(.05f, .6f);
            img.sprite = correctSprite;
            img.preserveAspect = true;
            canvasGroup.DOFade(1, .6f);
            correctAnswer++;
        }
        else if (answers == false)
        {
            //nexpos = objectss.GetChild(1).transform.position;s
            objectss.GetChild(0).transform.DOLocalMoveY(-.05f, .6f);
            img.sprite = falseSprite;
            img.preserveAspect = true;
            canvasGroup.DOFade(1, .6f);

        }
        img.preserveAspect = true;
        countAnswer++;
        PostAnswer();

    }
    public void PostAnswer() {
        //if (correctAnswer == 5) {
        //    Debug.Log("Next");
        //    GetComponent<ScoringManager>().Invoke("recievers",1);
        //}
        ScoringManager scoringManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoringManager>();
            

        if (countAnswer == 4) {
            if (correctAnswer >= 3)
            {
                //benar
                scoringManager.DecisionMaking(true);

            }
            else { 
            //salah
            scoringManager.DecisionMaking(false);

            }
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Music1Manager : MonoBehaviour
{
    public Button StartButton;
    public List<Animator> animators;
    public Animator animatorSq;
    public AudioSource source;
    public AudioClip clip;
    public int score;
    public Text scoreText;
    public Image blueTrue;
    public Image greenTrue;
    public Image orangeTrue;    
    public Image blueFalse;
    public Image greenFalse;
    public Image orangeFalse;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.GetComponent<CanvasGroup>().alpha = 1;
        StartButton.GetComponent<CanvasGroup>().interactable = true;
        StartButton.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAnimation() {
        StartButton.GetComponent<CanvasGroup>().alpha = 0;
        StartButton.GetComponent<CanvasGroup>().interactable = false;
        StartButton.GetComponent<CanvasGroup>().blocksRaycasts = false;
        //source.Play();
        source.clip = clip;
        source.Play();
        animatorSq.SetTrigger("Start");
        
        Invoke("EndSeq", 30);
        //foreach (Animator animator1 in animators) {
        //    animator1.SetTrigger("Start");
        //}
    }
    public void EndSeq() {
        animatorSq.SetTrigger("Calls");
        ApiManagerR managerR = GameObject.FindGameObjectWithTag("UrlManager").GetComponent<ApiManagerR>();
        managerR.DirectLink();

    }


    public void AddPoint() {
        score += 5;
        scoreText.text = score.ToString();
    }
    public void TrueFalseLine(string line,bool stat) {
        switch (line) {
            case "blue":
                if (stat)
                {
                    blueTrue.DOKill();
                    blueFalse.DOKill();
                    blueTrue.DOFade(0, 0);
                    blueFalse.DOFade(0, 0);
                    blueTrue.DOFade(1, .3f).OnComplete(delegate {
                        blueTrue.DOFade(0, .3f);
                    });

                }
                else {
                    blueTrue.DOKill();
                    blueFalse.DOKill();
                    blueTrue.DOFade(0, 0);
                    blueFalse.DOFade(0, 0);
                    blueFalse.DOFade(1, .3f).OnComplete(delegate {
                        blueFalse.DOFade(0, .3f);
                    });
                }
                break;
            case "green":
                if (stat)
                {
                    greenTrue.DOKill();
                    greenFalse.DOKill();
                    greenTrue.DOFade(0, 0);
                    greenFalse.DOFade(0, 0);
                    greenTrue.DOFade(1, .3f).OnComplete(delegate {
                        greenTrue.DOFade(0, .3f);
                    });

                }
                else
                {
                    greenTrue.DOKill();
                    greenFalse.DOKill();
                    greenTrue.DOFade(0, 0);
                    greenFalse.DOFade(0, 0);
                    greenFalse.DOFade(1, .3f).OnComplete(delegate {
                        greenFalse.DOFade(0, .3f);
                    });
                }
                break;            
            case "orange":
                if (stat)
                {
                    orangeTrue.DOKill();
                    orangeFalse.DOKill();
                    orangeTrue.DOFade(0, 0);
                    orangeFalse.DOFade(0, 0);
                    orangeTrue.DOFade(1, .3f).OnComplete(delegate {
                        orangeTrue.DOFade(0, .3f);
                    });

                }
                else
                {
                    orangeTrue.DOKill();
                    orangeFalse.DOKill();
                    orangeTrue.DOFade(0, 0);
                    orangeFalse.DOFade(0, 0);
                    orangeFalse.DOFade(1, .3f).OnComplete(delegate {
                        orangeFalse.DOFade(0, .3f);
                    });
                }
                break;
            default:
                break;
        }
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Q4 : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public List<BoxCollider> boxCollider;
    public bool blinkAnimation;
    public List<Sprite> sprites;
    public Image refs;
    public ScoringManager scoringManager;
    public bool isM3;
    public Q4 q4;
    public List<Image> images;
    // Start is called before the first frame update
    void OnEnable()
    {
        foreach (BoxCollider box in boxCollider)
        {
            //box.enabled = false;
        }
        if (blinkAnimation)
        {
            //GetComponent<Image>().DOFade(0, 0);
            transform.GetComponent<CanvasGroup>().DOFade(0, 0f);
            Debug.Log("sss");
            DoBlink();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlaySound()
    {
        source.clip = clip;
        source.Play();
        foreach (BoxCollider box in boxCollider)
        {
            box.enabled = true;
        }
    }
    public void StopSound()
    {
        source.Stop();
        foreach (BoxCollider box in boxCollider)
        {
            box.enabled = false;
        }
    }
    public void DoBlink()
    {
        //float rands = Random.Range(0, 5);
        //GetComponent<Image>().DOFade(1, .5f).SetDelay(rands).OnComplete(delegate {
        //    float randss = Random.Range(0, 5);
        //    GetComponent<Image>().DOFade(0, .5f).SetDelay(randss).OnComplete(delegate {

        //        DoBlink();
        //    });

        //});
        transform.GetComponent<CanvasGroup>().DOFade(0, 0f);

        transform.DOLocalMoveY(-0.37f, 0f).OnComplete(delegate {
            transform.DOLocalMoveY(0, 2f);
            transform.GetComponent<CanvasGroup>().DOFade(1, 2f);
        });
    }

    public void ChangesBG(int i)
    {
        refs.sprite = sprites[i];

    }
    public void DoAct(bool stat)
    {
        ScoringManager scoringManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoringManager>();
        scoringManager.DecisionMaking(stat);
        //if (answ == true)
        //{
        //    scoringManager.DecisionMaking(true);
        //}
        //else
        //{
        //    scoringManager.DecisionMaking(false);

        //}
        foreach (BoxCollider box in boxCollider)
        {
            box.enabled = false;
        }
    }
    public void StartAnimation() {
        images[0].transform.DOKill();
        images[1].transform.DOKill();
        float durations = .8f;
        images[0].transform.DOScale(0, 0);
        images[1].transform.DOScale(0, 0).OnComplete(delegate {
            images[0].transform.DOScale(1, durations).OnComplete(delegate {
                images[1].transform.DOScale(1, durations).OnComplete(delegate {


                });

            });

        });
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Music3Manager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public List<BoxCollider> boxCollider;
    public bool blinkAnimation;
    public List<Sprite> sprites;
    public Image refs;
    public ScoringManager scoringManager;
    public bool isM3;
    // Start is called before the first frame update
    void Start()
    {
        foreach (BoxCollider box in boxCollider) {
            box.enabled = false;
        }
        if (blinkAnimation) {
            //GetComponent<Image>().DOFade(0, 0);
            transform.GetComponent<CanvasGroup>().DOFade(0, 0f);

            DoBlink();
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound() {
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
    public void DoBlink() {
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

    public void ChangesBG(int i) {
        refs.sprite = sprites[i];
    
    }
    public void ScoreM2(bool answ)
    {
        if (answ == true)
        {
            scoringManager.DecisionMaking(true);
        }
        else
        {
            scoringManager.DecisionMaking(false);

        }

    }

}

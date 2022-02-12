using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music1Manager : MonoBehaviour
{
    public Button StartButton;
    public List<Animator> animators;
    public Animator animatorSq;
    public AudioSource source;
    public AudioClip clip;
    public int score;
    public Text scoreText;
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
        //foreach (Animator animator1 in animators) {
        //    animator1.SetTrigger("Start");
        //}
    }
    public void AddPoint() {
        score += 5;
        scoreText.text = score.ToString();
    }
}

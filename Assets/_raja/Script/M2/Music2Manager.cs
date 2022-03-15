using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Music2Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image imageQuestion;
    public List<Sprite> listQuestion;
    public Sprite questionDefault;
    public int curIndex;
    public float delay;
    public Image imageResult;
    public Button btnStart;
    public CanvasGroup canvasAnswer;
    public AudioSource source;
    public bool isAnswer;
    [SerializeField] public AudioClip clip;
    public bool allowPlay;
    public bool playAudios;
    public ScoringManager scoringManager;
    void Start()
    {
        Color colors = Color.white;
        colors.a = 0f;
        //imageResult.color = colors;
        btnStart.gameObject.SetActive(true);
        //canvasAnswer.interactable = false;
        imageQuestion.sprite = questionDefault;

        if (playAudios == false) {
            btnStart.gameObject.SetActive(false);
            //PlayBTN();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PrepareCall() {
        if (playAudios)
        {
            if (isAnswer == false)
            {
                imageQuestion.sprite = questionDefault;
                Debug.Log(imageQuestion.sprite.name);
                btnStart.gameObject.SetActive(true);
                canvasAnswer.interactable = false;
            }
            else
            {


            }
        }

        else {
            if (isAnswer == false)
            {
                //imageQuestion.sprite = questionDefault;
                Debug.Log(imageQuestion.sprite.name);
                canvasAnswer.interactable = true;
            }
            else
            {


            }

        }
    }


    public void PlayBTN()
    {
        //Invoke("PlayQuestion", 0);
        //string pathss = Path.Combine(Application.streamingAssetsPath, "m2.ogg");
        //StartCoroutine(PlayAudioClip(source, pathss));
        btnStart.gameObject.SetActive(false);
        if (isAnswer == false) {
            canvasAnswer.interactable = true;

        }
        if (playAudios == false) {
            curIndex = listQuestion.Count-1;
        }
        PlayQuestion();

    }
    public static IEnumerator PlayAudioClip(AudioSource audioSource, string path)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.UNKNOWN))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = myClip;
                audioSource.Play();
                
            }
            //source.clip = audioSource;
            //AudioClip
            //source.Play();
            
        }
       
    }
    public void PlayQuestion() {
        //source.Play();

        if (playAudios) {
            source.clip = clip;
            source.Play();
        }
        
        allowPlay = true;

        StartCoroutine("PlayQuestionSequence");
        
        if (playAudios) {
            Invoke("StopAllow", 19f);
        }
        
    }
    public void StopQuestion()
    {
        if (playAudios == true)
        {
            CancelInvoke("StopAllow");
            StopCoroutine("PlayQuestionSequence");
            if (isAnswer == false)
            {
                Debug.Log("ssss");

                imageQuestion.sprite = questionDefault;
                Debug.Log(imageQuestion.sprite.name);
                btnStart.gameObject.SetActive(true);
                canvasAnswer.interactable = false;
            }

            if (playAudios)
            {
                source.Stop();
                Debug.Log("dddd");

            }

            
        }
        else { 
        
        
        }
    }

    public void StopAllow() {
        allowPlay = false;
    }


    public IEnumerator PlayQuestionSequence() {
        //Debug.Log("start");
        //if (allowPlay == true && source.isPlaying == true)
        //{
        //    int rands = Randoms(curIndex);
        //    curIndex = rands;
        //    if (curIndex >= listQuestion.Count)
        //    {
        //        curIndex = 0;
        //    }

        //    imageQuestion.sprite = listQuestion[rands];
        //    //curIndex++;
        //    Debug.Log(rands);
        //    yield return new WaitForSeconds(delay);
        //    StartCoroutine("PlayQuestionSequence");
        //}
        //else if(allowPlay == false && source.isPlaying == true) { 
        //    imageQuestion.sprite = questionDefault;
        //    //btnStart.gameObject.SetActive(true);
        //    Invoke("CountingTrue", 1.5f);

        //}
        if (playAudios)
        {
            if (allowPlay == true && source.isPlaying == true)
            {
                int rands = Randoms(curIndex);
                curIndex = rands;
                if (curIndex >= listQuestion.Count)
                {
                    curIndex = 0;
                }

                imageQuestion.sprite = listQuestion[rands];

                //curIndex++;
                Debug.Log(imageQuestion.sprite.name);
                yield return new WaitForSeconds(delay);
                StartCoroutine("PlayQuestionSequence");
            }
            else if (allowPlay == false && source.isPlaying == true)
            {
                imageQuestion.sprite = questionDefault;
                //btnStart.gameObject.SetActive(true);
                Invoke("CountingTrue", 1.5f);

            }
        }
        else {
            int rands = Randoms(curIndex);
            curIndex = rands;
            if (curIndex >= listQuestion.Count)
            {
                curIndex = 0;
            }

            imageQuestion.sprite = listQuestion[rands];
            //curIndex++;
            Debug.Log(rands);
            yield return new WaitForSeconds(delay);
            StartCoroutine("PlayQuestionSequence");

            if (allowPlay == true)
            {
                
            }
            else if (allowPlay == false && source.isPlaying == true)
            {
                imageQuestion.sprite = questionDefault;
                //btnStart.gameObject.SetActive(true);
                Invoke("CountingTrue", 1.5f);

            }
        }
    }
    public void EndSeq()
    {
        ApiManagerR managerR = GameObject.FindGameObjectWithTag("UrlManager").GetComponent<ApiManagerR>();
        managerR.DirectLink();

    }
    public void CountingTrue() { 
            btnStart.gameObject.SetActive(true);

    }
    public int Randoms(int curidx) {
        int storeValue;
        //int rands = Random.Range(0, listQuestion.Count);
        //int rands = 0;
        //if (curidx == rands)
        //{
        //    storeValue = Randoms(curidx);
        //}
        //else {
        //    storeValue = rands;
        //}
        curidx++;
        if (curidx >= listQuestion.Count) {
            curidx = 0;
        }
        storeValue = curidx;
        return storeValue;
    }


    public void QuestionAnswer(int i) {
        if (i == 3)
        {
            Debug.Log("true");
            Color colors = Color.green;
            colors.a = 1f;
            scoringManager.DecisionMaking(true);
            //imageResult.color = colors;
        }
        else {
            Debug.Log("false");
            Color colors = Color.red;
            colors.a = 1f;
            scoringManager.DecisionMaking(false);

            //imageResult.color = colors;

        }
        isAnswer = true;
        canvasAnswer.interactable = false;
        StopQuestion();
        //EndSeq();
    }


}

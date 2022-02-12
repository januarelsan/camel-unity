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
    void Start()
    {
        Color colors = Color.white;
        colors.a = 0f;
        imageResult.color = colors;
        btnStart.gameObject.SetActive(true);
        canvasAnswer.interactable = false;
        imageQuestion.sprite = questionDefault;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        source.clip = clip;
        source.Play();
            StartCoroutine("PlayQuestionSequence");
    }
    public void StopQuestion()
    {
        if (isAnswer == false)
        {
            imageQuestion.sprite = questionDefault;
            btnStart.gameObject.SetActive(true);
            canvasAnswer.interactable = false;

        }
        source.Stop();
        StopCoroutine("PlayQuestionSequence");
    }

    public IEnumerator PlayQuestionSequence() {
        if (curIndex >= listQuestion.Count) {
            curIndex = 0;
        }
        imageQuestion.sprite = listQuestion[curIndex];
        curIndex++;
        yield return new WaitForSeconds(delay);
        StartCoroutine("PlayQuestionSequence");
    }

    public void QuestionAnswer(int i) {
        if (i == 3)
        {
            Debug.Log("true");
            Color colors = Color.green;
            colors.a = 1f;
            imageResult.color = colors;
        }
        else {
            Debug.Log("true");
            Color colors = Color.red;
            colors.a = 1f;
            imageResult.color = colors;

        }
        isAnswer = true;
        canvasAnswer.interactable = false;
        StopQuestion();

    }


}

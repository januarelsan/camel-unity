using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Art2QManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> questionList;
    public Image question;

    public void Start()
    {
        DoRandoms();
    }

    public void DoRandoms() {
        int randoms = Random.Range(0, questionList.Count);
        question.sprite = questionList[randoms];
    }
}

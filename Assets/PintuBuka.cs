using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuBuka : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Animator anim;
    [SerializeField] CameraDetection objDetection;
    [SerializeField] Material pintuAnjing;
    [SerializeField] Texture2D pintuKebukaBangsat;
    bool isEnable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objDetection.isFinish)
        {
            isEnable = true;
        }
    }
    public void OnMouseDown()
    {
        if (isEnable)
        {
            pintuAnjing.mainTexture = pintuKebukaBangsat;
            anim.SetTrigger("pintu");
            door.SetActive(true);
        }
            //m_Mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            //SceneManager.LoadScene("lobby");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuBuka : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Animator anim;
    [SerializeField] CameraDetection objDetection;
    [SerializeField] Material doorMat;
    [SerializeField] Texture2D doorTex;
    bool isEnable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            doorMat.mainTexture = doorTex;
            anim.SetTrigger("pintu");
            door.SetActive(true);
            LinkItemController.Instance.CallGetLinkAPI("20");

        }
            //m_Mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            //SceneManager.LoadScene("lobby");
    }
}

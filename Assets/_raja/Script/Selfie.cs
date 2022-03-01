using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zappar;
using DG.Tweening;

public class Selfie : MonoBehaviour
{
    public ZapparCameraBackground zapparCameraBG;
    public GameObject zapparCamera;
    public Image result;
    public Image result2;
    public Image framesBox;
    public Texture texturess;
    public CanvasGroup permissionPanel;
    public CanvasGroup capturingPanel;
    public CanvasGroup resultPanel;
    public CanvasGroup lastResultPanel;
    public Image splash;
    public Image camResult;
    public List<Sprite> frames;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("GetTex", 5);
        permissionPanel.alpha = 1;
        permissionPanel.interactable = true;
        permissionPanel.blocksRaycasts = true;

        capturingPanel.alpha = 0;
        capturingPanel.interactable = false;
        capturingPanel.blocksRaycasts = false;
        resultPanel.alpha = 0;
        resultPanel.interactable = false;
        resultPanel.blocksRaycasts = false;

        lastResultPanel.alpha = 0;
        lastResultPanel.interactable = false;
        lastResultPanel.blocksRaycasts = false;
        //capturingPanel.alpha = 1;
        //capturingPanel.interactable = true;
        //capturingPanel.blocksRaycasts = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenCameras() {
        permissionPanel.interactable = false;
        permissionPanel.blocksRaycasts = false;
        permissionPanel.DOFade(0, .5f).OnComplete(delegate {
            capturingPanel.DOFade(1, .5f).OnComplete(delegate {
                capturingPanel.interactable = true;
                capturingPanel.blocksRaycasts = true;
            });

        });


    }

    public void GetTex() {
        splash.DOFade(1, .1f).OnComplete(delegate {

            splash.DOFade(1, .2f).OnComplete(delegate {
                splash.DOFade(0, .1f).OnComplete(delegate {

                });
            });
        });
        //Texture texs = zapparCamera.GetCameraTexture;
        Texture2D tex =  zapparCameraBG.GetCameraTexture;
        Texture2D tex2D = new Texture2D(tex.width,tex.height);
        Texture2D tex2D2 = new Texture2D(tex.width,tex.height, TextureFormat.Alpha8 ,true);
        tex2D = tex;
        tex2D2 = tex;
        
        //tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        //tex.Apply();
        // Encode texture into PNG
        //var bytes = tex2D.EncodeToPNG();
        Sprite sprite = Sprite.Create(tex2D, new Rect(0, 0, tex2D.width, tex2D.height), new Vector2(tex2D.width / 2, tex2D.height / 2));

        Sprite spriteGS = Sprite.Create(tex2D2, new Rect(0, 0, tex2D2.width, tex2D2.height), new Vector2(tex2D2.width / 2, tex2D2.height / 2));
        
        zapparCamera.GetComponent<ZapparCamera>().ToggleActiveCamera(true);
        result.sprite = sprite;
        result2.sprite = spriteGS;
        camResult.sprite = spriteGS;
        //result.preserveAspect = true;
        capturingPanel.interactable = false;
        capturingPanel.blocksRaycasts = false;
        result.transform.DOLocalRotate(new Vector3(0,0,190), 0);
        result.transform.DOLocalRotate(new Vector3(0,0, 180), .5f);
        capturingPanel.DOFade(0, .5f).SetDelay(.2f).OnComplete(delegate {

        });
        resultPanel.DOFade(1, 0).SetDelay(.2f).OnComplete(delegate {
            resultPanel.interactable = true;
            resultPanel.blocksRaycasts = true;
        });
    }
    public void Retakes() {
        zapparCamera.GetComponent<ZapparCamera>().ToggleActiveCamera(false);

        result.sprite = null;
        resultPanel.interactable = false;
        resultPanel.blocksRaycasts = false;

        resultPanel.DOFade(0, .5f).OnComplete(delegate {

        });
        capturingPanel.DOFade(1, 0).OnComplete(delegate {
            capturingPanel.interactable = true;
            capturingPanel.blocksRaycasts = true;
        });

    }

    public void next()
    {
        resultPanel.interactable = false;
        resultPanel.blocksRaycasts = false;
        int rands = Random.Range(0, frames.Count);
        framesBox.sprite = frames[rands];
        resultPanel.DOFade(0, .5f).OnComplete(delegate {


        });
        lastResultPanel.DOFade(1, .5f).OnComplete(delegate {
            lastResultPanel.interactable = true;
            lastResultPanel.blocksRaycasts = true;
        });
        //Application.OpenURL("https://ihzv.zappar.io/3941965431407901021/1.0.HOF.21/");
    }
}

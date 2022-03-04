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
    public Camera extraCam;
    public Texture2D camResult2;


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
        //Invoke("Preparations", 1);
        //Debug.Log(zapparCameraBG.)
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
            Preparations();
        });


    }

    public void GetTex() {
        splash.DOFade(1, .1f).OnComplete(delegate {

            splash.DOFade(1, .2f).OnComplete(delegate {
                splash.DOFade(0, .1f).OnComplete(delegate {

                });
            });
        });

        //---
        //Texture2D tex =  zapparCameraBG.GetCameraTexture;
        //Texture2D tex2D = new Texture2D(tex.width,tex.height);
        //Texture2D tex2D2 = new Texture2D(tex.width,tex.height, TextureFormat.Alpha8 ,true);
        //tex2D = tex;
        //tex2D2 = tex;

        RTImage();
        Texture2D tex2D = camResult2;
        Sprite sprite = Sprite.Create(tex2D, new Rect(0, 0, tex2D.width, tex2D.height), new Vector2(tex2D.width / 2, tex2D.height / 2));

        //Sprite spriteGS = Sprite.Create(tex2D2, new Rect(0, 0, tex2D2.width, tex2D2.height), new Vector2(tex2D2.width / 2, tex2D2.height / 2));

        zapparCamera.GetComponent<ZapparCamera>().ToggleActiveCamera(true);
        
        result.sprite = sprite;
        result2.sprite = sprite;
        //camResult.sprite = spriteGS;

        //RTImage(tex2D2.width, tex2D2.height);
        
        //result.preserveAspect = true;
        //---

        capturingPanel.interactable = false;
        capturingPanel.blocksRaycasts = false;
        result.transform.DOLocalRotate(new Vector3(0,0,-10f), 0);
        result.transform.DOLocalRotate(new Vector3(0,0, 0), .5f);
        capturingPanel.DOFade(0, .5f).SetDelay(.2f).OnComplete(delegate {

        });
        resultPanel.DOFade(1, 0).SetDelay(.2f).OnComplete(delegate {
            resultPanel.interactable = true;
            resultPanel.blocksRaycasts = true;
        });
    }

    public void Preparations() {
        Texture2D tex = zapparCameraBG.GetCameraTexture;

        Texture2D tex2D = new Texture2D(tex.width, tex.height);
        Texture2D tex2D2 = new Texture2D(tex.width, tex.height, TextureFormat.Alpha8, true);
        tex2D = tex;
        tex2D2 = tex;

        Sprite sprite = Sprite.Create(tex2D, new Rect(0, 0, tex2D.width, tex2D.height), new Vector2(tex2D.width / 2, tex2D.height / 2));
        Sprite spriteGS = Sprite.Create(tex2D2, new Rect(0, 0, tex2D2.width, tex2D2.height), new Vector2(tex2D2.width / 2, tex2D2.height / 2));
        Debug.Log(tex.width);
        Debug.Log(tex.height);
        zapparCamera.GetComponent<ZapparCamera>().ToggleActiveCamera(false);
        //result.sprite = sprite;
        //result2.sprite = spriteGS;
        camResult.rectTransform.sizeDelta = new Vector2(Screen.height, Screen.height);
        camResult.sprite = spriteGS;

        //RTImage(tex2D2.width, tex2D2.height);
        //result.preserveAspect = true;

    }
    private Texture2D RTImage()
    {
        int x = Screen.width;
        int y = Screen.height;
        Rect rect = new Rect(0, 0, x, y);
        RenderTexture renderTexture = new RenderTexture(x, y, 24);
        Texture2D screenShot = new Texture2D(x, y, TextureFormat.RGBA32, false);

        extraCam.targetTexture = renderTexture;
        extraCam.Render();

        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();

        extraCam.targetTexture = null;
        RenderTexture.active = null;


        Destroy(renderTexture);
        renderTexture = null;
        camResult2 = screenShot;
        return screenShot;
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
    public void Testing() {
        //zapparCameraBG.

    }
}

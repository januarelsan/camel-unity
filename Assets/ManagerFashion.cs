using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zappar;

public class ManagerFashion : MonoBehaviour
{
    [Header("atrribute photo")]
    [SerializeField] GameObject objPhoto;
    [SerializeField] GameObject objMarker;
    [SerializeField] GameObject objPhotoIcon;

    [SerializeField] RawImage imageCapture;
    [SerializeField] GameObject objFace;
    // Start is called before the first frame update
    void Start()
    {
        if (!StaticData.frontCamera)
        {
            objFace.SetActive(false);
            objPhotoIcon.SetActive(false);
            imageCapture.texture = StaticData.textureFace;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void caputureWajah()
    {
        StartCoroutine(getImageCapture());
    }

    IEnumerator getImageCapture()
    {
        objMarker.SetActive(false);
        objPhotoIcon.SetActive(false);
        yield return new WaitForEndOfFrame();
        //Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
        //Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);

        ss.ReadPixels(rect, 0, 0);
        ss.Apply();
        //textureImage = ss;
        imageCapture.texture = ss;
        StaticData.textureFace = ss;
        //objPhoto.SetActive(true);
        ZapparCamera.switchCamera();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] GameObject cameraRotation;
    [SerializeField] Text txtCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtCamera.text = "Camera rotation: " + cameraRotation.transform.rotation.ToString();


    }
}

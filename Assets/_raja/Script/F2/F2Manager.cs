using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoAct()
    {
        Debug.Log("linked2");
        ApiManagerR apiManagerR;
        apiManagerR = GameObject.FindGameObjectWithTag("UrlManager").GetComponent<ApiManagerR>();
        apiManagerR.DirectLinkparam();

    }
}

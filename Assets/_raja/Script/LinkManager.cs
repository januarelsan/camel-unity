using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkManager : MonoBehaviour
{
    public string url;
    // Start is called before the first frame update
    public bool isNeedForce;

    private void OnEnable()
    {
        if (isNeedForce)
        {
            DirectLink();
        }
    }

    void Start()
    {
        //if (isNeedForce) {
        //    DirectLink();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DirectLink() {
        Application.OpenURL(url);
    
    }
}

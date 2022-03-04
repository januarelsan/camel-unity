using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Web;
using System.Runtime.InteropServices;

public class URLGetter : Singleton<URLGetter>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public string GetFullURL(){
        return Application.absoluteURL;        
    }

    public string GetParam(string name){
        string url =  Application.absoluteURL;
        
        Uri myUri = new Uri(url);
        string value = HttpUtility.ParseQueryString(myUri.Query).Get(name);
        return value;
    }
}

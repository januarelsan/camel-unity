using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleHTTP;
using System.Runtime.InteropServices;

public class URLOpener : Singleton<URLOpener>
{
    [DllImport("__Internal")]
    private static extern void OpenURL(string url);
    // Start is called before the first frame update
    public void _OpenURL(string url){
        
        OpenURL(url);
    }
}

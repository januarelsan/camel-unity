using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiManagerR : MonoBehaviour
{
    // Start is called before the first frame update
    public string gameID;
    public string url = "januarelsan.com/api/link/get/";
    public int score;
    public float time;
    public Param param;
    void Start()
    {
        url = "januarelsan.com/api/link/get/";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DirectLink() { }
    
    public void DirectLinkparam() {
        StartCoroutine("GetLink");



        //Application.OpenURL(url);
    
    }
    public IEnumerator GetLink() {
        url = "januarelsan.com/api/link/get/";
        string uri = url + gameID;
        Debug.Log(uri);
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            Debug.Log(webRequest.downloadHandler);

            //string[] pages = uri.Split('/');
            //int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    //Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    //Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    Debug.Log(webRequest.downloadHandler.text);
                    
                    string newJson = webRequest.downloadHandler.text;
                    Param param1 = JsonUtility.FromJson<Param>(newJson);
                    param = param1;
                    Application.OpenURL(param.link_item.value);
                    break;
            }
        }

    }

}
//Received: { "status":"success","message":"Get Link","link_item":{ "id":2,"name":"Art Pilar 2","value":"https:\/\/ihzv.zappar.io\/3941965431407901021\/1.0.Art2.8\/"} }
[System.Serializable]
public class Param {
    public string status;
    public string message;
    public Link_Item link_item;
}
[System.Serializable]
public class Link_Item
{
    public int id;
    public string name;
    public string value;

}
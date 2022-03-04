using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ApiManagerR : MonoBehaviour
{
    // Start is called before the first frame update
    public string gameID;
    public string url = "januarelsan.com/api/link/get/";
    public int score;
    public float time;
    public Param param;
    public Text textResult;
    public string id;
    public string lobbyCode;

    void Start()
    {
        url = "januarelsan.com/api/link/get/";
    }

    // Update is called once per frame
    public void WaitID()
    {
        if (textResult != null)
        {
            textResult.text = id;
        }
    }
    public void DirectLink() {
        StartGame();

    }

    public void DirectLinkparam() {
        if (textResult != null) {
            textResult.text = "";
        }

        //StartCoroutine("GetLink");
        StartGame();


        //Application.OpenURL(url);

    }
    public void StartGame()
    {
        // SceneManager.LoadScene("New Scene");
         List<string> parameters = new List<string>();                                 
        parameters.Add(gameID);
        LinkItemController.Instance.CallGetLinkAPI(parameters);
        
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
            if (textResult != null) {
                textResult.text = webRequest.downloadHandler.ToString();
            }
            

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
                    //Application.OpenURL(param.link_item.value/*+"lobbycode, gamecode, user"*/);
                    Application.ExternalEval("window.open(\""+ param.link_item.value + "\",\"_blank\")");

                    /*https://ihzv.zappar.io/3941965431407901021/1.0.Music3.3?lobbycode=xxxx&gamecode=1&identitynumber=1234567892134567*/
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
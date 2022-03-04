using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleHTTP;
using System.Runtime.InteropServices;

public class LinkItemController : Singleton<LinkItemController>
{
    [DllImport("__Internal")]
    private static extern void OpenURL(string url);

    private string lobbyCode;
    private string identity_no;
    public void CallGetLinkAPI(List<string> parameters)
    {
        lobbyCode = parameters[1];
        identity_no = parameters[2];

        List<string> _parameters = new List<string>();       
        _parameters.Add(parameters[0]);

        APIController.Instance.Get("link/get", CallGetLinkAPIResponse, _parameters);
        
    }

    void CallGetLinkAPIResponse(Client http)
    {

        if (http.IsSuccessful())
        {
            Response resp = http.Response();

            if (resp.IsOK())
            {

                Debug.Log(resp.ToString());

                GeneralResponse generalResponse = JsonUtility.FromJson<GeneralResponse>(resp.ToString());


                if (generalResponse.status == "success")
                {
                    LinkItem link = generalResponse.link_item;                    
                    Debug.Log(link.value);

                     

                    string url = link.value + "?" + "lobbyCode=" + lobbyCode + "&" + "identity_no=" + identity_no ;
                    Debug.Log(url);

                    OpenURL(url);

                }
                else
                {
                    MessageController.Instance.ShowMessage(generalResponse.message);
                }

            }
            else
            {
                Debug.Log(resp.ToString());
            }

        }
        else
        {
            Debug.Log("error: " + http.Error());
            MessageController.Instance.ShowMessage("Something Error, Please Try Again!");
        }
    }
}

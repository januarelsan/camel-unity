using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleHTTP;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;


public class LobbyHomeController : MonoBehaviour
{
    [SerializeField] private Text lobbyNameText;
    [SerializeField] private Text[] userNameTexts;        

    private Lobby lobby;

    private string lobbyCode;
    private string identity_no;

    void Start(){
        InvokeRepeating("CallLobbyJoinedUserListAPI",2,5);
    }

    public void Setup(Lobby lobby){
        
        this.lobby = lobby;

        lobbyNameText.text = lobby.name + " - " + lobby.code;

        for (int i = 0; i < userNameTexts.Length; i++)
        {
            if(i < lobby.joined_identities.Length){
                userNameTexts[i].text = lobby.joined_identities[i].fullname;
            } else {
                userNameTexts[i].text = "Empty";
            }
        }
    }

    

    public void StartGame(){                
        // Debug.Log("Start: " + PlayerPrefController.Instance.GetLobbyCode());
        CallLobbyStartAPI(PlayerPrefController.Instance.GetLobbyCode());
    }    

    public void CallLobbyStartAPI(string lobbyCode){

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        
        parameters.Add("code", lobbyCode);
        parameters.Add("identity_no", PlayerPrefController.Instance.GetIdentityNumber());
        
        APIController.Instance.PostWithFormData("lobby/start",CallLobbyStartAPIResponse, parameters);

    }

    void CallLobbyStartAPIResponse(Client http)
    {
        
        if (http.IsSuccessful ()) {
			Response resp = http.Response ();

            if(resp.IsOK()){
                
                GeneralResponse generalResponse = JsonUtility.FromJson<GeneralResponse>(resp.ToString());

                if(generalResponse.status == "pending"){
                    MessageController.Instance.ShowMessage("Lobby Not Started Yet!");
                } else {       
                    List<string> parameter_id = new List<string>();                                 
                    parameter_id.Add("19");

                    lobbyCode = generalResponse.lobby.code;
                    identity_no = PlayerPrefController.Instance.GetIdentityNumber();                                        

                    APIController.Instance.Get("link/get", CallGetLinkAPIResponse, parameter_id);
                }
                
            } else {
                Debug.Log(resp.ToString());
            }

		} else {
			Debug.Log("error: " + http.Error());
            MessageController.Instance.ShowMessage("Something Error, Please Try Again!");
		}
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

                    URLOpener.Instance._OpenURL(url);

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

    public void CallLobbyJoinedUserListAPI(){
        List<string> parameters = new List<string>(){lobby.code};
        APIController.Instance.Get("lobby/joinedUserList", CallLobbyJoinedUserListAPIResponse, parameters);        
    }

    void CallLobbyJoinedUserListAPIResponse(Client http)
    {
        
        if (http.IsSuccessful ()) {
			Response resp = http.Response ();

            if(resp.IsOK()){

                string wrappedJSON = resp.WrapJSONArray("lobbies");
                            
                LobbyCollection lobbyCollection = JsonUtility.FromJson<LobbyCollection>(wrappedJSON);
                            
                foreach (Lobby lobby in lobbyCollection.lobbies)
                {
                    Setup(lobby);
                }  
                
            } else {
                Debug.Log(resp.ToString());
            }

		} else {
			Debug.Log("error: " + http.Error());
            MessageController.Instance.ShowMessage("Something Error, Please Try Again!");
		}
    }

    public void CallLobbyLeaveAPI(){
        List<string> parameters = new List<string>(){lobby.code,PlayerPrefController.Instance.GetIdentityNumber()};
        APIController.Instance.Get("lobby/leave", CallLobbyLeaveAPIResponse, parameters);        
    }

    void CallLobbyLeaveAPIResponse(Client http)
    {
        
        if (http.IsSuccessful ()) {
			Response resp = http.Response ();

            if(resp.IsOK()){

                Debug.Log(resp.ToString());
                
            } else {
                Debug.Log(resp.ToString());
            }

		} else {
			Debug.Log("error: " + http.Error());
            MessageController.Instance.ShowMessage("Something Error, Please Try Again!");
		}
    }
}

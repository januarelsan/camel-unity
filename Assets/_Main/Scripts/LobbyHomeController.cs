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

    void Start(){
        InvokeRepeating("CallLobbyJoinedUserListAPI",2,5);
    }

    public void Setup(Lobby lobby){
        
        this.lobby = lobby;

        lobbyNameText.text = lobby.name;

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
        SceneManager.LoadScene("New Scene");
        // LinkItemController.Instance.CallGetLinkAPI("1");
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

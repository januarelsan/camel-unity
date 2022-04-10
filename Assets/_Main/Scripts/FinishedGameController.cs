using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleHTTP;

public class FinishedGameController : Singleton<FinishedGameController>
{

    [SerializeField] private GameObject gameFinishedUI;
    [SerializeField] private Text messageText;

    private string currentGameID;

    private bool allUserOnSameGame = true;

    string joinedLobbyId;

    void Start(){
        joinedLobbyId = PlayerPrefController.Instance.GetLobbyCode();
        // PlayerPrefController.Instance.SetLobbyCode("I1TNR");
        // PlayerPrefController.Instance.SetCurrentGameID(0);
        // CheckAllUserFinished();

        // SetupNextGame();
        // CheckAllUserFinished();
    }

    public void SetupNextGame(){
        int nextGameId = PlayerPrefController.Instance.GetCurrentGameID() + 1;
        PlayerPrefController.Instance.SetCurrentGameID(nextGameId);

        //Update on server
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("lobby_code", joinedLobbyId);        
        parameters.Add("finished_game_id", nextGameId.ToString());                
        parameters.Add("identity_no", PlayerPrefController.Instance.GetIdentityNumber());
        
        APIController.Instance.PostWithFormData("lobby/game/save/finished",CallLobbyGameSaveFinishedAPIResponse, parameters);
    }

    void CallLobbyGameSaveFinishedAPIResponse(Client http)
    {

    }

    public void CheckAllUserFinished(){
        currentGameID = PlayerPrefController.Instance.GetCurrentGameID().ToString();
        joinedLobbyId = PlayerPrefController.Instance.GetLobbyCode();
        Debug.Log(joinedLobbyId);
        List<string> parameters = new List<string>() { joinedLobbyId };
        APIController.Instance.Get("lobby/joinedUserList", CallLobbyJoinedUserListAPIResponse, parameters);   
    }
    
    void CallLobbyJoinedUserListAPIResponse(Client http)
    {
        allUserOnSameGame = true;
        if (http.IsSuccessful ()) {
			Response resp = http.Response ();

            if(resp.IsOK()){

                string wrappedJSON = resp.WrapJSONArray("lobbies");
                            
                LobbyCollection lobbyCollection = JsonUtility.FromJson<LobbyCollection>(wrappedJSON);

                string message =  "\r\n\r\n";

                foreach (Lobby lobby in lobbyCollection.lobbies)
                {
                    foreach (Identity identity in lobby.joined_identities)
                    {                        
                        
                        int userFinishedIdInt = int.Parse(identity.pivot.finished_game_id);
                        int currentGameIDInt = int.Parse(currentGameID);
                        
                        Debug.Log(userFinishedIdInt);
                        Debug.Log(currentGameIDInt);

                        if( userFinishedIdInt != currentGameIDInt){
                            allUserOnSameGame = false;
                            message += " - " + identity.fullname + "\r\n\r\n";
                            gameFinishedUI.SetActive(true);
                            messageText.text = message;
                        }
                    }
                } 

                if(GetAllUserOnSameGame()){
                    gameFinishedUI.SetActive(false);
                }
                
            } else {
                Debug.Log(resp.ToString());
            }

		} else {
			Debug.Log("error: " + http.Error());
            MessageController.Instance.ShowMessage("Something Error, Please Try Again!");
		}
    }

    public bool GetAllUserOnSameGame(){
        return allUserOnSameGame;
    }
}

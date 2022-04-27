using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleHTTP;

public class FinishedGameController : Singleton<FinishedGameController>
{

    [SerializeField] private GameObject gameFinishedUI;
    [SerializeField] private Text messageText;
    [SerializeField] private Text textRoomId;

    private string currentGameID;

    private bool allUserOnSameGame = true;

    string joinedLobbyId;

    public bool needCheckUser = true;

    void Start(){
        joinedLobbyId = PlayerPrefController.Instance.GetLobbyCode();
        // PlayerPrefController.Instance.SetLobbyCode("I1TNR");
        // PlayerPrefController.Instance.SetCurrentGameID(0);
        // CheckAllUserFinished();

        // SetupNextGame();
        // CheckAllUserFinished();
        textRoomId = messageText.transform.parent.GetChild(3).GetComponent<Text>();

    }

    public void SetupNextGameOnServer(){
        int nextGameId = PlayerPrefController.Instance.GetCurrentGameID();
        
        //Update on server
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("lobby_code", joinedLobbyId);        
        parameters.Add("finished_game_id", nextGameId.ToString());                
        parameters.Add("identity_no", PlayerPrefController.Instance.GetIdentityNumber());

        textRoomId.text = "ID Room: "+joinedLobbyId;

        APIController.Instance.PostWithFormData("lobby/game/save/finished",CallLobbyGameSaveFinishedAPIResponse, parameters);
    
    }
    public void SetupFirstGame()
    {
        int nextGameId = 0;
        PlayerPrefController.Instance.SetCurrentGameID(nextGameId);
    }

    void CallLobbyGameSaveFinishedAPIResponse(Client http)
    {
        if (http.IsSuccessful ()) {
			Response resp = http.Response ();

            if(resp.IsOK()){
                Debug.Log("Saved Game Finished Success");
                Debug.Log(resp.ToString());                
                
                
            } else {
                Debug.Log(resp.ToString());                
            }

		} else {
			Debug.Log("error: " + http.Error());
            MessageController.Instance.ShowMessage("Something Error, Please Try Again!");
		}
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
            Debug.Log(resp.ToString());
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
                    // do stop repeating
                    needCheckUser = false;
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

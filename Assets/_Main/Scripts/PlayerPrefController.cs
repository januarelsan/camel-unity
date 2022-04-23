using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefController : Singleton<PlayerPrefController>
{
    public void SetIdentityNumber(string value){
        PlayerPrefs.SetString("identity_no",value);
    }

    public string GetIdentityNumber(){
        return PlayerPrefs.GetString("identity_no");
    }

    public void SetLobbyCode(string value){
        PlayerPrefs.SetString("lobbyCode",value);
    }

    public string GetLobbyCode(){
        return PlayerPrefs.GetString("lobbyCode");
    }

    public void SetCurrentGameID(int index){
        PlayerPrefs.SetInt("currentGameID",index);
    }

    public int GetCurrentGameID(){
        return PlayerPrefs.GetInt("currentGameID",0);
    }

    public void SetStatusGame(int index)
    {
        PlayerPrefs.SetInt("isMultiplayer", index);
    }

    public int GetStatusGame()
    {
        return PlayerPrefs.GetInt("isMultiplayer", 0);
    }

    public void SetIsJoinAsOwner(int isOwning)
    {
        PlayerPrefs.SetInt("isJoinAsOwner", isOwning);
    }

    public int GetIsJoinAsOwner()
    {
        return PlayerPrefs.GetInt("isJoinAsOwner", 0);
    }

}

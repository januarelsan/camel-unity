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
}

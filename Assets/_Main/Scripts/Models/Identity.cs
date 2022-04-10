using System;

[Serializable]
public class Identity {
    
	public string id;
    public string identity_no;
    public string fullname;

    public Pivot pivot;
	   

}

[Serializable]
public class IdentityCollection {
	
    public Identity[] identities;	
	
}

[Serializable]
public class Pivot {
    
	public string lobby_id;
    public string identity_id;
    public string finished_game_id;
	   

}

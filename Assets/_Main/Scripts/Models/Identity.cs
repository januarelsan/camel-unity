using System;

[Serializable]
public class Identity {
    
	public string id;
    public string identity_no;
    public string fullname;
	   

}

[Serializable]
public class IdentityCollection {
	
    public Identity[] identities;	
	
}

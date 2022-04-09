using System;

[Serializable]
public class JoinedUserList {
    
	public Identity[] identities;
	   
}

[Serializable]
public class JoinedUserListCollection {
	
    public JoinedUserList[] joinedUserLists;	
	
}
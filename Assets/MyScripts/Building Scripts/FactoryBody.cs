using UnityEngine;
using System.Collections;

public class FactoryBody : FactoryPart{
	public PartNavigation.BodyType BodyType;
	
	// Use this for initialization
	void Start () {
		type = PartNavigation.BaseType.Body;
		tier2 = (int)type;
		tier3 = 0;
		Layers = 2;
		name = "Blahbl2ah";

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public PartNavigation.BodyType getType(){
		return BodyType;
	}

}

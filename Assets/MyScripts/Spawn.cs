using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public Squad squad;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		checkkeys();
	}
	
	void checkkeys(){
		if (Input.GetButtonDown("Jump")){
				GameObject Tank=(GameObject)PhotonNetwork.Instantiate ("Tank", new Vector3(-47,30,76), Quaternion.identity,0);
				//Tank.GetComponent<ClickToMove>().enabled = true;
				Tank.GetComponent<Unit>().enabled = true;
				Tank.GetComponent<TextLookAt>().enabled = true;
				Tank.GetComponent<AIPatherNew>().enabled = true;
				Tank.GetComponent<TextLookAtEnemy>().enabled = false;
				Tank.gameObject.tag= "Tank";
				squad.addToOwnedList(Tank);
				
		}
	}
}

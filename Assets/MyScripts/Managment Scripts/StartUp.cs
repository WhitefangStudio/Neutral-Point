using UnityEngine;
using System.Collections;

public class StartUp : MonoBehaviour {

	//public GameObject camera;


	
	// Use this for initialization
	void Start () {
		InvokeRepeating ("checkForPlayers", 0, 0.5f);
	}
	
	// Update is called once per frame
	void checkForPlayers() {
		GameObject[] cams = GameObject.FindGameObjectsWithTag ("MainCamera");
		foreach(GameObject cam in cams){
			if (!cam.GetPhotonView().owner.isLocal) {
				GlobalStats.stats.startGame();
				cam.SetActive(false);

				CancelInvoke();
			}
		}

	}
}

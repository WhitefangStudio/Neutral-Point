using UnityEngine;
using System.Collections;

public class SpawnFactory : MonoBehaviour {

	// Use this for initialization
	public GameObject Factory;
	
	GameObject[] factories;
	int currFact;
	Vector3 target;
	Camera cam;
	bool placing=false;
	int Player;
	
	void Start(){
		factories = new GameObject[6];
		Player = PhotonNetwork.player.ID;

	}

	public void place(int Position){
		if(placing==false){
			currFact=Position;
			if(cam==null){
				if (GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>() != null) {
					cam = GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>();
				}
			}
			StartFactoryCheck(Position);
		}
	}
	void Update () {
		if (placing == true) {
			RaycastHit hit;
			if (Physics.Raycast	(cam.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity)) {
				factories[currFact].transform.position= hit.point;
				factories[currFact].GetComponent<BuildingPosition>().SendUpdate();
			}
			if(Input.GetMouseButtonDown(0)){
				Debug.Log ("placed");
				placing = false;
				factories[currFact].GetComponent<MeshCollider>().enabled= (true);
				factories[currFact].GetComponent<BuildingPosition>().SendUpdate();
				factories[currFact].GetComponent<Factory>().enabled=true;
				factories[currFact].GetComponent<Factory>().player=this.Player;

				//currUsedFactories++;
			}
			if(Input.GetMouseButtonDown(1)){
				placing = false;
				GameObject.Destroy(factories[currFact]);
			}
		}


	/*	if (Input.GetKeyDown (KeyCode.A)) {
			if(placing==false){
				if(cam==null){
					if (GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>() != null) {
						cam = GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>();
					}
				}
				placing=true;
				StartFactoryCheck();
			}
		}*/
	}

	 void StartFactoryCheck(int Position){
		if (factories[Position]==null) {
			RaycastHit hit;
			if (Physics.Raycast	(cam.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity)) {
					target = hit.point;
			}
			factories[Position] = (GameObject)PhotonNetwork.Instantiate ("Factory", target, Quaternion.Euler(-90,0,0),0);
			factories[Position].GetComponent<MeshCollider>().enabled= (false);
			placing=true;

		}
	}
}

using UnityEngine;
using System.Collections;

public class SpawnFactory : MonoBehaviour {

	// Use this for initialization
	//public GameObject Factory;
	
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
			if (Physics.Raycast	(cam.ScreenPointToRay (Input.mousePosition), out hit,Mathf.Infinity)) {
				factories[currFact].transform.position= new Vector3(hit.point.x,hit.point.y+
				     ((factories[currFact].GetComponent<Renderer>().bounds.size.y)/1.7f),hit.point.z);
				factories[currFact].GetComponent<BuildingPosition>().SendUpdate();
			}
			if(Input.GetMouseButtonDown(0)){
				bool isBuildable=true;
				Renderer ren = factories[currFact].GetComponent<Renderer>();
				float x = (ren.bounds.size.x)/2;
				float z = (ren.bounds.size.z)/2;
				Vector3 center= ren.bounds.center;
				Vector3[] positions = new Vector3[4]{
					new Vector3(center.x+x,center.y,center.z+z),
					new Vector3(center.x-x,center.y,center.z+z),
					new Vector3(center.x-x,center.y,center.z-z),
					new Vector3(center.x+x,center.y,center.z-z)
				};

				RaycastHit[] hits= new RaycastHit[4];
				float avgDist=0;
				for (int i=0; i<4;i++){
					Physics.Raycast (positions[i],Vector3.down, out hits[i], Mathf.Infinity);
					avgDist+=hits[i].distance;
				}
				avgDist/=4;
				for (int i=0; i<4;i++){
					if(Mathf.Abs(avgDist-hits[i].distance)>5){
						isBuildable=false;
						ShowErrorMessage.SEM.displayError("Terrain Uneven");
					}
				}
				if(!(FactoryBoundingBox.FBBox.Box(Player).Contains(factories[currFact].transform.position))){
					isBuildable=false;
					ShowErrorMessage.SEM.displayError("Outside of Placement Area");
				}

					if(isBuildable){
					Debug.Log ("placed");
					placing = false;
					factories[currFact].GetComponent<BoxCollider>().enabled= (true);
					factories[currFact].GetComponent<BuildingPosition>().SendUpdate();
					factories[currFact].GetComponent<Factory>().enabled=true;
					factories[currFact].GetComponent<Factory>().player=this.Player;
					factories[currFact].GetComponent<Factory>().position=currFact;
					GameObject.Find("A* Path").GetComponent<AstarPath>().Scan();
				}

				//currUsedFactories++;
			}
			if(Input.GetMouseButtonDown(1)){
				placing = false;
				PhotonNetwork.Destroy(factories[currFact]);
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
			factories[Position].GetComponent<BoxCollider>().enabled= (false);
			placing=true;

		}
	}
}

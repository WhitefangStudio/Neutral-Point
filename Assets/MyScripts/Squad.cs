using UnityEngine;
using System.Collections;
using Pathfinding;
using System.Collections.Generic;

public class Squad : MonoBehaviour {
	
	Vector3 target;
	Path path;
	private Camera cam = null;
	List<GameObject> Units;
	
	
	// Use this for initialization
	void Start () {
		if (GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>() != null) {
			cam = GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>();
		}
		Units = new List<GameObject>();
		target = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		CheckMouse();
	}
	
	public void addToOwnedList(GameObject newUnit){
		Units.Add(newUnit);
	}
	
	void CheckMouse(){
		if (Input.GetMouseButtonUp (1)) {
			RaycastHit hit;
			if (Physics.Raycast	(cam.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity)) {
				if(target != hit.point){
					target = hit.point;
					if(Units.Count>0)
						MoveSquad ();
				}
			}
		}
	}
	
	void MoveSquad(){
		Vector3[] temp = new Vector3[Units.Count];
		for(int i=0; i<Units.Count;i++){
			if (Units[i].GetComponent<Unit>().selected==true){
				temp[i]= Units[i].transform.position;
			}
		}
		int j =0;
		bool finished=false;
		do {
			if(Units[j].GetComponent<Unit>().selected==true){
				finished = true;
				Units[j].GetComponent<Seeker>().StartMultiTargetPath(temp,target,true,callbacks,-1);
			}
			j++;
		}while(!finished);
	}
		void callbacks(Path p){
			MultiTargetPath mp = p as MultiTargetPath;
			List<Vector3>[] paths = mp.vectorPaths;
			for (int k=0; k<Units.Count; k++) {
				if (Units [k].GetComponent<Unit> ().selected == true) {
					Units[k].GetComponent<AIPatherNew>().takePath(paths[k]);
			}

		}
	}
}
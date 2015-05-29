using UnityEngine;
using System.Collections;
using Pathfinding;
using System.Collections.Generic;

public class Squad : MonoBehaviour {

	int team;
	Vector3 target;
	public Transform targetEnemy;
	Path path;
	private Camera cam = null;
	
	
	// Use this for initialization
	void Start () {
		if (GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>() != null) {
			cam = GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>();
		}
		target = new Vector3 (0, 0, 0);
		team =PhotonNetwork.player.ID;
	}
	
	// Update is called once per frame
	void Update () {
		CheckMouse();
	}
	
	void CheckMouse(){
		if (Input.GetMouseButtonUp (1)) {
			Debug.Log (PhotonNetwork.player.ID);
			if (Selected.selected.isMovable(0)) {
				RaycastHit hit;
				if (Physics.Raycast (cam.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity)) {
					if (hit.collider.GetComponentInParent<Unit>()!=null) {
						Debug.Log(hit.collider.transform.parent.GetComponent<Unit> ().player+" "+PhotonNetwork.player.ID+" "+hit.collider.transform.ToString());
							if (hit.collider.transform.parent.GetComponent<Unit> ().player != PhotonNetwork.player.ID) {
								targetEnemy = hit.collider.transform;
								for (int k=0; k<Selected.selected.Count(); k++) {
									Selected.selected.getAtPosition (k).GetComponent<Weapon> ().setTarget (hit.collider.transform);
								}
								Debug.Log ("attack " + hit.collider.transform.ToString ());
							}
					} else {
						for (int k=0; k<Selected.selected.Count(); k++) {
							Selected.selected.getAtPosition (k).GetComponent<Weapon> ().setTarget (null);
							Selected.selected.getAtPosition (k).GetComponent<UnitStats> ().stopped = false;
						}
					}
					if (target != hit.point) {
						target = hit.point;
						if (Selected.selected.Count () > 0)
							MoveSquad ();
					}
				}
			}
		}
	}
	
	void MoveSquad(){
		int Count =Selected.selected.Count();
		if (Selected.selected.Count()>0) {
			Vector3[] temp = new Vector3[Count];
			for (int i=0; i<Count; i++) {
				if (Selected.selected.isMovable(i)) {
					temp [i] = Selected.selected.getAtPosition(i).position;
				}
			}
			int j = 0;
			bool finished = false;
			do {
				if (Selected.selected.isMovable(j)) {
					finished = true;
					Selected.selected.getAtPosition(j).GetComponent<Seeker> ().StartMultiTargetPath (temp, target, true, callbacks, -1);
				}
				j++;
			} while(!finished&&j<Count);
		}
	}
		void callbacks(Path p){
			MultiTargetPath mp = p as MultiTargetPath;
			List<Vector3>[] paths = mp.vectorPaths;
			for (int k=0; k<Selected.selected.Count(); k++) {
			if (Selected.selected.getAtPosition(k).GetComponent<Unit> ()!=null) {
				Selected.selected.getAtPosition(k).GetComponent<AIPatherNew>().takePath(paths[k]);
			}

		}
	}
}
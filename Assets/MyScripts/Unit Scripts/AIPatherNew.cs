//sup ma niggaa
//blahblah cuz why the fuck not
using UnityEngine;
using System.Collections;
using Pathfinding;
using Pathfinding.RVO;
using System.Collections.Generic;

public class AIPatherNew : MonoBehaviour {

	RVOController controller;
	Vector3 target;
	Seeker seeker;
	List<Vector3> path;
	int currentWaypoint;
	float dist;
	private Camera cam = null;
	bool move;
	public float moveSpeed = 30f; 
	public LayerMask mask;


	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>() != null) {
			cam = GameObject.Find ("Main Camera(Clone)").GetComponent<Camera>();
		}
		seeker = GetComponent<Seeker>();
		controller = GetComponent<RVOController>();

	}

	public void takePath(List<Vector3> p){
		path = p;
		currentWaypoint = 0;
		move = true;
	}

	public void newPath(Vector3 position){
		target = position;
		Invoke("spawnWaypoint",.5f);
	}
	void spawnWaypoint(){
		seeker.StartPath (transform.position, target, onComplete);
	}
	public void onComplete(Path p){
		path = p.vectorPath;
		currentWaypoint = 0;
		move = true;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (path == null) {
			return;
		}
		if(currentWaypoint >= path.Count){
			move = false;
		
		}
		
		if (move == true) {
			moveSpeed = 30;
			GetComponent<Rigidbody>().freezeRotation = false;
			rotate ();
			moveUnit ();
		} else if (move == false) {
			moveSpeed = 0;
			controller.Move (transform.forward * moveSpeed);
			GetComponent<Rigidbody>().freezeRotation = true;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			return;
		}
		dist= Vector3.Distance(transform.position,path[currentWaypoint]);
		if ((dist < 15)) {
			currentWaypoint++;
			moveSpeed = 0;
			
		}
	}
	void rotate(){
		Quaternion targetRotation = Quaternion.LookRotation (path[currentWaypoint]-transform.position);

		float rotX = transform.eulerAngles.x;
		if (rotX > 180) {
			rotX-=360;
		}

		rotX = Mathf.Clamp (rotX, -1, 1);
		float rotZ = transform.eulerAngles.z;

		if (rotZ > 180) {
			rotZ-=360;
		}
		rotZ = Mathf.Clamp (rotX, -2, 2);
		
		targetRotation =Quaternion.Euler(rotX,targetRotation.eulerAngles.y,rotZ);
		transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,1f);
	}



	void moveUnit(){		
		Vector3 towards =(path[currentWaypoint] - transform.position).normalized;
		if ((dist > 3)) {
			float i;

			//transform.position = Vector3.MoveTowards(transform.position, path.vectorPath[currentWaypoint], moveSpeed);
			controller.Move (transform.forward * moveSpeed);
		} else {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}

	public void stop(){
		Debug.Log ("binkus");
		move = false;
	}

}

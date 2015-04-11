using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	private Vector3 targetPosition;	
	private Camera cam= null;
	public float moveSpeed= 2.0f;
	public float dist;
	Vector3 towards;
	Quaternion targetRotation;
	public float reqAngle=10;
	public bool fall = true;
	bool exited=false;
	int move= 5;
	

	// Use this for initialization
	void Start () {
		targetPosition = transform.position;
		targetPosition.y = 0;
		if(GameObject.Find("Main Camera(Clone)").GetComponent<Camera>()!=null){
			cam = GameObject.Find("Main Camera(Clone)").GetComponent<Camera>();
		}
	
	}
	
	void FixedUpdate(){
		if(fall == false){
			dist = Vector3.Distance(transform.position,targetPosition);
			moveUnit();
		}
	}
	// Update is called once per frame
	void OnCollisionStay(){
	fall = false;
		if (cam != null){
			checkForClick();
	
		}
		if (cam == null){
			if(GameObject.Find("Main Camera(Clone)").GetComponent<Camera>()!=null){
				cam = GameObject.Find("Main Camera(Clone)").GetComponent<Camera>();
			}
		}
	}
	
	void OnCollisionExit()
	{
		exited = true;
		StartCoroutine(ConfirmEmpty());
	}
	IEnumerator ConfirmEmpty()
	{
		yield return new WaitForSeconds(.1f);
		if(exited==true)
			fall = true;
	}
	
	
	void Update () {

	}
	
	
	void checkForClick(){
		if(Input.GetMouseButton (1)){
			if(GetComponent<Unit>().selected==true){
				Plane playerPlane = new Plane(Vector3.up, transform.position);
				float hitDist =0.0f;
				Ray ray = new Ray();
				move = 5;
			
				ray = cam.ScreenPointToRay (Input.mousePosition);

			
				if(playerPlane.Raycast(ray,out hitDist)){
					Vector3 targetPoint = ray.GetPoint(hitDist);
					targetPosition = ray.GetPoint (hitDist);
					targetRotation = Quaternion.LookRotation (targetPoint - transform.position);
				}
				targetPosition.y=transform.position.y;

			}
		}	
	}
	
	void moveUnit(){
	
		transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,Time.deltaTime*10);
		towards = (targetPosition-transform.position).normalized;
		Quaternion yAxis = Quaternion.Euler(0,targetRotation.eulerAngles.y,0);
		Quaternion actualYAxis = Quaternion.Euler (0,transform.rotation.eulerAngles.y,0);
		
		
		if((dist>move)&&(Quaternion.Angle(yAxis, actualYAxis) <= reqAngle)){
				if(GetComponent<Rigidbody>().velocity.sqrMagnitude<500){
					GetComponent<Rigidbody>().AddForce (towards*1500*moveSpeed);
				}
		}else if ((dist<move)&&(Quaternion.Angle(yAxis, actualYAxis) <= reqAngle)){
			move = 100000;
			if(fall==false){
				GetComponent<Rigidbody>().velocity= Vector3.zero;
			}
		}else if ((dist>move)&&(Quaternion.Angle(yAxis, actualYAxis) >= reqAngle)){
			if(fall==false){
				GetComponent<Rigidbody>().velocity= Vector3.zero;
			}
		}
	}
}

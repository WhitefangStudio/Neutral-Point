using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour {
	
	public float rotateSpeed = 20.0f;
	public float angleMax = 30.0f;
	public Transform target;
	
	private Vector3 initialVector = Vector3.forward;
	
	// Use this for initialization
	void Start () {
		
		if(target != null)
		{
			initialVector = transform.position - target.position;
			initialVector.y = 0;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(target != null)
		{
			if (Input.GetMouseButton (0)){
				float rotateDegrees = 0f;
				rotateDegrees= Input.GetAxis("Mouse Y")*3;
				
				Vector3 currentVector = transform.position - target.position;
				currentVector.x = 0;
				float angleBetween = Vector3.Angle(initialVector, currentVector) * (Vector3.Cross(initialVector, currentVector).x > 0 ? 1 : -1);            
				float newAngle = Mathf.Clamp(angleBetween + rotateDegrees, 15f, 45f);
				rotateDegrees = newAngle - angleBetween;
				
				transform.RotateAround(target.position, transform.right, rotateDegrees);
			}
		}
		
	}
}
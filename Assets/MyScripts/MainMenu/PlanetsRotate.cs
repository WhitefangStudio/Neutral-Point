using UnityEngine;
using System.Collections;

public class PlanetsRotate : MonoBehaviour {
	public float radius;
	public Transform Sun;
	Vector3 rotate;
	public float speed;

	public bool isMoon;
	// Use this for initialization

	void OnEnable(){
		setup ();
	}
	public void setup(){
		if(Sun!=null){
		float scale = Random.Range (5, 15);
		//transform.localScale = new Vector3 (scale, scale, scale);
		float randX = Random.Range (-4*radius,4*radius);
		if (randX < 0) {
			randX-=1*radius;
		}
		if (randX >= 0) {
			randX+=1*radius;
		}
		float randY= Random.Range (-4*radius,4*radius);;

		if (randY < 0) {
			randY-=1*radius;
		}
		if (randY >= 0) {
			randY+=1*radius;
		}

		transform.position = new Vector3 (Sun.transform.position.x+randX, Sun.transform.position.y+Random.Range (-5*radius/10,5*radius/10),
		                                  Sun.transform.position.z+randY);


		if(!isMoon)
			speed = Mathf.Log (Vector3.Distance (Sun.position, transform.position));
		if (isMoon)
			speed = Mathf.Log (Vector3.Distance (Sun.position, transform.position))*6;

		}
	}
	// Update is called once per frame
	void Update () {
		if (Sun != null) {
			//Debug.Log (Vector3.Distance(Sun.position,transform.position));
			//Debug.Log (Vector3.Distance (transform.position,Sun.position));
			transform.RotateAround (Sun.position,Vector3.up,  speed * Time.deltaTime);

		}
	}
}

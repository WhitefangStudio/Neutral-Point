using UnityEngine;
using System.Collections;

public class TextLookAtEnemy : MonoBehaviour {
	Vector3 face;
	Transform text;
	Name cam;
	// Use this for initialization
	void Start () {
		text = transform.FindChild("Name");
		face = text.transform.localPosition;
		face.y-=10000;
		cam = GameObject.Find("Main Camera(Clone)").GetComponent<Camera>().GetComponent<Name>();
		Debug.Log (face.ToString());
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Quaternion targetRotation = Quaternion.LookRotation(face);
		text.transform.rotation = targetRotation;
		text.GetComponent<TextMesh>().text =  "Enemy";
		text.GetComponent<MeshRenderer> ().material.color = Color.red;
	}
	
	
	void changeName(){
		
	}
}


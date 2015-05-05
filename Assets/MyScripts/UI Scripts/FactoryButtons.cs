using UnityEngine;
using System.Collections;

public class FactoryButtons : MonoBehaviour {
	int position;
	Factory factoryScript;
	public GameObject factory;
	Squad squad;
	public static FactoryButtons FB;
	// Use this for initialization
	void Start () {
		FB = this;
		if (squad == null) {
			if(GameObject.Find ("Main Camera(Clone)")!=null){
				squad=GameObject.Find ("Main Camera(Clone)").GetComponent<Squad>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setPosition(GameObject Factory){
		factory = Factory;
		factoryScript = Factory.GetComponent<Factory> ();

	}

	public void spawn(){
		GameObject Tank=(GameObject)PhotonNetwork.Instantiate ("Tank", new Vector3(factory.transform.position.x+20,30,factory.transform.position.z), Quaternion.identity,0);
		//Tank.GetComponent<ClickToMove>().enabled = true;
		Tank.GetComponent<Unit>().enabled = true;
		Tank.GetComponent<AIPatherNew>().enabled = true;
		Tank.gameObject.tag= "Tank";
	}

	public void slot(int part,int pos){
		//Debug.Log (factory.ToString());
		//factory.GetComponent<Factory> ().setPosition (part, pos);
	}
}

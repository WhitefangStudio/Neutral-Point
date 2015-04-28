using UnityEngine;
using System.Collections;

public class FactoryBoundingBox : MonoBehaviour {
	public int player;
	public bool IsParent;
	public static FactoryBoundingBox FBBox;
	// Use this for initialization
	void Start () {
		if (IsParent) {
			FBBox=this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Bounds Box(int p){
		if (IsParent) {
			FactoryBoundingBox[] FBBs =GetComponentsInChildren<FactoryBoundingBox>();
			Debug.Log (FBBs.Length);
			foreach(FactoryBoundingBox f in FBBs){
				if(f.player==p){
					Debug.Log (p);
					return f.Box ();
				}else{

				}
			}
		}
		Debug.Log ("error, no Bounding Box Found for Player");
		return new Bounds(this.transform.position,new Vector3(0,0,0));

	}
	public Bounds Box(){
		Debug.Log ("BoundingBox sent");
		return GetComponent<BoxCollider> ().bounds;
	}
}

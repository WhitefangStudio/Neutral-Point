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
		Visible (false);
	}
	
	// Update is called once per frame
	void Update () {


	}
	public void Visible(bool vis){
		if (!IsParent) {
			if(vis==true){
				GetComponent<Renderer> ().material.SetColor ("_Color", new Color (1, 1, 1, .2f));
			}else{
				GetComponent<Renderer> ().material.SetColor ("_Color", new Color (1, 1, 1, 0));
			}
		}
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
		if (GetComponent<BoxCollider> () != null) {
			return GetComponent<BoxCollider> ().bounds;
		}
		Debug.Log ("error, no Bounding Box Found for Player");
		return new Bounds(this.transform.position,new Vector3(0,0,0));

	}

	public FactoryBoundingBox getBox(int p){
		if (IsParent) {
			for(int i =0;i<transform.childCount;i++){
				if(transform.GetChild(i).GetComponent<FactoryBoundingBox>().player==p){
					return transform.GetChild(i).GetComponent<FactoryBoundingBox>();
				}else{
					
				}
			}
		}
		return null;
		
	}
	public Bounds Box(){
		Debug.Log ("BoundingBox sent");
		return GetComponent<BoxCollider> ().bounds;
	}
}

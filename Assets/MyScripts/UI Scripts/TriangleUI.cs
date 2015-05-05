using UnityEngine;
using System.Collections;

public class TriangleUI : MonoBehaviour {
	public static TriangleUI TUI;
	public PopFromSide PFM;
	TriangleButtons[] TBs;


	// Use this for initialization
	void Start () {
		TUI = this;
		TBs = new TriangleButtons[transform.childCount];
		for (int i = 0; i<TBs.Length; i++) {
			TBs[i]=transform.GetChild (i).GetComponentInChildren<TriangleButtons>();
		}

	}

	public void setInfo(GameObject type){
		for (int i=0; i<TBs.Length; i++) {
			if (type.transform.GetChild(i)!=null){
				TBs[i].setObject (type.transform.GetChild (i).gameObject);
			}
		}
	}

	public void setInfo(GameObject type,int slotPosition){
		for (int i=0; i<TBs.Length; i++) {
			if (type.transform.GetChild(i)!=null){
				TBs[i].setObject (type.transform.GetChild (i).gameObject);
				TBs[i].setPos(slotPosition);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

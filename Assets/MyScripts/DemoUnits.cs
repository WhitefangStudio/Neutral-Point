using UnityEngine;
using System.Collections;

public class DemoUnits : MonoBehaviour {
	public Transform[] demoPlacement;
	private PartPrefs prefs;

	public GameObject demo(int pos, GameObject part){
		prefs = part.GetComponent<PartPrefs> ();
		if (prefs.isbody) {
			GameObject Base=Instantiate (part)as GameObject;
			Base.transform.parent=demoPlacement[pos];
			Base.transform.localPosition= new Vector3(0,0,0);
			Base.transform.localRotation= Quaternion.Euler(new Vector3(0,0,0));
			return Base;
		} else {
			return null;
		}
	}

	public void demo(GameObject basePart, GameObject part,int slotPosition){
		GameObject slot = Instantiate (part)as GameObject;
		slot.transform.parent = basePart.transform.GetChild (slotPosition);
		slot.transform.position = basePart.transform.GetChild (slotPosition).position;
		slot.transform.rotation=basePart.transform.GetChild(slotPosition).rotation;
		slot.transform.localScale = basePart.transform.GetChild (slotPosition).localScale;
		Debug.Log (basePart.name);
	}
	
}

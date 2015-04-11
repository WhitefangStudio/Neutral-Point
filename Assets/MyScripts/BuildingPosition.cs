using UnityEngine;
using System.Collections;

public class BuildingPosition : MonoBehaviour {

	public void SendUpdate () {
		this.gameObject.GetPhotonView ().RPC ("UpdateNetworkPosition", PhotonTargets.All, this.transform.position);
	}
	[RPC]
	public void UpdateNetworkPosition(Vector3 position){
		this.transform.position = position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

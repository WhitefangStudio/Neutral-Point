using UnityEngine;
using System.Collections;

public class NetworkMovement : MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;
	string otherName= "Name";
	TextMesh name;
	bool nameSent=false;
	// Use this for initialization
	void Start () {
		name = transform.FindChild("Name").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<PhotonView>().isMine){
			//Do nothing;
		}else{
			transform.position = Vector3.Lerp (transform.position, realPosition, 0.1f);
			transform.rotation = Quaternion.Lerp (transform.rotation, realRotation, 0.1f);
			name.text = otherName ;
		}
	
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
	
		if(stream.isWriting) {
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
				stream.SendNext (name.text);
		} else {
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
				otherName = (string)stream.ReceiveNext();
		}
	}	
}
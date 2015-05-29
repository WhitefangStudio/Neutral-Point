using UnityEngine;
using System.Collections;

public class UnitStats : MonoBehaviour {
	public float health;
	public float speed;
	public float size;
	public float stopRange;
	public Transform target;
	AIPatherNew pather;
	public bool stopped;
	// Use this for initialization
	void Start () {
		pather = GetComponent<AIPatherNew> ();
		stopped = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 0&&this.gameObject!=null) {
			Selected.selected.removeFromSelected(this.transform);
			PhotonNetwork.Destroy(this.gameObject);
		}
		if (target != null) {
			if (Vector3.Distance (this.transform.position, target.position) <= stopRange) {
				if (!stopped) {
					pather.stop ();
					stopped = true;
				}
			}
		}
	}
	void OnTriggerEnter(Collider c){
		if (c.transform.GetComponent<Bullet> () != null) {
			if (c.transform.GetComponent<Bullet> ().team != this.transform.GetComponent<Unit> ().player) {
				health -= c.transform.GetComponent<Bullet> ().getDamage ();
				PhotonNetwork.Destroy (c.gameObject);
			}
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if(stream.isWriting) {
			stream.SendNext (health);
		} else {
			health = (float)stream.ReceiveNext();
		}
	}
	public void setTarget(Transform target){
			this.target = target;
	}
}

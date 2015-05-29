using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public int team;
	float speed;
	float damage;
	Vector3 target;
	Vector3 towards;
	public int Force;
	float timer;
	// Use this for initialization
	void Start () {
		timer = 5;
	}
	void Update(){
		timer -= Time.deltaTime;
		if (timer <= 0) {
			PhotonNetwork.Destroy(this.gameObject);
		}
	}
	[RPC]
	public void init (Vector3 target, float damage){
		this.damage = damage;
		this.target = target;
		transform.rotation=Quaternion.LookRotation (target-transform.position);
		GetComponent<Rigidbody> ().AddForce (transform.forward*Force);
	}

	

	/*public void OnCollisionEnter(Collision c){
		if(c.gameObject.GetComponent<UnitStats>()!=null){
			c.gameObject.GetComponent<UnitStats>().decHealth(damage);
			PhotonNetwork.Destroy (this.gameObject);
		}
	}*/
	public float getDamage(){
		return damage;
	}
}

using UnityEngine;
using System.Collections;

public class WeaponStats : MonoBehaviour, IShoot {
	public float range;
	public float damage;
	public float fireRate;
	
	public Transform target;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setRange(float range){
		this.range = range;
	}

	void setDamage(float damage){
		this.damage = damage;
	}

	void setFireRate(float fireRate){
		this.fireRate = fireRate;
	}

	public virtual void Shoot(){
		Debug.Log ("Child uninitialized");
	}

	public void setTarget(Transform target){
		this.target = target;
		Shoot ();
	}
}

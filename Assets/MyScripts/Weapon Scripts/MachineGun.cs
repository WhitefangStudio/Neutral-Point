using UnityEngine;
using System.Collections;

public class MachineGun : WeaponStats{
	public GameObject bulletPrefab;
	string bulletPrefabString;
	// Use this for initialization
	void Start () {
		bulletPrefabString = bulletPrefab.ToString ();
		bulletPrefabString="Bullets/"+bulletPrefabString.Replace(" (UnityEngine.GameObject)","");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Shoot(){
		if(target!=null){
			if(Vector3.Distance(transform.position,target.position)<range){
				Quaternion toward = Quaternion.LookRotation (target.position);
				GameObject bullet = PhotonNetwork.Instantiate(bulletPrefabString,transform.position,toward,0);
				bullet.GetComponent<PhotonView>().RPC ("init",PhotonTargets.All,new object[]{(object)target.position,(object)damage});
				bullet.GetComponent<Bullet>().team=this.transform.GetComponentInParent<Unit>().player;
				//();(object)5f, (object)5f, 
				Invoke ("Shoot",fireRate);
			}else{
				Invoke("Shoot",0.1f);
			}
		}

	}


	void OnCollisionEnter(Collision c){
		GameObject.Destroy (this);
	}
}

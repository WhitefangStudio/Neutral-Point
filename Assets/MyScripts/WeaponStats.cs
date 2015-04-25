using UnityEngine;
using System.Collections;

public class WeaponStats : MonoBehaviour {
	public int Damage;
	public int Accuracy;
	public int RateofFire;

	public enum fireType {Projectile,Laser,Artillery};
	public fireType FT;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

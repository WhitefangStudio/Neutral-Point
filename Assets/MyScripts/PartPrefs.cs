using UnityEngine;
using System.Collections;

public class PartPrefs : MonoBehaviour {
	public float health;
	public float speed;
	public float size;
	public float defense;
	public float attackSpeed;
	public float damage;
	public float energyUsage;
	public string name;

	public GameObject[] attachmentNodes;
	public Sprite sprite;
	public bool isbody;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 originalScale = transform.localScale;
	}
	public int getNodes(){
		return this.attachmentNodes.Length;
	}
}

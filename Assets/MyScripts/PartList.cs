using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PartList : MonoBehaviour {
	public static PartList PL;
	GameObject Holder;
	public GameObject[] parts;

	public GameObject[][][][] partsSorted;

	void Start () {
		if (PL == null) {
			PL=this;
		}
		Holder= new GameObject ();
		Holder.name = "PartList Holder";
		parts = Resources.LoadAll<GameObject> ("Modules");
		
		for (int i = 0; i<parts.Length; i++) {
			parts[i] = (GameObject)Instantiate(parts[i],new Vector3(1000,1000,1000),Quaternion.identity);
			parts[i].transform.parent=Holder.transform;
			//partsTemp[(int)parts[i].GetComponent<FactoryPart>().getBaseType()].Add(parts[i]);
			
		}
		Invoke ("groupDoubles", 1f);
		Invoke ("sort", 3f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void groupDoubles(){
		bool triggered = false;
		List<GameObject>partTemp= new List<GameObject>();
		List<GameObject>partTemp2= new List<GameObject>();
		List<string>Names= new List<string>();
		for (int i =0; i<parts.Length; i++) {
			if(!(Names.Contains(parts[i].GetComponent<FactoryPart>().getName()))){
				partTemp.Add (parts[i]);
				Names.Add (parts[i].GetComponent<FactoryPart>().getName());
			}else{
				partTemp2.Add(parts[i]);
			}
		}
		for (int i =0; i<partTemp.Count; i++) {
			for(int j=0; j<partTemp2.Count;j++){
				if(partTemp[i].GetComponent<FactoryPart>().getName ()==partTemp2[j].GetComponent<FactoryPart>().getName ()){
					partTemp[i].GetComponent<FactoryPart>().addToPair(partTemp2[j]);
				}
			}
		}
		
		parts = partTemp.ToArray ();
	}
	void sort(){
		partsSorted = new GameObject[6][][][];
		List<GameObject>[][][] partsTemp = new List<GameObject>[6][][];
		for (int i = 0; i<partsTemp.Length; i++) {
			partsTemp[i]=new List<GameObject>[6][];
			partsSorted[i]=new GameObject[6][][];
			for(int j=0;j<partsTemp[i].Length;j++){
				partsTemp[i][j]=new List<GameObject>[6];
				partsSorted[i][j]= new GameObject[6][];
				for(int k=0;k<partsTemp[i][j].Length;k++){
					partsTemp[i][j][k]= new List<GameObject>();
					partsSorted[i][j][k]= new GameObject[6]; 
				}
			}
		}

		
		for (int i=0; i<parts.Length; i++) {
			partsTemp[(int)parts[i].GetComponent<FactoryPart>().getBaseType()][parts[i].GetComponent<FactoryPart>().getTier2Int()][parts[i].GetComponent<FactoryPart>().getTier3Int()].Add(parts[i]);
		}
		for (int i=0; i<partsTemp.Length; i++) {
			for(int j=0;j<partsTemp[i].Length;j++){
				for(int k=0;k<partsTemp[i][j].Length;k++){
					partsSorted[i][j][k]=partsTemp[i][j][k].ToArray();
				}
			}
		}
		print ();
	}
	
	void print(){
		for (int i=0; i<partsSorted.Length; i++) {
			for (int j=0; j<partsSorted[i].Length; j++) {
				for (int k=0; k<partsSorted[i][j].Length; k++) {
					for (int l=0; l<partsSorted[i][j][k].Length; l++) {
						Debug.Log (partsSorted[i][j][k][l].ToString()+" "+i+" "+j+" "+k+" "+l);
					}
				}
			}
		}
	}

}

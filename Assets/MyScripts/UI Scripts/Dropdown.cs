using UnityEngine;
using System.Collections;

public class Dropdown: MonoBehaviour 
{
	public string[] items;
	public Rect Box;
	public string selectedItem = "None";
	
	private bool editing = false;
	private bool pressed;
	
	private void OnGUI()
	{
		if(editing == false){
			if (GUI.Button(Box, selectedItem))
			{
				pressed = true;
				editing = true;
			}
		}
		
		if (editing)
		{ 
			Texture2D texture = new Texture2D(1, 1);
			texture.SetPixel(0,0,Color.grey);
			texture.Apply();
			GUI.DrawTexture (new Rect (Box.x, Box.y, Box.width, Box.height*(items.Length+1)), texture);
			if (GUI.Button(Box,"None")){
				selectedItem = "None";
				editing = false;
			}
			for (int x = 0; x < items.Length; x++)
			{
				if (GUI.Button(new Rect(Box.x, (Box.height * x) + Box.y + Box.height, Box.width, Box.height), items[x]))
				{
					selectedItem = items[x];
					editing = false;
				}
			}
		}
		
	}
	
	public void Update(){
		if (Input.GetMouseButtonDown (0)) {
			
			pressed=false;
		}
		if (Input.GetMouseButtonUp (0)) {
			if (pressed == false){
				editing = false;
			}
		}
		
	}
}
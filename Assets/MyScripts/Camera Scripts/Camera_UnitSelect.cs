using UnityEngine;
using System.Collections;

public class Camera_UnitSelect : MonoBehaviour {

	public Texture2D selectionHighlight;
	public static Rect selection = new Rect (0,0,0,0);
	private Vector3 startClick = -Vector3.one;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		checkCamera();

	}
	
	private void checkCamera(){
		if (Input.GetMouseButtonDown (0)){
			startClick=Input.mousePosition;
		}else if(Input.GetMouseButtonUp (0)){
			if(selection.width < 0){
				selection.x+= selection.width;
				selection.width= -1*(selection.width);
			}
			if(selection.height <0){
				selection.y +=selection.height;
				selection.height = -1*(selection.height);
			}
			
			startClick= -Vector3.one;
			
		}
		
		float startX=startClick.x;
		float startY=InvertMouseY(startClick.y);
		float width=Input.mousePosition.x-startClick.x;
		float height=InvertMouseY(Input.mousePosition.y)-InvertMouseY(startClick.y);
		
		if (Input.GetMouseButton(0)){
			if ((startX< Input.mousePosition.x)&&( startY <InvertMouseY(Input.mousePosition.y))){
				selection = new Rect(startX, startY,width,height);
			}
			if ((startX> Input.mousePosition.x)&&( startY <InvertMouseY(Input.mousePosition.y))){
				selection = new Rect(Input.mousePosition.x, startY,-width,height);
			}
			if ((startX< Input.mousePosition.x)&&( startY >InvertMouseY(Input.mousePosition.y))){
				selection = new Rect(startX, InvertMouseY(Input.mousePosition.y),width,-height);
			}
			
			if ((startX> Input.mousePosition.x)&&( startY >InvertMouseY(Input.mousePosition.y))){
				selection = new Rect(Input.mousePosition.x, InvertMouseY(Input.mousePosition.y),-width,-height);
			} 
			
			if ((startX==Input.mousePosition.x)||( startY ==InvertMouseY(Input.mousePosition.y))){
				selection = new Rect(Input.mousePosition.x,InvertMouseY(Input.mousePosition.y),width,height);
			}
			
		}
		
	}
	
	public void OnGUI(){
		if (startClick != -Vector3.one){
			GUI.color = new Color (.7f,.7f,1,.5f);
			GUI.DrawTexture (selection, selectionHighlight);
		}
	
	}
	
	
	public static float InvertMouseY(float y){
		return Screen.height - y;
	}
	
}

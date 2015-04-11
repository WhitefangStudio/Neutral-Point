using UnityEngine;
using System.Collections;
public class Cursor : MonoBehaviour {
	public Texture2D cursorCustom;
	int cursorSizeX = 8;  // Your cursor size x
	int cursorSizeY = 8;  // Your cursor size y

	// Use this for initialization
	void Start () {
		UnityEngine.Cursor.visible = false;
	
	}
	
	void OnGUI()
	{
		GUI.DrawTexture (new Rect(Input.mousePosition.x-cursorSizeX/2, Screen.height-Input.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), cursorCustom);
	}
}

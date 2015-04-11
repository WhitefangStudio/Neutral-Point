using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	Vector3 mousePos;
	public float camSpeedA = 1.5f;
	float camSpeed;
	public float maxRotate;
	
	bool moveUp = false;
	bool moveLeft=false;
	bool moveRight=false;
	bool moveDown=false;
	bool zoomIn=false;
	bool zoomOut=false;
	public bool camLock=false;
	private int Swidth;
	private int Sheight;
	public int maxZoomIn= 20;
	public int maxZoomOut= 50;
	Vector3 zoomPos;
	public static CameraMovement Cam;

	void Awake() {
		Cam = this;
	}
	// Use this for initialization
	void Start () {
		maxRotate = 5;
	}

	// Update is called once per frame
	void Update () {
		inputCheck ();

		if (!camLock) {
			Swidth = Screen.width;
			Sheight = Screen.height;
			if (camSpeed > 1)
				camSpeed -= .2f;
			mousePos = Input.mousePosition;
			moveCam ();
			camSpeed = camSpeedA * transform.position.y / 1.4f;
			}

	}


	void inputCheck(){
				if (Input.GetKeyDown (KeyCode.L)) {
					camLock=!camLock;
				}

				if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
						zoomIn = true;
				} else {
						zoomIn = false;
				}
		
				if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
						zoomOut = true;
				} else {
						zoomOut = false;
				}
		

				if ((mousePos.x > (Swidth - 15)) || (Input.GetKey (KeyCode.RightArrow))) {
						moveRight = true;
				} else {
						moveRight = false;
				}
		
				if ((mousePos.x < 15) || (Input.GetKey (KeyCode.LeftArrow))) {
						moveLeft = true;
				} else {
						moveLeft = false;
				}
		
				if ((mousePos.y > (Sheight - 15)) || (Input.GetKey (KeyCode.UpArrow))) {
						moveUp = true;
				} else {
						moveUp = false;
				}
		
				if ((mousePos.y < 15) || (Input.GetKey (KeyCode.DownArrow))) {
						moveDown = true;
				} else {
						moveDown = false;
				}

		}


	void moveCam(){
		if (zoomIn== true){
			if(transform.position.y >(float)maxZoomIn){
				zoomPos=transform.position;
				zoomPos.y-=10;
				transform.position = Vector3.Lerp(transform.position,zoomPos, 10f*Time.deltaTime);
				maxRotate-=1;
				
				if(maxRotate<5){
					Quaternion rot = Quaternion.Euler(-10,0,0);
					transform.rotation = Quaternion.Lerp(transform.rotation,transform.rotation*rot, .1f);

				}
			}
		}
		
		if (zoomOut== true){
			if(transform.position.y <(float)maxZoomOut){
				zoomPos=transform.position;
				zoomPos.y+=10;
				transform.position = Vector3.Lerp(transform.position,zoomPos, 10f*Time.deltaTime);
				maxRotate+=1;
				
				if(maxRotate<6){	
					Quaternion rot = Quaternion.Euler(10,0,0);
					transform.rotation = Quaternion.Lerp(transform.rotation,transform.rotation*rot, .1f);

				}
			}
		}
	
	
		if (moveUp == true&&moveLeft==false&&moveRight==false) {
			transform.Translate (Vector3.forward * camSpeed * Time.deltaTime,Space.World);
			if (camSpeed <10)
				camSpeed += .5f;
		}
		if (moveDown == true&&moveLeft==false&&moveRight==false) {
			transform.Translate (Vector3.forward *-1*  camSpeed * Time.deltaTime,Space.World);
			if (camSpeed <10)
				camSpeed += .5f;
		}
		if (moveLeft == true&&moveUp==false&&moveDown==false) {
			transform.Translate (Vector3.right *-1*  camSpeed * Time.deltaTime,Space.World);
			if (camSpeed <10)
				camSpeed += .5f;
		}
		if (moveRight == true&&moveUp==false&&moveDown==false) {
			transform.Translate (Vector3.right*  camSpeed * Time.deltaTime,Space.World);
			if (camSpeed <10)
				camSpeed += .5f;
		}

		if (moveUp == true&&moveRight==true) {
			transform.Translate (Vector3.forward * camSpeed * Time.deltaTime*.7f,Space.World);
			transform.Translate (Vector3.right * camSpeed * Time.deltaTime*.7f,Space.World);
			if (camSpeed <10)
				camSpeed += .5f;
		}
		if (moveUp == true&&moveLeft == true) {
			transform.Translate (Vector3.right *-1*  camSpeed * Time.deltaTime*.7f,Space.World);
			transform.Translate (Vector3.forward * camSpeed * Time.deltaTime*.7f,Space.World);
			if (camSpeed <10)
				camSpeed += .5f;
		}
		if (moveDown == true && moveRight==true) {
			transform.Translate (Vector3.right*  camSpeed * Time.deltaTime*.7f ,Space.World);
			transform.Translate (Vector3.forward * -1* camSpeed * Time.deltaTime*.7f ,Space.World);
			if (camSpeed <10)
				camSpeed += .5f;
		}
		if (moveDown == true && moveLeft==true) {
			transform.Translate (Vector3.right* -1* camSpeed * Time.deltaTime*.7f,Space.World);
			transform.Translate (Vector3.forward *-1* camSpeed * Time.deltaTime*.7f,Space.World);
			if (camSpeed <10)
				camSpeed += .5f;
		}




	}

}

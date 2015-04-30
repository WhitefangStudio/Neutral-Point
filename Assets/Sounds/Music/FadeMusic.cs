using UnityEngine;
using System.Collections;

public class FadeMusic : MonoBehaviour {
	public AudioSource audio;
	int volume;
	float audio2Volume=0f;
	bool fadein;
	// Use this for initialization
	void Start () {
		volume = 0;
		setFade (true);

	}
	
	// Update is called once per frame
	void Update () {
		if (fadein) {
			fadeInSound ();
		} else {
			fadeOutSound();
		}
	}

	void fadeInSound(){
			if (audio2Volume < 9) {
				audio2Volume += 0.1f * Time.deltaTime;
				audio.volume = audio2Volume;
			}
	}

	
	void fadeOutSound(){
		if (audio2Volume > 0) {
			audio2Volume -= 0.1f * Time.deltaTime;
			audio.volume = audio2Volume;
		}
	}

	public void setFade(bool f){
		fadein = f;
	}
}

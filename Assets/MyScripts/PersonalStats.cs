	using UnityEngine;
	using System.Collections;
	using UnityEngine.UI;
	
	public class PersonalStats : MonoBehaviour {
		int seconds;
		int minutes;
		int Resource;
		Text ResourceDisplay;
		Text time;
		public bool gameStarted;
		int player;
		GameObject StatPanel;

		// Use this for initialization
		void OnEnable () {

		}
		
		void Start(){
			gameStarted = false;
			player = (PhotonNetwork.player.ID);
			StatPanel = GameObject.Find ("DisplayPanel");
			ResourceDisplay = StatPanel.transform.GetChild (1).GetComponent<Text> ();
			time =StatPanel.transform.GetChild (0).GetComponent<Text> ();
		}
		
		void Update(){
			Resource = GlobalStats.stats.getStats (player);
			ResourceDisplay.text = Resource.ToString();
			time.text = Mathf.Round(GlobalStats.stats.getTime()).ToString();
			Debug.Log (gameStarted);
			
		}
		
		public void startGame(){
			gameStarted = true;
			Debug.Log ("GameStarted");
			Debug.Log (gameStarted);
		}
}


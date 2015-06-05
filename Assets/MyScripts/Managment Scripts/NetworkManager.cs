using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	public bool isOffline;

	
	
	// Use this for initialization

	void Update () {
		if (!PhotonNetwork.connected) {
						Connect ();
				}
	}	
	void Connect(){
		if (isOffline) {
			PhotonNetwork.offlineMode = true;
			OnJoinedRoom();
		} else {
			PhotonNetwork.ConnectUsingSettings ("V002");
		}
	}
	
	void OnGUI(){
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString() );
	}
	
	void OnJoinedLobby(){
		Debug.Log ("joined Lobby");
		PhotonNetwork.JoinRandomRoom ();
	}
	
	void OnPhotonRandomJoinFailed() {
		Debug.Log("join room failed");
		PhotonNetwork.CreateRoom (null);
	}
	
	void OnJoinedRoom(){
		Debug.Log("joinedroom");
		Debug.Log (PhotonNetwork.player.ID);
		Vector3 camPos= new Vector3(0,100,0);
		Quaternion camRot = Quaternion.AngleAxis(75, Vector3.right);
		GameObject Cam=(GameObject)PhotonNetwork.Instantiate("Main Camera", camPos, camRot,0);
		if (PhotonNetwork.isMasterClient) {
			PhotonNetwork.Instantiate("Score",Vector3.zero,Quaternion.identity,0);
		}



	}
	﻿
}

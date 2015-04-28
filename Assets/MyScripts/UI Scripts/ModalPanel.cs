using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {
	string position;
	string part;
	public Button Cancel;
	public Button[] ModalButtons;
	public Text question;
	public GameObject modalPanelObject;
	
	private static ModalPanel modalPanel;
	
	public static ModalPanel Instance(){
		if (!modalPanel) {
			modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
			if(!modalPanel)
				Debug.LogError ("no modal panel in scene");
		}
		return modalPanel;
	}

	public void Choice(string question,GameObject[] parts, UnityAction[] choices, UnityAction cancelEvent){
		modalPanelObject.SetActive (true);

		for (int i = 0; i<choices.Length; i++) {
			ModalButtons [i].onClick.RemoveAllListeners ();
			ModalButtons [i].onClick.AddListener (choices [i]);
			ModalButtons [i].onClick.AddListener (ClosePanel);
		}
		
		Cancel.onClick.RemoveAllListeners ();
		Cancel.onClick.AddListener (cancelEvent);
		Cancel.onClick.AddListener (ClosePanel);

		for(int i =0; i<parts.Length; i++){
			this.ModalButtons[i].gameObject.SetActive(true);
			this.ModalButtons[i].transform.GetChild(1).GetComponent<Image>().enabled= true;
			this.ModalButtons[i].transform.GetChild(1).GetComponent<Image>().sprite = parts[i].GetComponent<PartPrefs>().sprite;
			this.ModalButtons[i].GetComponentInChildren<Text>().text = parts[i].GetComponent<PartPrefs>().name;

		}

		this.question.text = question;

		for (int i = parts.Length; i <ModalButtons.Length; i++) {
			this.ModalButtons[i].transform.GetChild (0).GetComponent<Text>().text ="Locked";
			this.ModalButtons[i].transform.GetChild(1).GetComponent<Image>().enabled= false;
			this.ModalButtons[i].gameObject.SetActive(false);
		}
	}

	void ClosePanel(){
		modalPanelObject.SetActive (false);
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_RightUpDownBTN : MonoBehaviour {
	bool rightGridState;
	GameObject rightGrid;
	
	void Awake(){
		//GameObject.Find("UI_right_grid").SetActive(rightGridState);
	}
	// Use this for initialization
	void Start () {
		rightGrid=GameObject.Find("UI_right_menu");
		rightGridState = true;
		rightGrid.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//when up or downBTN on Click then chang right UI grid's stats --by shoutleaf
	public void OnUpdownClick(){
		rightGrid.SetActive(rightGridState);
		rightGridState=!rightGridState;
	}
}


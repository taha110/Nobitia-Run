using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour {

    public Buttons ButtonType;

    public Sprite L_fish_seletion;
    public Sprite R_fish_seletion;
    public GameObject fish_Selection_Object;
   

	void Awake () {
		if(!PlayerPrefs.HasKey("FishSide")){
            PlayerPrefs.SetInt("FishSide", 0);
        }
	}
    
    // Use this for initialization
	void Start () {
        if(!PlayerPrefs.HasKey("FishSide")){
            PlayerPrefs.SetInt("FishSide", 0);
        }
        if(PlayerPrefs.GetInt("FishSide") != 0 && PlayerPrefs.GetInt("FishSide") != 1) {
            selectRightFish();
        }
		if(PlayerPrefs.GetInt("FishSide") == 0){
        fish_Selection_Object.GetComponent<Image>().sprite = R_fish_seletion;
        }else if(PlayerPrefs.GetInt("FishSide") == 1){
        fish_Selection_Object.GetComponent<Image>().sprite = L_fish_seletion;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonPressed() {
        UIManager.Instance.ActivateScreen(ButtonType);
    }

	public void StartGame() {
        SceneManager.LoadScene("GamePlayScene");
    }



    
    public void selectRightFish() {
        PlayerPrefs.SetInt("FishSide", 0);
        Debug.Log("right fishhhhhhhhh");
        fish_Selection_Object.GetComponent<Image>().sprite = R_fish_seletion;
    }
    
    public void SelectLeftFish() {
        PlayerPrefs.SetInt("FishSide", 1);
        Debug.Log("Left fishhhhhhhhh");
        fish_Selection_Object.GetComponent<Image>().sprite = L_fish_seletion;

    }

}


public enum Buttons {
    Start,Options,HowToPlay,BackHTP
}
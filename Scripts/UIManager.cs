using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : Singleton<UIManager> {


    GameObject ActiveScreen;
    public GameObject Home;
    public GameObject HowToPlay;
    public GameObject Options;

    public Text highScoreText;


    void Awake (){
        if(!PlayerPrefs.HasKey("FishSide")){
            PlayerPrefs.SetInt("FishSide", 1);
        }

        if(!PlayerPrefs.HasKey("HighScore")){
            PlayerPrefs.SetInt("HighScore", 0);
        }

        this.Reload();
    }

	// Use this for initialization
	void Start () {
        ActiveScreen = Home;
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

        if(!PlayerPrefs.HasKey("FishSide")){
            PlayerPrefs.SetInt("FishSide", 1);
        }
        if(PlayerPrefs.GetInt("FishSide") != 0 && PlayerPrefs.GetInt("FishSide") != 1){
            PlayerPrefs.SetInt("FishSide", 1);
        }
                    
}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reload()
         {
             applicationIsQuitting = false;
         }

    private static bool applicationIsQuitting = false;
    
	/// <summary>
	/// When Unity quits, it destroys objects in a random order.
	/// In principle, a Singleton is only destroyed when application quits.
	/// If any script calls Instance after it have been destroyed, 
	///   it will create a buggy ghost object that will stay on the Editor scene
	///   even after stopping playing the Application. Really bad!
	/// So, this was made to be sure we're not creating that buggy ghost object.
	/// </summary>
	public void OnDestroy () {
		applicationIsQuitting = true;
	}

    public void ActivateScreen(Buttons _buttonPressed) {
        
        GameObject CurrentActiveScreen = ActiveScreen;
        switch (_buttonPressed)
        {
            case Buttons.HowToPlay:
                ActiveScreen = HowToPlay;
                break;
            case Buttons.BackHTP:
                ActiveScreen = Home;
                break;
            case Buttons.Start:
                break;
            case Buttons.Options:
            ActiveScreen = Options;
                break;
        }

        CurrentActiveScreen.GetComponent<EasyTween>().OpenCloseObjectAnimation();
        ActiveScreen.GetComponent<EasyTween>().OpenCloseObjectAnimation();

    }

}

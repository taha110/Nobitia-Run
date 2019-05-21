using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GamePlayUI_Manager : MonoBehaviour {

	public GameObject gameOverScreen;
	public static bool _GameOver;
	public GameObject pauseBtn;

	public Sprite pauseIcon;
	public Sprite playIcon;


	bool pauseGame;

	// Use this for initialization
	void Start () {
	
	gameOverScreen.GetComponent<EasyTween>().OpenCloseObjectAnimation();
	pauseGame = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(_GameOver){
			 for (int i = 0; i < Input.touchCount; ++i)
        	{
            	if (Input.GetTouch(i).phase == TouchPhase.Began)
            	{
					SceneManager.LoadScene("Home");
					_GameOver = false;
				}
			}


			if (Input.GetKeyDown("space")){

					SceneManager.LoadScene("Home");
					_GameOver = false;
    		}
		}
	}

	public void PauseGameToggle(){
		print("Pause Clickec");
		if(!pauseGame){
			Time.timeScale = 0f;
			pauseGame = true;
			pauseBtn.GetComponent<Image>().sprite = playIcon;
			print("Pauseddddddddddddddddddd");

		}else{
			Time.timeScale = 1f;
			pauseGame = false;
			pauseBtn.GetComponent<Image>().sprite = pauseIcon;
			print("un pauseddddddddddd");

		}
	}


}

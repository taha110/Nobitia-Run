using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;



public class PlayerFish : MonoBehaviour {

	public Animator anim;
	public Rigidbody2D rb;
	public float thrust;
	public Text scoreText;
	public Text objectiveScoreText;
	public Text highScoreText;
	

	int currentScore;

	public int[] levelPoints;
	public float[] sizes;

	public GameObject gameOverScreen;
	public GameObject gameOverText1;
	public GameObject gameOverText2;
	public GameObject gameOverText3;

	public int mysize;

	// ////////////// physics ////////////
	public float vertSpeed;
	public float jumpSpeed;
	public float fallingConstant;
	public float YSpeed;

	public AudioClip audio_move1;
	public AudioClip audio_move2;
	public AudioClip audio_move3;

	public AudioClip audio_chomp1;
	public AudioClip audio_chomp2;
	public AudioClip audio_chomp3;

	public AudioClip audio_new_record;

	public GameObject fishSpawnerObj;

	public static Vector3 NobitaPos;

	bool canJump;
	float _tempCanJumpTimer;
	public float jumpTime;

	public static bool _isInvisible;
	public static int _scoreMultiplier;
	public static bool _isMagnet;

	public Image UI_2x;
	public Image UI_3x;
	public Image UI_Invisible;
	public Image UI_Magnet;	
	public Sprite sp_2x;
	public Sprite sp_3x;
	public Sprite sp_invisible;
	public Sprite sp_magnet;
	public Sprite sp_2x_dull;
	public Sprite sp_3x_dull;
	public Sprite sp_invisible_dull;
	public Sprite sp_magnet_dull;

	bool isAnyPowerup;
	public float powerupTimeLimit;
	float tempPowerupTimer;


	int rand = 0;
	AudioSource audioSource;


	// Admob // 
	private InterstitialAd interstitial;
	
	// Use this for initialization
	void Start () {
	
	anim = GetComponent<Animator>();
	rb = GetComponent<Rigidbody2D>();
	currentScore=0;

	_isInvisible = false;
	_scoreMultiplier = 1;
	isAnyPowerup = false;

	highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

	gameOverScreen.SetActive(true);

	audioSource = GetComponent<AudioSource>();
	canJump = true;
	_tempCanJumpTimer = 0;

	// if(PlayerPrefs.HasKey("FishSide")){
	// 	if(PlayerPrefs.GetInt("FishSide") == 0){

	// 	}else{
	// 		this.gameObject.transform.position = new Vector3(-6 , 0 , -5);
	// 		this.gameObject.transform.eulerAngles  = new Vector3(0,180,0);
	// 		        Debug.Log(" fishhhhhhhhh   rotation");
	// 	}
	// }


		/// admob initialization

		#if UNITY_ANDROID
            string appId = "ca-app-pub-6432932007254983~8101554794";
        #elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
        #else
            string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);





	this.RequestInterstitial();

	}
	

	    private void RequestInterstitial()
    {
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif



        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        // Register for ad events.
        /* 
		this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
        this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
        this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;
*/

	// Create an empty ad request.
    AdRequest request = new AdRequest.Builder().Build();
    // Load the interstitial with the request.
    interstitial.LoadAd(request);

    }






	// Update is called once per frame
	void Update () {

	NobitaPos = this.transform.position;

	if(isAnyPowerup){
		DoPowerup();
	}
	
	//Debug.Log(PlayerPrefs.GetInt("FishSide"));

		if (Input.GetKeyDown("space")){
//            print("space key was pressed");

			//anim.SetTrigger("eat");

			//rb.AddForce(transform.up * thrust);
			if(canJump){
			vertSpeed = jumpSpeed;
			canJump = false;
			anim.SetTrigger("jump");
			}


			//random for sound

			rand = UnityEngine.Random.Range(0,2);
			switch (rand)
        	{
        	case 0:
						audioSource.PlayOneShot(audio_move1, 0.5F);
            break;
			case 1:
						audioSource.PlayOneShot(audio_move2, 0.5F);
            break;
			case 2:
						audioSource.PlayOneShot(audio_move3, 0.5F);
            break;
			}


    	}

		 for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
				            //print("space key was pressed");

				//rb.AddForce(transform.up * thrust);

				if(canJump){
					vertSpeed = jumpSpeed;
					canJump = false;

					anim.SetTrigger("jump");
				}

			rand = UnityEngine.Random.Range(0,2);
			switch (rand)
        	{
        	case 0:
						audioSource.PlayOneShot(audio_move1, 0.5F);
            break;
			case 1:
						audioSource.PlayOneShot(audio_move2, 0.5F);
            break;
			case 2:
						audioSource.PlayOneShot(audio_move3, 0.5F);
            break;
			}

			}
		}


		this.gameObject.transform.position  = new Vector3(this.gameObject.transform.position.x , (YSpeed) , this.gameObject.transform.position.z);

				vertSpeed -= fallingConstant * Time.deltaTime;

				if(YSpeed < -1.5f && vertSpeed < 0){     			
				
				}else if(YSpeed > 5f && vertSpeed > 0){

				}else{

				YSpeed +=  vertSpeed * Time.deltaTime;

				}


		if(!canJump){
			_tempCanJumpTimer += Time.deltaTime;
			if(_tempCanJumpTimer > jumpTime){
				_tempCanJumpTimer = 0;
				canJump = true;
			}
		}


	}


	public void DoPowerup(){
		if(tempPowerupTimer < powerupTimeLimit){
			tempPowerupTimer += Time.deltaTime;
			if(tempPowerupTimer >= powerupTimeLimit){
				isAnyPowerup=false;
				tempPowerupTimer =0f;
				UI_2x.sprite = sp_2x_dull;
				UI_3x.sprite = sp_3x_dull;					
				UI_Invisible.sprite = sp_invisible_dull;
				UI_Magnet.sprite = sp_magnet_dull;

				_scoreMultiplier=1;
				_isInvisible=false;
				_isMagnet=false;
			}

		}
	}

			void OnTriggerEnter2D(Collider2D col) {
 
				if(col.gameObject.name.Contains("fish") && col.gameObject.GetComponent<EnemyFishScript>().fishSize > mysize && !_isInvisible ){
						gameOverScreen.GetComponent<EasyTween>().OpenCloseObjectAnimation();
						VisiblityTrue(gameOverText1);
						VisiblityTrue(gameOverText2);
						VisiblityTrue(gameOverText3);
						gameOverText2.GetComponent<Text>().text=currentScore.ToString();
						GamePlayUI_Manager._GameOver = true;


						if(PlayerPrefs.GetInt("HighScore") < currentScore){
							        PlayerPrefs.SetInt("HighScore", currentScore);
						}



						
						if (interstitial.IsLoaded()) {
    						interstitial.Show();
  							}

						Destroy(this.gameObject);

				}
        		else if(col.gameObject.name.Contains("fish") || col.gameObject.name.Contains("powerup")){
					//anim.SetTrigger("eat");	

					print("playing eating animmmmmmmmmmmmmmmmmmmmmmmmmmm");		
					
					if(col.gameObject.name.Contains("Minnow_fish")){
					currentScore += _scoreMultiplier ;							
					scoreText.text = currentScore.ToString();
					} else if(col.gameObject.name.Contains("Invisible_powerup")){
					_isInvisible = true;							
					isAnyPowerup = true;
					UI_Invisible.sprite = sp_invisible;
					tempPowerupTimer =0f;

					//scoreText.text = currentScore.ToString();
					} else if(col.gameObject.name.Contains("Double_powerup")){
					_scoreMultiplier = 2;
					isAnyPowerup = true;		
					UI_2x.sprite = sp_2x;	
					tempPowerupTimer =0f;				
					//scoreText.text = currentScore.ToString();
					} else if(col.gameObject.name.Contains("Triple_powerup")){
					_scoreMultiplier = 3;
					isAnyPowerup = true;	
					UI_3x.sprite = sp_3x;	
					tempPowerupTimer =0f;					
					//scoreText.text = currentScore.ToString();
					}  else if(col.gameObject.name.Contains("Magnet_powerup")){
					_isMagnet = true;
					isAnyPowerup = true;	
					UI_Magnet.sprite = sp_magnet;	
					tempPowerupTimer =0f;					
					//scoreText.text = currentScore.ToString();
					}

					//random for sound

			rand = UnityEngine.Random.Range(0,2);
			switch (rand)
        	{
        	case 0:
						audioSource.PlayOneShot(audio_chomp1, 0.7F);
            break;
			case 1:
						audioSource.PlayOneShot(audio_chomp2, 0.7F);
            break;
			case 2:
						audioSource.PlayOneShot(audio_chomp3, 0.7F);
            break;
			}

					HighScoreBreak();
					//PlayerFishLevelCheck();
				}
    		}

	
	
	public void VisiblityTrue(GameObject obj){
			obj.SetActive(true);

	}

	public void HighScoreBreak() {

		if(currentScore == PlayerPrefs.GetInt("HighScore") + 1){
			audioSource.PlayOneShot(audio_new_record, 0.7F);
		}
	}

}	

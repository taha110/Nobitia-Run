
using UnityEngine;
using System;
using System.Collections;
using System.IO;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class uiController : MonoBehaviour {

	// Use this for initialization
	public Camera uiCam;
	public string hitObjName;
	public GameObject playGame,review,levels,ui,exit,creditsDetails;
	public Renderer playRender,reviewRender,exitRender;
	public Texture[] playTexture,reviewTexture,exitTexture;
	
	private bool isProcessing = false;

	// Admob // 
	private RewardBasedVideoAd rewardBasedVideoAd;

	void Start () {
		Time.timeScale = 1;

		//ios store won't accepect exit buttons 
		#if UNITY_IPHONE
		Destroy(exit);
		#endif

				/// admob initialization

		#if UNITY_ANDROID
            string appId = "ca-app-pub-6432932007254983~8101554794";
        #elif UNITY_IPHONE
            string appId = "ca-app-pub-6432932007254983~8101554794";
        #else
            string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);


			/// admob instance...........
	rewardBasedVideoAd = RewardBasedVideoAd.Instance;


	///  admob events.......
	// Called when an ad request has successfully loaded.
        rewardBasedVideoAd.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideoAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideoAd.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideoAd.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideoAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideoAd.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideoAd.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

	///  Admob thingiiii (Reward Video)
	LoadRewardBasedAd();
	///
	


	}


		private void LoadRewardBasedAd(){
		#if UNITY_EDITOR
			string adUnitId = "UNUSED -- EDITOR";
		#elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-6432932007254983/6909780091";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #else
            string adUnitId = "unexpected_platform";
        #endif

		// Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        rewardBasedVideoAd.LoadAd(request, adUnitId);
	}


	private void ShowRewardBasedAd(){
		if (rewardBasedVideoAd.IsLoaded()) {
    		rewardBasedVideoAd.Show();
  		}
	}
	
	// Update is called once per frame
	void Update () {
	
	

		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Ray rayObj = uiCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitObject;
			if(Physics.Raycast(rayObj,out hitObject))
			{
				hitObjName=hitObject.collider.name;
			}
			switch(hitObjName)
			{
			case "Play":
				SoundController.Static.PlayClickSound();
				playRender.material.mainTexture=playTexture[1];
				StartCoroutine (MyLoadLevel ());
								Debug.Log("play button");

				//iTween.MoveTo(levels,new Vector3(0,0,0),2f);
				//iTween.MoveTo(ui,new Vector3(-29,0,0),2f);
				break;
			case "Share":
				SoundController.Static.PlayClickSound();
				if(!isProcessing){
					StartCoroutine( ShareScreenshot() );
				}
				//Application.OpenURL("");
				break;
			case "Review":
				SoundController.Static.PlayClickSound();
				reviewRender.material.mainTexture=reviewTexture[1];
				ShowRewardBasedAd();

				Debug.Log("review button");

				//Application.OpenURL("");
				break;
			case "Exit":
				SoundController.Static.PlayClickSound();
				exitRender.material.mainTexture=exitTexture[1];
				Application.Quit();
				break;
			case "Credits":
				SoundController.Static.PlayClickSound();
				break;
				
			}
		}
		if(Input.GetKeyUp(KeyCode.Mouse0))
		 {
			Ray rayObj = uiCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitObject;
			if(Physics.Raycast(rayObj,out hitObject))
			{
				hitObjName=hitObject.collider.name;
			}
			originalTextures();
			switch(hitObjName)
			{
			case "Play":
				 playRender.material.mainTexture=playTexture[0];
				// iTween.MoveTo(levels,new Vector3(0,0,0),2f);
				// iTween.MoveTo(ui,new Vector3(-29,0,0),2f);
				break;

			case "Review":
				reviewRender.material.mainTexture=reviewTexture[0];
				Application.OpenURL("");
				break;
			case "Exit":
				exitRender.material.mainTexture=exitTexture[0];
				Application.Quit();
				break;
			case "Credits":
				iTween.MoveTo(creditsDetails,new Vector3(0,1.2f,0),2f);
				iTween.MoveTo(ui,new Vector3(29,0,0),2f);
				
				break;
				
				
			}
		}
	}


	IEnumerator MyLoadLevel ()
	{
		yield return new WaitForSeconds (0.3f);
		Application.LoadLevel ("Level-Jungle");
		//Application.LoadLevel ("Space");

	}


	public void originalTextures()
	{
		#if !UNITY_IPHONE
		exitRender.material.mainTexture=exitTexture[0];
		#endif

		reviewRender.material.mainTexture=reviewTexture[0];
		playRender.material.mainTexture=playTexture[0];
	}


		public IEnumerator ShareScreenshot()
	{
		isProcessing = true;

		// wait for graphics to render
		yield return new WaitForEndOfFrame();
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		// create the texture
		Texture2D screenTexture = new Texture2D(Screen.width, Screen.height,TextureFormat.RGB24,true);
		
		// put buffer into texture
		screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);

		// apply
		screenTexture.Apply();
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO

		byte[] dataToSave = screenTexture.EncodeToPNG();
		
		string destination = Path.Combine(Application.persistentDataPath,System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");

		File.WriteAllBytes(destination, dataToSave);

		if(!Application.isEditor)
		{
			// block to open the file and share it ------------START
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
			//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "testo");
			//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");
			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

			// option one WITHOUT chooser:
			currentActivity.Call("startActivity", intentObject);

			// option two WITH chooser:
			//AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "YO BRO! WANNA SHARE?");
			//currentActivity.Call("startActivity", jChooser);

			// block to open the file and share it ------------END

		}
		isProcessing = false;
	}




    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " + type);
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

    #endregion




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {


	public GameObject [] enemyFishes;

	public AudioClip audio_bubble1;
	public AudioClip audio_bubble2;
	public AudioClip audio_bubble3;
	AudioSource audioSource;

	public float fishSpawnDelay;

	int rand;

	public List < int > fishListToSpawn = new List <int>() ;
	public int[] totalFish;
	public int[] selectedFish = new int[4];

	public List < float > fishHeightListToSpawn = new List <float>() ;
	public float[] totalFishHeight;
	public float[] selectedFishHeight = new float[4];

	public GameObject PirhanaFish;

	//int rand_totalNumberOfFish;
	int rand_numSetOneFish;

	IEnumerator WaitAndPrint()
    {
		while (true)
		{
			SelectFishes();

			if(rand_numSetOneFish==1){
				if(selectedFish[1] == selectedFish[2] || selectedFish[2] == selectedFish[3]){
					
				}
			}
			else if(rand_numSetOneFish==3){

			}else{

			}
			
			for(int i =0; i<1; i++){
				//int tempFish = Random.Range(0,4);

			if(PlayerPrefs.HasKey("FishSide")){

				if(rand_numSetOneFish>i){
				
				if(selectedFish[i]==0){
				Instantiate(enemyFishes[selectedFish[i]] , new Vector3(10 + PirhanaFish.transform.position.x, selectedFishHeight[i] , enemyFishes[selectedFish[i]].transform.position.z),  Quaternion.identity);
				
				}else if(selectedFish[i]==1){
				Instantiate(enemyFishes[selectedFish[i]] , new Vector3(10 + PirhanaFish.transform.position.x, -1.6f , enemyFishes[selectedFish[i]].transform.position.z),  Quaternion.identity);
				
				}else if(selectedFish[i]==2){
				Instantiate(enemyFishes[selectedFish[i]] , new Vector3(10 + PirhanaFish.transform.position.x, -1.4f , enemyFishes[selectedFish[i]].transform.position.z),  Quaternion.identity);
				
				}else if(selectedFish[i]==3){
				Instantiate(enemyFishes[selectedFish[i]] , new Vector3(10 + PirhanaFish.transform.position.x, 1f , enemyFishes[selectedFish[i]].transform.position.z),  Quaternion.identity);

				}
					
				}
			else{
				if(selectedFish[i]==0){
				Instantiate(enemyFishes[selectedFish[i]] , new Vector3(13 + PirhanaFish.transform.position.x, selectedFishHeight[i] , enemyFishes[selectedFish[i]].transform.position.z),  Quaternion.identity);
				
				}else if(selectedFish[i]==1){
				Instantiate(enemyFishes[selectedFish[i]] , new Vector3(13 + PirhanaFish.transform.position.x, -1.6f , enemyFishes[selectedFish[i]].transform.position.z),  Quaternion.identity);
				
				}else if(selectedFish[i]==2){
				Instantiate(enemyFishes[selectedFish[i]] , new Vector3(13 + PirhanaFish.transform.position.x, -1.4f , enemyFishes[selectedFish[i]].transform.position.z),  Quaternion.identity);
				
				}else if(selectedFish[i]==3){
				Instantiate(enemyFishes[selectedFish[i]] , new Vector3(13 + PirhanaFish.transform.position.x, 1f , enemyFishes[selectedFish[i]].transform.position.z),  Quaternion.identity);

				}				}
				
			}
			}

			fishListToSpawn.Clear();
			fishHeightListToSpawn.Clear();
			
			//random for sound

			rand = Random.Range(0,2);
			switch (rand)
        	{
        	case 0:
						//audioSource.PlayOneShot(audio_bubble1, 1F);
            break;
			case 1:
						//audioSource.PlayOneShot(audio_bubble2, 1F);
            break;
			case 2:
						//audioSource.PlayOneShot(audio_bubble3, 1F);
            break;
			}



			// suspend execution for 5 seconds
       	 	yield return new WaitForSeconds(fishSpawnDelay);
					
		}       
    }

    IEnumerator Start()
    {
        print("Starting " + Time.time);
			audioSource = GetComponent<AudioSource>();

        // Start function WaitAndPrint as a coroutine
        yield return StartCoroutine("WaitAndPrint");
        //print("Done " + Time.time);
		
    }

	public void SwapSlectedFishes(int a , int b){
		int _tempValue;

		_tempValue = selectedFish[a];
		selectedFish[a] = selectedFish[b];
		selectedFish[b] = _tempValue;
	}


	public void SelectFishes(){
		for(int i=0; i<7; i++){
			fishListToSpawn.Add(totalFish[i]);
		}

		for(int j=0; j<4; j++){
			int tempint = fishListToSpawn.Count;
			int rand_select = Random.Range(0,tempint);
			selectedFish[j] = fishListToSpawn[rand_select];
			fishListToSpawn.RemoveAt(rand_select);
		}
		
		// special size conditions ...........
		if(PirhanaFish != null){
			// size 1 -------------------
		if(PirhanaFish.GetComponent<PlayerFish>().mysize == 1){

		int tempMinnowCount =0;

		for(int i=0; i<4; i++){
			if(selectedFish[i]==0 ){
				tempMinnowCount++;
			}
		}
		if(tempMinnowCount==0){
			selectedFish[0]=0;
			}
		}
		

			// size 2 ------------------------------
		if(PirhanaFish.GetComponent<PlayerFish>().mysize == 2){

		int tempBassCount =0;
		int tempSharkCount =0;

		for(int i=0; i<4; i++){
			if(selectedFish[i]==2 ){
				tempBassCount++;
			}
			if(selectedFish[i]==3 ){
				tempSharkCount++;
			}
		}
		if(tempBassCount==2 && tempSharkCount==1){
			selectedFish[0]=0;
			selectedFish[1]=1;

			}
		}
		
		}
		// ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
		for(int i=0; i<8; i++){
			fishHeightListToSpawn.Add(totalFishHeight[i]);
		}

		for(int j=0; j<4; j++){
			int tempHeightint = fishHeightListToSpawn.Count;
			int rand_select_height = Random.Range(0,tempHeightint);
			selectedFishHeight[j] = fishHeightListToSpawn[rand_select_height];
			fishHeightListToSpawn.RemoveAt(rand_select_height);
		}


	rand_numSetOneFish = Random.Range(1,4);
	
	}





	public void IncreaseEnemyFishSpeed(){
		print("increasingn sopeed  ");

	for(int i=0; i<4; i++){
		enemyFishes[i].GetComponent<EnemyFishScript>().fishSpeed = enemyFishes[i].GetComponent<EnemyFishScript>().fishSpeed * 1.1f;
	}
		fishSpawnDelay = fishSpawnDelay * 0.9f;
	}

}

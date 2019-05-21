using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SelectCharacterRJ ()
	{
		Application.LoadLevel ("CityScene");
	}

	public void SelectCharacterAutumn ()
	{
		Application.LoadLevel ("SkyIsland");
	}

	public void SelectCharacterZypher ()
	{
		Application.LoadLevel ("Floating");
	}
}

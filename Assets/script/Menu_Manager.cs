using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour {

	public GameObject MenuPanel;
	public GameObject CreditScane;
	public GameObject HowToPlay;
	public GameObject Settings;
	public GameObject Level;
	public AudioSource lagu;

	// Use this for initialization

	void Start () {
		MenuPanel.SetActive (true);
		CreditScane.SetActive (false);
		HowToPlay.SetActive (false);
		Level.SetActive (false);
		Settings.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}

	public void PlayClicked()
	{
		Application.LoadLevel (1); //nama scane ketika klik tombol play//
		Time.timeScale = 1;
	}

	public void CreditClicked()
	{
		MenuPanel.SetActive (false);
		CreditScane.SetActive (true);
		HowToPlay.SetActive (false);
		Level.SetActive (false);
		Settings.SetActive (false);
	}

	public void LevelClicked()
	{
		MenuPanel.SetActive (false);
		Level.SetActive (true);
		CreditScane.SetActive (false);
		HowToPlay.SetActive (false);
		Settings.SetActive (false);
	}

	public void Level1Clicked()
	{
		Application.LoadLevel (1); //nama scane ketika klik tombol play//
		Time.timeScale = 1;
	}

	public void Level2Clicked()
	{
		Application.LoadLevel (2); //nama scane ketika klik tombol play//
		Time.timeScale = 1;
	}

	public void Level3Clicked()
	{
		Application.LoadLevel (3); //nama scane ketika klik tombol play//
		Time.timeScale = 1;
	}

	public void CaraMainClicked()
	{
		MenuPanel.SetActive (false);
		CreditScane.SetActive (false);
		HowToPlay.SetActive (true);
		Level.SetActive (false);
		Settings.SetActive (false);
	}

	public void SettingsClicked()
	{
		MenuPanel.SetActive (false);
		CreditScane.SetActive (false);
		HowToPlay.SetActive (false);
		Level.SetActive (false);
		Settings.SetActive (true);
	}

	public void BackButtonCicked()
	{
		MenuPanel.SetActive (true);
		CreditScane.SetActive (false);
		HowToPlay.SetActive (false);
		Level.SetActive (false);
		Settings.SetActive (false);
	}

	public void PlayMusicClicked()
	{
		lagu.volume = 0.3f; //Play Musik//
	}

	public void MuteMusicClicked()
	{
		lagu.volume = 0; //Mute Musik//
	}
}
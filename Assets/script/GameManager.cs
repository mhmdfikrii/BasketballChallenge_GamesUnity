using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject panelPause;
	public GameObject settingsPanel;
	public AudioSource lagu;

	private bool isPaused = false;
	private bool isSetting = false;

	public void PauseControl()
	{
		isPaused = !isPaused;

		if (isPaused)
		{
			Time.timeScale = 0;
			panelPause.SetActive(true);
			settingsPanel.SetActive(false);
		}
		else
		{
			Time.timeScale = 1;
			panelPause.SetActive(false);
			settingsPanel.SetActive(false);
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}

	public void SettingsClicked()
	{
		if (!isSetting)
		{
			isSetting = true;
			settingsPanel.SetActive(true);
			panelPause.SetActive(false);
			Time.timeScale = 0;
		}
	}

	public void ShowPausePanel()
	{
		isSetting = false;
		settingsPanel.SetActive(false);
		panelPause.SetActive(true);
	}


	public void MenuUtama()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
	}

	public void PlayMusicClicked()
	{
		lagu.volume = 0.3f; //Play Musik//
	}

	public void MuteMusicClicked()
	{
		lagu.volume = 0; //Mute Musik//
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
}

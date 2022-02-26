using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
	[SerializeField]GameObject[] showOnPauseObjects;
	[SerializeField] GameObject[] hideOnPauseObjects;

	[SerializeField] GameObject exitPopup;

	[SerializeField] GameObject mainMenu;
	[SerializeField] GameObject settings;

	[SerializeField] TMP_Text textVolume;
	[SerializeField] Slider volumeSlider;
	[SerializeField] GameObject audioPopup;

	float defaultVolume;
	float currentVolume;

	bool canPause = false;

	IEnumerator waitCinematic()
    {
		yield return new WaitForSeconds(6.0f);
		canPause = true;
    }

	// Use this for initialization
	void Start()
	{
		Time.timeScale = 1;
		hidePaused();
		StartCoroutine(waitCinematic());
		volumeSlider.value = AudioListener.volume*50;
		textVolume.text = (AudioListener.volume * 50).ToString("0.0");
		defaultVolume =AudioListener.volume;
		currentVolume = defaultVolume;
	}

	// Update is called once per frame
	void Update()
	{

		//uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.P) && canPause)
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}


	//Reloads the Level
	public void Reload()
	{
		//Application.LoadLevel(Application.loadedLevel);
	}

	//controls the pausing of the scene
	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		foreach (GameObject g in showOnPauseObjects)
		{
			g.SetActive(true);
		}
		foreach (GameObject g1 in hideOnPauseObjects)
		{
			//g1.SetActive(false);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		foreach (GameObject g in showOnPauseObjects)
		{
			g.SetActive(false);
		}
		foreach (GameObject g1 in hideOnPauseObjects)
		{
			//g1.SetActive(true);
		}
	}

	//loads inputted level
	public void LoadLevel(string level)
	{
		//Application.LoadLevel(level);
	}

	public void quitLevel()
	{

		Application.Quit();
		UnityEditor.EditorApplication.isPlaying = false;
	}

	public void openExitPopup()
    {
		exitPopup.SetActive(true);
    }

	public void closeExitPopup()
    {
		exitPopup.SetActive(false);
    }

	public void showAudioSetting()
    {
		volumeSlider.value = currentVolume * 50;
		textVolume.text = (currentVolume * 50).ToString("0.0");
		audioPopup.SetActive(true);
		
    }

	public void hideAudioSetting()
    {
		currentVolume = AudioListener.volume;
		audioPopup.SetActive(false);
    }

	public void setVolume()
    {
		float value = volumeSlider.value;
		AudioListener.volume = value/50;
		textVolume.text = (value).ToString("0.0");
    }

	public void exitVolumeWithoutUpdate()
    {
		AudioListener.volume = currentVolume;
		audioPopup.SetActive(false);
    }

	public void resetVolume()
    {
		AudioListener.volume = defaultVolume;
		textVolume.text = (defaultVolume * 50).ToString("0.0");
		volumeSlider.value = defaultVolume * 50;
	
    }

	public void setDefaultVolume()
    {
		AudioListener.volume = defaultVolume;
		volumeSlider.value = defaultVolume * 50;
		textVolume.text = (defaultVolume*50).ToString("0.0");

	}

	public void settings2mainMenu()
    {
		mainMenu.SetActive(true);
		settings.SetActive(false);
		
    }

	public void mainMenu2settings()
	{
		mainMenu.SetActive(false);
		settings.SetActive(true);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	[SerializeField]GameObject[] showOnPauseObjects;
	[SerializeField] GameObject[] hideOnPauseObjects;

	[SerializeField] GameObject exitPopup;

	[SerializeField] GameObject mainMenu;
	[SerializeField] GameObject mainMenu1;
	[SerializeField] GameObject settings;

	[SerializeField] TMP_Text textVolume;
	[SerializeField] Slider volumeSlider;
	[SerializeField] GameObject audioPopup;
	float defaultVolume;
	float currentVolume;

	float brightness;
	[SerializeField] Camera cameraPlayer;
	[SerializeField] GameObject background;

	[SerializeField] GameObject player;

	[SerializeField] TMP_Text textBrightness;
	[SerializeField] Slider brightnessSlider;
	float defaultBrightness;
	float currentBrightness;
	Color defaultColor;
	Color currentColor;

	[SerializeField] GameObject dropdownQuality;

	int currentQuality;
	int defaultQuality;

	[SerializeField] GameObject dropdownResolution;
	private Resolution[] resolutions;

	int defaultResolutionIndex;
	int currentResolutionIndex;

	[SerializeField] GameObject graphicPopup;

	[SerializeField] GameObject controlsPopup;

	[SerializeField] GameObject[] menuButtons;

	[SerializeField] GameObject[] settingButtons;

	[SerializeField] GameObject play;

	public bool startingGame = true;










	bool canPause = false;

	void deactivate(GameObject[] buttons)
    {
		for (int i = 0; i < buttons.Length; i++)
        {
			buttons[i].SetActive(false);
        }
    }

	void activate(GameObject[] buttons)
	{
		for (int i = 0; i < buttons.Length; i++)
		{
			buttons[i].SetActive(true);
		}
	}

	IEnumerator waitCinematic()
    {
		yield return new WaitForSeconds(6.0f);
		canPause = true;
    }

	// Use this for initialization
	void Start()
	{
		
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		Time.timeScale = 1;
		hidePaused();
		StartCoroutine(waitCinematic());

		//init volume
		volumeSlider.value = AudioListener.volume*50;
		textVolume.text = (AudioListener.volume * 50).ToString("0.0");
		defaultVolume = AudioListener.volume;
		currentVolume = defaultVolume;

		//init brightness
		brightness = cameraPlayer.GetComponent<Light>().intensity;
		brightnessSlider.value = brightness * 50;
		textBrightness.text = (50 + brightness * 100).ToString("0.0");
		defaultBrightness = brightness;
		currentBrightness = brightness;
		Color color = background.GetComponent<Image>().color;
		color.r = 0.5f;
		color.g = 0.5f;
		color.b = 0.5f;
		color.a = 1.0f;
		defaultColor = color;
		currentColor = color;
		background.GetComponent<Image>().color = color;

		//init quality
		QualitySettings.SetQualityLevel(2);
		dropdownQuality.GetComponent<TMP_Dropdown>().value = 1;
		dropdownQuality.GetComponent<TMP_Dropdown>().RefreshShownValue();



		//init resolutions
		resolutions = Screen.resolutions;
		List<string> options = new List<string>();



		dropdownResolution.GetComponent<TMP_Dropdown>().ClearOptions();
		for (int i = 0; i < resolutions.Length; i++)
        {
			options.Add(resolutions[i].width + "x" + resolutions[i].height);
			

			if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
				defaultResolutionIndex = i;
            }
        }
		dropdownResolution.GetComponent<TMP_Dropdown>().AddOptions(options);
		dropdownResolution.GetComponent<TMP_Dropdown>().value = defaultResolutionIndex;
		dropdownResolution.GetComponent<TMP_Dropdown>().RefreshShownValue();
		currentResolutionIndex = defaultResolutionIndex;

		currentQuality = 1;
		defaultQuality = 1;
	}

	// Update is called once per frame
	void Update()
	{

		//uses the p button to pause and unpause the game
		if ((Input.GetKeyDown(KeyCode.P) && canPause) || startingGame)
		{
            if (startingGame)
            {
				startingGame = false;
            }
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

	public void startGame()
    {
		mainMenu1.SetActive(false);
		player.SetActive(true);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

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
		deactivate(menuButtons);

	}

	public void closeExitPopup()
    {
		exitPopup.SetActive(false);
		activate(menuButtons);

	}

	public void showAudioSetting()
    {
		volumeSlider.value = currentVolume * 50;
		textVolume.text = (currentVolume * 50).ToString("0.0");
		audioPopup.SetActive(true);
		deactivate(settingButtons);


	}

	public void hideAudioSetting()
    {
		currentVolume = AudioListener.volume;
		audioPopup.SetActive(false);
		activate(settingButtons);

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
		activate(settingButtons);

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

	public void setBrightness()
    {
		float value = brightnessSlider.value;
		cameraPlayer.GetComponent<Light>().intensity = (value / 100)*2;
		Color color = background.GetComponent<Image>().color;
		color.r = 0.5f + Mathf.RoundToInt(value) * 0.01f;
		color.g = 0.5f + Mathf.RoundToInt(value) * 0.01f;
		color.b = 0.5f + Mathf.RoundToInt(value) * 0.01f;
		background.GetComponent<Image>().color = color;
		textBrightness.text = (50 + value).ToString("0.0");
	}

	public void setQuality()
    {
		QualitySettings.SetQualityLevel(dropdownQuality.GetComponent<TMP_Dropdown>().value + 1);
    }

	public void applyGraphics()
    {
		//save resolution
		currentResolutionIndex = dropdownResolution.GetComponent<TMP_Dropdown>().value;

		//save quality
		currentQuality = dropdownQuality.GetComponent<TMP_Dropdown>().value;

		//save brightness
		currentBrightness = brightnessSlider.value/50;
		currentColor = background.GetComponent<Image>().color;

		graphicPopup.SetActive(false);
		activate(settingButtons);


	}

	public void showGraphics()
    {
		graphicPopup.SetActive(true);
		deactivate(settingButtons);
	}

	public void cancelChangeGraphics()
    {
		Screen.SetResolution(resolutions[currentResolutionIndex].width, 
			resolutions[currentResolutionIndex].height, Screen.fullScreen);
		dropdownResolution.GetComponent<TMP_Dropdown>().value = currentResolutionIndex;
		dropdownResolution.GetComponent<TMP_Dropdown>().RefreshShownValue();

		QualitySettings.SetQualityLevel(currentQuality);
		dropdownQuality.GetComponent<TMP_Dropdown>().value = currentQuality;
		dropdownQuality.GetComponent<TMP_Dropdown>().RefreshShownValue();

		background.GetComponent<Image>().color = currentColor;
		cameraPlayer.GetComponent<Light>().intensity = currentBrightness;
		Debug.Log(currentBrightness);
		brightnessSlider.value = currentBrightness * 50;
		textBrightness.text = (50 + currentBrightness * 50).ToString("0.0");

		graphicPopup.SetActive(false);
		activate(settingButtons);




	}

	public void setResolution()
    {
		
		Resolution resolution = resolutions[dropdownResolution.GetComponent<TMP_Dropdown>().value];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

	public void setGraphics2Default()
    {
		brightnessSlider.value = 0;
		background.GetComponent<Image>().color = defaultColor;
		textBrightness.text = "50";
		cameraPlayer.GetComponent<Light>().intensity = 0;

		QualitySettings.SetQualityLevel(2);
		dropdownQuality.GetComponent<TMP_Dropdown>().value = 1;
		dropdownQuality.GetComponent<TMP_Dropdown>().RefreshShownValue();

		Screen.SetResolution(resolutions[defaultResolutionIndex].width, resolutions[defaultResolutionIndex].height, Screen.fullScreen);
		dropdownResolution.GetComponent<TMP_Dropdown>().value = defaultResolutionIndex;
		dropdownResolution.GetComponent<TMP_Dropdown>().RefreshShownValue();

	}

	public void showControls()
    {
		controlsPopup.SetActive(true);
		deactivate(settingButtons);
    }

	public void hideControls()
    {
		controlsPopup.SetActive(false);
		activate(settingButtons);
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene("SceneClara2");
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	[SerializeField]GameObject[] showOnPauseObjects;
	[SerializeField] GameObject[] hideOnPauseObjects;
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
}

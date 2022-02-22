﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class opencloseDoor : MonoBehaviour
{

	[SerializeField] private Animator openandclose;
	public bool open;

	private bool openCorouRunning = false;
	private bool closeCorouRunning = false;


	void Start()
		{
			open = false;
		}

		
	public void Open()
	{
		if (!openCorouRunning && !open)
		{

			StartCoroutine(opening());
			Invoke("Close", 5f);
			
		}
	}
	public void Close()
	{
		if (!closeCorouRunning && open)
		{
			CancelInvoke("Close");
			StartCoroutine(closing());
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Invoke("Close", 1.0f);
		}
	}
	IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}

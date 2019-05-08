﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Audio : MonoBehaviour {

	public AudioClip[] audios;
	private AudioSource audioSource;
	private AudioClip shoot;
	private AudioClip jump;
	private AudioClip dead;
	private AudioClip damaged;


	private void Start(){
		audioSource = this.gameObject.GetComponent<AudioSource>();
		for(int i = 0; i<4; i++)
		{
			switch (audios[i].name)
			{
				case "playerDamagedSFX":
				damaged = audios[i];
				break;
				case "playerDeadSFX":
				dead = audios[i];
				break;
				case "playerShootSFX":
				shoot = audios[i];
				break;
				case "playerJumpSFX":
				jump = audios[i];
				break;
			}
		}
	}
	public void PlayDamage()
	{
		audioSource.clip = damaged;
		audioSource.Play();
	}
	public void PlayDead()
	{
		audioSource.clip = dead;
		audioSource.Play();
	}
	public void PlayShoot()
	{
		audioSource.clip = shoot;
		audioSource.Play();
	}
	public void PlayJump()
	{
		audioSource.clip = jump;
		audioSource.Play();
	}

	private void Update()
	{

	}
}

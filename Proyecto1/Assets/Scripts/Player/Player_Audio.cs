using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Audio : MonoBehaviour {

	public AudioClip[] audios;
	private AudioSource audioSource;
	private AudioClip[] shoot;
	private AudioClip jump;
	private AudioClip dead;
	private AudioClip damaged;


	private void Start(){
		audioSource = this.gameObject.GetComponent<AudioSource>();
		shoot = new AudioClip[3];
		int k = 0;		
		for(int i = 0; i<audios.Length; i++)
		{
			print(audios[i].name);

			switch (audios[i].name)
			{
				case "playerDamagedSFX":
				damaged = audios[i];
				break;
				case "playerDeadSFX":
				dead = audios[i];
				break;
				case "playerShoot1SFX":
				shoot[k] = audios[i];
				k++;
				break;
				case "playerShoot2SFX":
				shoot[k] = audios[i];
				k++;
				break;
				case "playerShoot3SFX":
				shoot[k] = audios[i];
				k++;
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
		System.Random rnd = new System.Random();
		int r = rnd.Next(0,3);
		audioSource.clip = shoot[r];
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

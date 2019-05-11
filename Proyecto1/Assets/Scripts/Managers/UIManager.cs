using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ClockSounds
{
    public AudioClip[] clips;
}
public class UIManager : MonoBehaviour
{
    const int blinker = 15; 
    public AudioClip buttonSound;
    public Image clock;

    public Text scoreText, timeoutText, collected, winOrLose, regenSOZ;
    public GameObject panel, initialPanel;
    int nextLevel;
    int currentBlinker = 0;
    float timeToDisable = 0.05f;
    bool highlightedText;
    public ClockSounds[] clockSounds;
    AudioSource clockAudioSource;
    int tickTockFreq = -1;


    private void Awake()
    {
    }
    void Start()
    {
        GameManager.instance.SetUIManager(this);
        try {clockAudioSource = clock.gameObject.GetComponent<AudioSource>();}
        catch {print("No tiene audiosource el reloj");}
    }
    
    public void TimeOutside (float time)
    {
        regenSOZ.enabled = true;
        regenSOZ.text = "¡Entra! ¡Rápido! Antes de: " + (int)(time + 1);
    }

    public void TimeEntered()
    {
        regenSOZ.enabled = false;
    }

    public void PlayerCollected(int collect, int max)
    {
        collected.text = "" + collect + " / " + max;
    }

    public void PlayerKills(int kills)
    {
        collected.text = "Enemigos restantes: " + kills;
    }

    //llama al GameManager para saber el tiempo que le quede y lo muestra en pantalla
    public void SeeTime(float timer, float maxSeconds)
    {
        float timeOverMax = timer / maxSeconds;
        
        clock.fillAmount = timeOverMax;
        
        System.Random rnd = new System.Random();

        if(timeOverMax <= 0.75f && timeOverMax > 0.5f)
        {
            ClockPlaySound(0, rnd.Next(0,clockSounds[0].clips.Length));
        }
        else if (timeOverMax <= 0.5f && timeOverMax > 0.25f)
        {
            ClockPlaySound(1, rnd.Next(0,clockSounds[1].clips.Length));    
            ChangeColor();
        }
        else if(timeOverMax <=0.25f)
        {
            ClockPlaySound(2, rnd.Next(0,clockSounds[2].clips.Length));
            ClockBlinks();
        }
    }

    private void ClockPlaySound(int i, int j)
    {
        if(tickTockFreq != i)
        {
            clockAudioSource.clip = clockSounds[i].clips[j];
            clockAudioSource.Play();
        }

    }

    private void ChangeColor()
    {
        clock.color = new Color32(255,0,0,255); //Rojo full alpha
    }

    private void ClockBlinks()
    {
        if(currentBlinker == 0)
        {
            Color temp;
            temp = clock.color;
            temp.a = 0;
            clock.color = temp;
        } else if(currentBlinker==blinker)
        {
            Color temp;
            temp = clock.color;
            temp.a = 1;
            clock.color = temp;
            currentBlinker = -blinker;
        }
       currentBlinker++;

    }

    public void HighlightTextColor(Text text)
    {
        if (!highlightedText && text.GetComponentInParent<Button>().interactable != false)
        {
            text.color = Color.yellow;
            highlightedText = true;
        }
    }


    public void ReturnTextToNormal(Text text)
    {
        if (highlightedText && text.GetComponentInParent<Button>().interactable != false)
        {
            text.color = Color.black;
            highlightedText = false;
        }
    }


    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }

    public void FinishLevel(bool win, int level)
    {
        if (!win) Invoke("EnablePanel", GameManager.instance.GetLoseTime());
        else Invoke("EnablePanel", 0f);
        if (win) winOrLose.text = "Has ganado";
        else winOrLose.text = "Has perdido";
        nextLevel = level + 1;
        print(nextLevel);

    }


    public void ChangeLevel()
    {
        GameManager.instance.LoadLevel(nextLevel);
    }

    //hay que hacer que el menú principal sea la escena 0
    public void MainMenu()
    {
        GameManager.instance.LoadLevel(0);
    }

    public void StartLevel()
    {
        initialPanel.SetActive(true);
    }

    public void DisablePanel()
    {
        GameObject pan = initialPanel;
        pan.SetActive(false);
    }
    public void EnablePanel()
    {
        panel.SetActive(true);
    }
    public float GetTime() {return timeToDisable; }
    public void PlaySoundButton(){
        AudioManager.instance.PlayClip(buttonSound);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    //int playerPoints = 0;




    private void Awake()
    {

    }
    void Start()
    {
        GameManager.instance.SetUIManager(this);
    }
    
    public void TimeOutside (float time)
    {
        /*
        timeoutText.enabled = true;
        timeoutText.text = "" + time;
        */
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
        clock.fillAmount = timer / maxSeconds;
        if(timer/maxSeconds <= 0.5f && timer/maxSeconds> 0.25f)
        {
            ChangeColor();
        }
        else if(timer/maxSeconds <=0.25f)
            ClockBlinks();
        
        //timer.text = "Time: " + (int)maxSeconds;
    }
    private void ChangeColor()
    {
            clock.color = new Color32(255,0,0,255);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Image clock;

    public Text scoreText, timeoutText, collected, winOrLose, regenSOZ;
    public GameObject panel, initialPanel;
    int nextLevel;
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
        //timer.text = "Time: " + (int)maxSeconds;
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
        if (!win) Invoke("EnablePanel", 1.5f);
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

    //hay que hacer que el menú principal sea la escena 1
    public void MainMenu()
    {
        GameManager.instance.LoadLevel(1);
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
}

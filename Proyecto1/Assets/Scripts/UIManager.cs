using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text timer, scoreText, timeoutText,collected, winOrLose;
    public GameObject panel;
    int nextLevel;
    bool highlightedText;
    //int playerPoints = 0;


    
   
    void Start()
    {
       GameManager.instance.SetUIManager(this);
    }
    /*
    void Update()
    {
        scoreText.text = "Points: " + playerPoints;  Como UIManager solo encarga de update los puntos, no deberá tener la referencia de los playerpoints.
    }                                         (Ademas como va a ser algo como GM que va a cambiar de escena a escena, no debe tener alguna referencia en Start o Update de algo (excepto GM))
    */
    
    public void TimeOutside (int time)
    {
        timeoutText.enabled = true;
        timeoutText.text = "" + time;
    }

    public void TimeEntered(bool lived)
    {
        if (lived)
        {
            timeoutText.enabled = false;
        }
        else
        {
            timeoutText.text = "YOU LOSE";
        }
    }

    public void PlayerCollected(int collect,int max)
    {
        collected.text = "" + collect + " / " + max;
    }

    public void PlayerKills(int kills)
    {
        collected.text = "Remaining enemies: " + kills;
    }

    //llama al GameManager para saber el tiempo que le quede y lo muestra en pantalla
    public void SeeTime(float seconds, float maxSeconds)
    {
        timer.text ="Time: " + (int)seconds + "/" + (int)maxSeconds;
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
        panel.SetActive(true);
        if (win) winOrLose.text = "Has ganado";
        else winOrLose.text = "Has perdido";
        nextLevel = level;

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
     
    
}

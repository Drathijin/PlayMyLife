using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {

    public GameObject[] lvlObjects;
    private RawImage[] lvlImages;
    private LevelState[] lvlStates;
    private string dir = "./saves.txt"; //dirección de .txt

    // Use this for initialization
	void Start () {
        lvlImages = new RawImage[lvlObjects.Length];
        lvlStates = new LevelState[lvlObjects.Length];
        for (int i = 0; i < lvlObjects.Length; i++)
            lvlImages[i] = lvlObjects[i].GetComponent<RawImage>();
        GetStates();
        SetColors();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetStates()
    {
        StreamReader reader = new StreamReader(dir);
        reader.ReadLine(); //Ignora el primer nivel (menú) del guardado
        for(int i = 0; i < lvlStates.Length; i++)
        {
            string[] line = reader.ReadLine().Split(' ');
            lvlStates[i] = (LevelState)Enum.Parse(typeof (LevelState), line[0]);
            print(lvlStates[i]);
        }
    }
    void SetColors()
    {
        for(int i = 0; i < lvlImages.Length; i++)
        {
            switch (lvlStates[i])
            {
                case 0:
                    lvlImages[i].color = Color.grey;
                    break;
                case (LevelState)1:
                    lvlImages[i].color = Color.red;
                    break;
                case (LevelState)2:
                    lvlImages[i].color = Color.green;
                    break;
            }
        }
    }
}

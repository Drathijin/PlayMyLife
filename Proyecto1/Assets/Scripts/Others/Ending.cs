using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Ending : MonoBehaviour {

    int[] victories = new int[3]; //en este orden, cuenta las victorias del ámbito Familiar, Social y Académico
    string dir = "./saves.txt";
    /*public Text[] family = new Text[3];
    public Text[] social = new Text[3];
    public Text[] academic = new Text[3];*/

    public Text[] texts = new Text[9];
   
    // Use this for initialization
    void Start () {
        AlgoDeso();
        SetText();

    }

    // Update is called once per frame
    void Update () {
	}

    /// <summary>
    /// Lee el archivo y guarda en victorias el número de victorias de cada tipo
    /// </summary>
    private void AlgoDeso()
    {
        StreamReader file = new StreamReader(dir);
        string line;
        file.ReadLine(); //para que se salte lo del menú
        while (!file.EndOfStream)
        {
            line = file.ReadLine();
            char c = char.Parse(line.Split(' ')[1]);
            string v = line.Split(' ')[0];
            switch (c)
            {
                case 'f':
                    if (v == "Win") victories[0] += 1;
                    break;
                case 's':
                    if (v == "Win") victories[1] += 1;
                    break;
                case 'a':
                    if (v == "Win") victories[2] += 1;
                    break;
            }
            //esto.es.una.linea
            //line.Splie('.')
        }
        file.Close();
    }

    private void SetText()
    {
        int index = 0;
        for(int i = 0; i<victories.Length;i++)
        {
            if (victories[i] <= 1)
            {
                texts[index].gameObject.SetActive(true);
            }
            else if (victories[i] <= 3)
            {
                texts[index + 1].gameObject.SetActive(true);
            }
            else
                texts[index + 2].gameObject.SetActive(true);

            index += 3;
        }
    } 
}

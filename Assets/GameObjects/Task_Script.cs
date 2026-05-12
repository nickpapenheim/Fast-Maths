using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Task_Script : MonoBehaviour
{
    public TextMeshPro text;
    public GameLogic gameLogic;
    int stellenAnzahl = Start_Game_Script.settings_stellenanzahl;
    int rechenart = Start_Game_Script.settings_rechenart;
    int zahl1;
    int zahl2;
    public float solution;
    // Initialisieren der Geschwindigkeit von den Aufgaben TODO: Mechanismus verbessern um ihn an Schwierigkeit anzupassen
    public float task_speed;
    // wird benutzt um Task am rechten Bildschirmrand zu zerstören
    float time = 0;
    bool movingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { // TODO : FindObject ist computationally teuer, vlt gibt es hier eine bessere Lösung mit direktverweisen? 
        gameLogic = FindAnyObjectByType<GameLogic>();
        task_speed = 1f/Start_Game_Script.settings_schwierigkeit;
        zahl1 = RandomizedZahl(stellenAnzahl);
        zahl2 = RandomizedZahl(stellenAnzahl);
        // Je nach gewählter Rechenart in den Settings wird der Text und die Solution anders bestimmt 
        switch (rechenart)
        {
            // Addition
            case 0:
                text.text=zahl1 + "+" + zahl2;
                solution = zahl1 + zahl2;
            break;
            // Subtraktion: Es wird immer die größere minus die kleinere Zahl gerechnet um negative Zahlen zu vermiden
            case 1:
                if (zahl1 >= zahl2)
                {
                    text.text= zahl1 + "-" + zahl2;
                    solution = zahl1 - zahl2;
                } else
                {
                    text.text= zahl2 + "-" + zahl1;
                    solution = zahl2 - zahl1;
                }
                
            break;
            // Multiplikation
            case 2:
                text.text =zahl1 + "*" + zahl2;
                solution = zahl1 * zahl2;
            break;
            // Division wird umgesetzt indem das Ergebnis einer Multiplikation zweier natürlichlicher Zufallszahlen durch einen der beiden Faktoren dargestellt wird.
            // Im Falle einer 0 im Divisor wird dieser zur 7. 
            case 3:
                if (zahl2 == 0)
                {
                    zahl2=7;
                }
                text.text =zahl1*zahl2 + "/" + zahl2;
                solution = zahl1;
            break;
        }
        gameLogic.activeTasks.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLogic.gamePaused == false) {
            if (movingRight)
            {
                if (transform.position.x <= 5)
                {
                    transform.Translate(Vector3.right * task_speed * Time.deltaTime);
                } else
                {
                    movingRight = false;
                }
            } else
            {
                time = time + Time.deltaTime;
                if (time > Start_Game_Script.settings_schwierigkeit/2)
                {
                    remove_task();
                }
            }

        }
        
    }

    // generiert random Zahl mit x vielen stellen
    int RandomizedZahl(int stellen)
    {
        // TODO: Zahlen weighten, 7 öfter, 0 und 1 weniger oft
        int randomZahl;
        randomZahl = UnityEngine.Random.Range(0, Mathf.RoundToInt(Mathf.Pow(10,Start_Game_Script.settings_stellenanzahl)));
        return randomZahl;
    }

    public void remove_task()
    {
        gameLogic.activeTasks.Remove(this);
        Destroy(gameObject);
    }

}

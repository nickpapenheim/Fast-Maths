using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    //
    // GAMEOBJECTS
    //

    // Festlegen des Gameobjects in dem die Eingabe erscheint
    public TextMeshProUGUI Eingabe;
    // Festlegen des Gameobjects in dem der Score angezeigt wird
    public TextMeshProUGUI ScoreUI;
    // Festlegen des Gameobjects in dem die übrige Zeit erscheint
    public TextMeshProUGUI Timer;
    // Festlegen des Gameobjects mit dem die Aufgaben dargestellt werden
    public GameObject task_prefab;

    public GameObject GameOverScreen;
    // Liste der aktiven Tasks
    public List<Task_Script> activeTasks = new List<Task_Script>();

    //
    // PARAMETER
    //
    public int score = 0;
    float zeit = Start_Game_Script.settings_zeit;
    //
    // Festlegen der möglichen Spawnposition der Tasks, TODO: Dynamisches anpassen an Bildschirm, ich habe aktuell auf einem 1920x1080p Monitor getestet x für linken bildschirmrand y für höhe auf dem bildschirm
    float task_x = -7f;
    float task_min_y = -12f;
    float task_max_y = -20f;
    float random_task_y;
    // Festlegen der Zeit zwischen Aufgaben TODO: Das an Schwierigkeitsgrad anpassen
    float delay = 1.5f;
    // gibt an ob Spiel pausiert ist
    public bool gamePaused = false;
    

    //
    // CALLS DURCH UNITY
    //
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Spawn_task), delay, 2*delay);
    }

    // Update is called once per frame
    void Update()
    {
        // Runterticken des Timers
        if (gamePaused == false)
        {
            zeit = zeit - Time.deltaTime;
            if (zeit < 0)
            {
                End_game();
            } else
            {
                Timer.text = zeit.ToString().Split(",")[0];
            }
        }
        // Falls aktuell keine Aufgaben da sind sofort eine neue Aufgabe spawnen
        if(activeTasks.Count==0)
        {
            Spawn_task();
        }

        // Steuerungsskripte
        // Eingabe der Lösung beim Drücken der Entertaste und nicht leerem String
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
                foreach (Task_Script Task in activeTasks){
                if (Eingabe.text == Task.solution.ToString()) {
                    Task.remove_task();
                    // TODO: Hier irgendwelche Multiplikatoren zur Motivation schnellerer Lösungen einbauen
                    score = score + 100;
                    ScoreUI.text=score.ToString();
                    break;
                } else {}
            } 
            Eingabe.text = "";
        }
        // Löschen des letzten Zeichens bei nicht leerem Eingabestring
         if(Input.GetKeyDown(KeyCode.Backspace))
        { if (!(Eingabe.text==""))
            {
                Eingabe.text = Eingabe.text.Substring(0,Eingabe.text.Length-1);
            }
        }
        // Eingabe Zahlen
         if(Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            Eingabe.text = Eingabe.text + "1";
        }
         if(Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            Eingabe.text = Eingabe.text + "2";
        }
         if(Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            Eingabe.text = Eingabe.text + "3";
        }
         if(Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            Eingabe.text = Eingabe.text + "4";
        }
         if(Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            Eingabe.text = Eingabe.text + "5";
        }
         if(Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            Eingabe.text = Eingabe.text + "6";
        }
         if(Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
        {
            Eingabe.text = Eingabe.text + "7";
        }
         if(Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            Eingabe.text = Eingabe.text + "8";
        }
         if(Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            Eingabe.text = Eingabe.text + "9";
        }
         if(Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
        {
                Eingabe.text = Eingabe.text + "0";
        }
    }

    //
    // METHODEN
    //

    void End_game()
    {
        gamePaused = true;
        GameOverScreen.SetActive(true);
    }

    void Spawn_task()
    {
        if (gamePaused == false) {
            random_task_y = Random.Range(task_min_y, task_max_y);
           Instantiate(task_prefab, new Vector3(task_x, random_task_y, 0f), Quaternion.identity);
        }
    }
}

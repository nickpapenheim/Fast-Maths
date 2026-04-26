using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Festlegen des Gameobjects in dem die Eingabe erscheint
    public TextMeshProUGUI Eingabe;
    // Festlegen des Gameobjects in dem die übrige Zeit erscheint
    public TextMeshProUGUI Timer;
    // Spielzeit
    float zeit = 10f;
    public GameObject GameOverScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Runterticken des Timers 
        zeit = zeit - Time.deltaTime;
        if (zeit < 0)
        {
            End_game();
        } else
        {
            Timer.text = zeit.ToString().Split(",")[0];
        }


        // Steuerungsskripte
        // Eingabe der Lösung beim Drücken der Entertaste und nicht leerem String
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            // TODO Lösungskontrollskript
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
            // Wenn Eingabe leer ist, kann keine 0 als erstes Zeichen gesetzt werden.
            if (!(Eingabe.text==""))
            {
                Eingabe.text = Eingabe.text + "9";
            }
        }
    }

    void End_game()
    {
        GameOverScreen.SetActive(true);
    }
}

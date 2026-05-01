using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Task_Script : MonoBehaviour
{
    public TextMeshPro text;
    public GameLogic gameLogic;
    int zahl1;
    int zahl2;
    int randomZahl;
    public float solution;
    // Initialisieren der Geschwindigkeit von den Aufgaben TODO: Mechanismus entwerfen um ihn an Schwierigkeit anzupassen
    public float task_speed = 0.5f;
    bool movingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { // TODO : FindObject ist computationally teuer, vlt gibt es hier eine bessere Lösung mit direktverweisen? 
        gameLogic = FindAnyObjectByType<GameLogic>();
        // TODO: RandomizedZahl soll nach globaler Variable viele stellen bekommen
        zahl1 = RandomizedZahl(1);
        zahl2 = RandomizedZahl(1);
        text.text=zahl1 + "*" + zahl2;
        // TODO: Logik solution zu bestimmen nach gewählter Rechenform
        solution = zahl1 * zahl2;
        gameLogic.activeTasks.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight && gameLogic.gamePaused == false)
        {
            if (transform.position.x <= 5)
            {
                transform.Translate(Vector3.right * task_speed * Time.deltaTime);
            } else
            {
                movingRight = false;
            }

        }
    }

    // generiert random Zahl mit x vielen stellen
    int RandomizedZahl(int stellen)
    {
        // TODO: Zahlen weighten, 7 öfter, 0 und 1 weniger oft
        randomZahl = Random.Range(0, 10*stellen);
        return randomZahl;
    }

    public void remove_task()
    {
        gameLogic.activeTasks.Remove(this);
        Destroy(gameObject);
    }

}

using TMPro;
using UnityEngine;

public class Task_Script : MonoBehaviour
{
    public TextMeshPro text;
    public float solution;
    // Initialisieren der Geschwindigkeit von den Aufgaben TODO: Mechanismus entwerfen um ihn an Schwierigkeit anzupassen
    public float task_speed = 2f;
    bool movingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text="2+2";
        // TODO: Logik random aufgaben zu generieren und solution zu bestimmen
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            if (transform.position.x <= 5)
            {
                transform.Translate(Vector3.right * task_speed * Time.deltaTime);
            }
        }
    }

}

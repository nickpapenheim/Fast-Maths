using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Start_Game_Script : MonoBehaviour
{

    // Einstellungsfelder
    public TMP_Dropdown zeit_dropdown;
    public TMP_Dropdown rechenart_dropdown;
    public TMP_Dropdown schwierigkeit_dropdown;
    public TMP_Dropdown stellenanzahl_dropdown;

    // Variablen die vor dem Spiel eingestellt werden können
        public static float settings_zeit;
        public static int settings_rechenart;
        public static float settings_schwierigkeit;
        public static int settings_stellenanzahl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Start_game() {
        switch (zeit_dropdown.value)
        {
            case 0: settings_zeit = 30f;
            break;
            case 1: settings_zeit = 60f;
            break;
            case 2: settings_zeit = 120f;
            break;
            case 3: settings_zeit = 180f;
            break;
        }
        settings_rechenart = rechenart_dropdown.value;

        settings_stellenanzahl = stellenanzahl_dropdown.value +1;

        // Schwierigkeitsgrad erhöht die Aufgabenfrequenz
        switch (schwierigkeit_dropdown.value)
        {
            case 0: settings_schwierigkeit = 10f * settings_stellenanzahl;
            break;
            case 1: settings_schwierigkeit = 4f * settings_stellenanzahl;
            break;
            case 2: settings_schwierigkeit = 2f * settings_stellenanzahl;
            break;
            case 3: settings_schwierigkeit = 1f * settings_stellenanzahl;
            break;
        }
        SceneManager.LoadScene("Game");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_Game_Script : MonoBehaviour
{

    // Einstellungsfelder
    public Dropdown zeit_dropdown;

    // Variablen die vor dem Spiel eingestellt werden können
        public static int settings_zeit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Start_game() {
        SceneManager.LoadScene("Game");
    }
}

using UnityEngine;
using TMPro;

public class End_Game_Script : MonoBehaviour
{
    
    public GameLogic gameLogic;

    public TextMeshProUGUI scoreUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    } 

    void OnEnable()
    {
        scoreUI.text = gameLogic.score.ToString();
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}

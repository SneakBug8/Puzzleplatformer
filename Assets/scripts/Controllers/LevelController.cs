using System.Collections.Generic;
using UI;
using UnityEngine.UI;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Global;
    public GameObject WinView;
    public GameObject LostView;
    public GameObject PlayerObject;
    public bool LevelEnded = false;

    // Use this for initialization
    void Awake()
    {
        Global = this;
        
        Time.timeScale = 1;
    }
    void Start() {
        Player.Global.OnDeath.AddListener(OnLose);
    }
    public void OnVictory()
    {
        if (!LevelEnded)
        {
            LevelEnded = true;
            WinView.SetActive(true);
            Time.timeScale = 0f;

            MainController.Global.Level++;
        }
    }

    public void OnLose()
    {
        if (!LevelEnded)
        {
            LevelEnded = true;
            LostView.SetActive(true);
            Time.timeScale = 0;            
        }
    }
}
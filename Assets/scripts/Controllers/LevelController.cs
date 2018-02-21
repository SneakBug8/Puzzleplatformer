using System.Collections.Generic;
using UI;
using UnityEngine.UI;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Global;
    public GameObject WinView;
    public GameObject LostView;
    public Dictionary<string, Sprite> KeySprites = new Dictionary<string, Sprite>();

    // Use this for initialization
    void Awake()
    {
        Global = this;

        Time.timeScale = 1;
    }
    void Start()
    {
        Player.Global.OnDeath.AddListener(OnLose);
    }
    public void OnVictory()
    {
        Time.timeScale = 0f;
        Player.Global.enabled = false;
        WinView.SetActive(true);
    }

    public void OnLose()
    {
        Time.timeScale = 0;
        Player.Global.gameObject.SetActive(false);
        
        LostView.SetActive(true);
    }
}
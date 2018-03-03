using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Global;
    public GameObject WinView;
    public GameObject LostView;
    public Dictionary<string, Sprite> KeySprites = new Dictionary<string, Sprite>();

    public int LevelId;

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

        if (MainController.LastCompletedLevelId < LevelId) {
            MainController.LastCompletedLevelId = LevelId;
        }
    }

    public void OnLose()
    {
        Time.timeScale = 0;
        Player.Global.gameObject.SetActive(false);
        
        if (LostView != null) {
            LostView.SetActive(true);
        }
        else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
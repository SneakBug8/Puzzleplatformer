using UnityEngine;
using UnityEngine.SceneManagement;

public static class MainController {
    public static int LastCompletedLevelId {
        get {
            return PlayerPrefs.GetInt("level", 0);
    }
        set {
            PlayerPrefs.SetInt("level", value);
    }}

    public static int CurrentLevelId {
        get {
            return int.Parse(SceneManager.GetActiveScene().name);
        }
    }

    public static void LoadLevel(int level)
    {
        if (level >= Config.LevelCount)
        {
            SceneManager.LoadScene("menu");
        }

        SceneManager.LoadScene(level.ToString());
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
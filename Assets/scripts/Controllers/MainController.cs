using UnityEngine;
using UnityEngine.SceneManagement;

public static class MainController {
    public static int NextLevelId {
        get {
            return PlayerPrefs.GetInt("level", 0);
    }
        set {
            PlayerPrefs.SetInt("level", value);
    }}
    public static void LoadLevel(int level)
    {
        if (level >= Config.LevelCount)
        {
            SceneManager.LoadScene("menu");
            return;
        }
        NextLevelId = level;
        PlayerPrefs.SetInt("level", NextLevelId);

        SceneManager.LoadScene(NextLevelId.ToString());
    }

    public static void LoadLevel()
    {
        if (NextLevelId >= Config.LevelCount)
        {
            NextLevelId = 0;
        }
        LoadLevel(NextLevelId);
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
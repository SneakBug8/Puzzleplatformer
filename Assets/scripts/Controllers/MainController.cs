using UnityEngine;
using UnityEngine.SceneManagement;

public static class MainController {
    public static int LastUnlockedLevelId {
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
        LastUnlockedLevelId = level;
        PlayerPrefs.SetInt("level", LastUnlockedLevelId);

        SceneManager.LoadScene(LastUnlockedLevelId.ToString());
    }

    public static void LoadLevel()
    {
        if (LastUnlockedLevelId >= Config.LevelCount)
        {
            LastUnlockedLevelId = 0;
        }
        LoadLevel(LastUnlockedLevelId);
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
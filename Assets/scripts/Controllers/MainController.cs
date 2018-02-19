using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public static MainController Global;

    public int levelcount = 1;
    public int Level {
        get {
            return PlayerPrefs.GetInt("level", 0);
    }
        set {
            PlayerPrefs.SetInt("level", value);
    }}

    private void Awake()
    {
        if (Global != null)
        {
            Destroy(gameObject);
            return;
        }

        Global = this;
    }

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(int level)
    {
        if (level >= levelcount)
        {
            SceneManager.LoadScene("menu");
            return;
        }
        Level = level;
        PlayerPrefs.SetInt("level", Level);

        SceneManager.LoadScene(Level.ToString());
    }

    public void LoadLevel()
    {
        Level = PlayerPrefs.GetInt("level");
        if (Level >= levelcount)
        {
            Level = 0;
        }
        LoadLevel(Level);
    }

    public void ReloadLevel()
    {
        LoadLevel(int.Parse(SceneManager.GetActiveScene().name));
    }

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }
}
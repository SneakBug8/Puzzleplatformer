using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(FadeText))]
[RequireComponent(typeof(Typewriter))]

public class StoryText : MonoBehaviour {
    private Text Text;
    float timetilldisable;

    private void Start() {
        Text = GetComponent<Text>();
    }

    #region TemporaryText

    private void Update() {
        timetilldisable -= Time.deltaTime;

        if (timetilldisable <= 0) {
            gameObject.SetActive(false);
        }
    }

    public StoryText ShowText(string text) {
        Text.text = text;
        return this;
    }

    public StoryText DisableAfterTime(float time) {
        timetilldisable = time;
        return this;
    }

    public void Enable() {
        gameObject.SetActive(true);
    }

    #endregion
    #region TypeWriter

    public StoryText PrintText(string text) {
        var Typewriter = GetComponent<Typewriter>();
        Typewriter.enabled = true;
        Typewriter.Loop = false;
        Typewriter.AutoDisable = false;
        Typewriter.PrintText(text);

        return this;
    }

    #endregion
    #region FadeText
    public StoryText SetFade(bool fade) {
        var fadeText = GetComponent<FadeText>();
        fadeText.enabled = fade;
        return this;
    }

    #endregion
}
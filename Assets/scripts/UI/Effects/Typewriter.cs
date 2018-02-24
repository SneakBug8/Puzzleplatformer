using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    Text Text;
    public float TimePerSymbol;
    float timer;
    int curSymbol;
    public bool DrawCursorAtTheEnd;
    public bool Loop;
    public bool AutoDisable = false;
    string TextToDraw;
    private void Start()
    {
        Text = GetComponent<Text>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= TimePerSymbol)
        {
            timer -= TimePerSymbol;
            if (curSymbol < TextToDraw.Length)
            {
                curSymbol++;
            }
        }

        string drawtemp = TextToDraw.Substring(0, curSymbol);
        int drawCursor = Mathf.RoundToInt(0.5f + Mathf.Cos(Time.time * 3.5f) / 2);
        if (DrawCursorAtTheEnd && drawCursor == 1)
        {
            drawtemp += "|";
        }
        else if (DrawCursorAtTheEnd) {
            drawtemp += " ";
        }

        // drawtemp += new string(' ', TextToDraw.Length - curSymbol);
        Text.text = drawtemp;

        if (Loop & curSymbol == TextToDraw.Length) {
            curSymbol = 0;
        }
        else if (AutoDisable && curSymbol == TextToDraw.Length) {
            this.enabled = false;
        }
    }

    public void PrintText(string text)
    {
        TextToDraw = text;
    }
}
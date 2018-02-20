using UnityEngine;
using UnityEngine.UI;

public class Dialog : Interactable {
    public string[] Phrases;

    int curphrase = 0;

    public GameObject SayBubble;
    public Text Text;

    public override void Interact() {
        Say(curphrase);
        curphrase++;
    }

    void Say(int phrase) {
        Text.text = Phrases[phrase];
        SayBubble.SetActive(true);
    }
}
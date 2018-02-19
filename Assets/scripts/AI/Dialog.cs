using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {
    public string[] Phrases;

    int curphrase = 0;

    public GameObject SayBubble;
    public Text Text;

    public void Say() {
        Say(curphrase);
        curphrase++;
    }

    void Say(int phrase) {
        Text.text = Phrases[phrase];
        SayBubble.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == Player.Global.gameObject) {
            Player.Global.Interactions.NearNPC = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject == Player.Global.gameObject) {
            Player.Global.Interactions.NearNPC = null;            
        }
    }
}
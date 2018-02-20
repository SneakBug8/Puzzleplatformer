using UnityEngine;

public class Victory : Interactable {
    public override void Interact() {
        LevelController.Global.OnVictory();
    }
}
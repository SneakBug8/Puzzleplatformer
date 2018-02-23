using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewController : MonoBehaviour {
    public ViewPair[] Views;

    [HideInInspector]
    public bool HasActiveView = false;
    private void Update() {
        foreach (var viewpair in Views) {
            if (viewpair.ChangeState) {
                if (Input.GetKeyDown(viewpair.Key)) {
                viewpair.View.SetActive(!viewpair.View.activeSelf);
                HasActiveView = viewpair.View.activeSelf;
                }
            }
            else if (Input.GetKeyDown(viewpair.Key) && !HasActiveView) {
                HasActiveView = true;
                viewpair.View.SetActive(true);
            }
            else if (Input.GetKeyUp(viewpair.Key)) {
                HasActiveView = false;
                viewpair.View.SetActive(false);
            }
        }
    }
}

[System.Serializable]
public class ViewPair {
    public string Name;
    public bool ChangeState = true;
    public KeyCode Key;
    public GameObject View;
}
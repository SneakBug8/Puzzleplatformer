using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ExitButton : MonoBehaviour
    {
        void Start()
        {
            var buttoncomp = gameObject.GetComponent<Button>();
            buttoncomp.onClick.AddListener(OnClick);
        }
        void OnClick()
        {
            Application.Quit();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnClick();
            }
        }
    }
}
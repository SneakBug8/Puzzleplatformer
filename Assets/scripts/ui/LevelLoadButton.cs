using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LevelLoadButton : MonoBehaviour
    {

        public int level;
        void Start()
        {
            var buttoncomp = gameObject.GetComponent(typeof(Button)) as Button;
            buttoncomp.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            if (level >= 0)
            {
                MainController.Global.LoadLevel(level);
            }
            else if (level == -1)
            {
                MainController.Global.LoadLevel();
            }
            else if (level == -2)
            {
                MainController.Global.ReloadLevel();
            }
        }
    }
}
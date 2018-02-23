using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LevelLoadButton : MonoBehaviour
    {
        public Levels level;
        public int CustomLevelId;
        void Start()
        {
            var buttoncomp = gameObject.GetComponent(typeof(Button)) as Button;
            buttoncomp.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            switch (level) {
                case Levels.PreviousLevel:
                    MainController.LoadLevel(MainController.CurrentLevelId - 1);
                    break;
                case Levels.CurrentLevel: 
                    MainController.LoadLevel(MainController.CurrentLevelId);
                    break;
                case Levels.NextLevel:
                    MainController.LoadLevel(MainController.CurrentLevelId + 1);
                    break;
                case Levels.CustomId:
                    MainController.LoadLevel(CustomLevelId);
                    break;
            }
        }
    }

    public enum Levels {
        PreviousLevel, CurrentLevel, NextLevel, CustomId
    }
}
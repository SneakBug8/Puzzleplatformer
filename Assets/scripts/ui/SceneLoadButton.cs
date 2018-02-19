using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class SceneLoadButton : MonoBehaviour
    {

        public string scene;
        void Start()
        {
            var buttoncomp = gameObject.GetComponent(typeof(Button)) as Button;
            buttoncomp.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            SceneManager.LoadScene(scene);
        }
    }
}
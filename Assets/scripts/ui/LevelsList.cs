using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelsList : MonoBehaviour
    {
        public GameObject Button;

        void OnEnable()
        {
            var levels = MainController.Global.levelcount;

            for (int i = 0; i < levels; i++)
            {
                var button = Instantiate(Button);
                button.transform.SetParent(transform, false);

                var btncomponent = button.GetComponent(typeof(Button)) as Button;
                
                btncomponent.onClick.AddListener(delegate {int local_i = i; MainController.Global.LoadLevel(local_i);});

                var textcomponent = button.GetComponentInChildren(typeof(Text)) as Text;
                textcomponent.text = i.ToString();
            }
        }
    }
}
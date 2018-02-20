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
            var MaxLevel = Config.LevelCount;

            for (int i = 0; i < MaxLevel; i++)
            {
                var button = Instantiate(Button);
                button.transform.SetParent(transform, false);

                var btncomponent = button.GetComponent(typeof(Button)) as Button;

                if (MainController.LastUnlockedLevelId >= i)
                {

                    btncomponent.onClick.AddListener(delegate { int local_i = i; MainController.LoadLevel(local_i); });
                }
                else
                {
                    btncomponent.interactable = false;
                }

                var textcomponent = button.GetComponentInChildren(typeof(Text)) as Text;
                textcomponent.text = i.ToString();
            }
        }
    }
}
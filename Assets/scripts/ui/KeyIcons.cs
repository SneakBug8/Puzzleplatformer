using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class KeyIcons : MonoBehaviour
    {
        public GameObject IconPref;
        List<Image> icons = new List<Image>();
        void Start()
        {
            Player.Global.OnKeysChange.AddListener(RenderIcons);
        }

        public void RenderIcons()
        {
            var keys = Player.Global.Keys;

            if (icons.Count < keys.Count)
            {
                for (int i = icons.Count; i < keys.Count; i++)
                {
                    icons.Add(CreateIcon());
                }
            }

            for (int i = 0; i < keys.Count; i++) {
                icons[i].sprite = LevelController.Global.KeySprites[keys[i]];
                icons[i].SetNativeSize();
            }
        }

        public Image CreateIcon()
        {
            var icon = Instantiate(IconPref);
            icon.transform.SetParent(transform);
            
            transform.localScale = new Vector3(1,1,1);

            return icon.GetComponent<Image>();
        }
    }
}
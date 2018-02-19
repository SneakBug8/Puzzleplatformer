using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ActivateButton : MonoBehaviour
    {

        public GameObject[] Objects;
        public bool Switch;
        void Start()
        {
            var buttoncomp = gameObject.GetComponent(typeof(Button)) as Button;
            buttoncomp.onClick.AddListener(OnClick);

            CheckActivation();
        }

        public void CheckActivation()
        {
            if (Objects.Length == 0)
            {
                Destroy(this);
            }
        }

        void OnClick()
        {
            if (Switch)
            {
                foreach (var obj in Objects)
                {
                    obj.SetActive(!obj.activeSelf);
                }
                return;
            }

            foreach (var obj in Objects)
            {
                obj.SetActive(true);
            }
        }
    }
}
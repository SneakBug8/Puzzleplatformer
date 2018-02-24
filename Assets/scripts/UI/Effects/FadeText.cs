using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{

    Text Text;

    public Color Color1;
    public Color Color2;
    [Range(0, 1f)]
    public float FadeSpeed;
    void Start()
    {
        Text = GetComponent<Text>();
    }

    void Update()
    {
        Text.color = Color.Lerp(Color1, Color2, 0.5f + Mathf.Cos(Time.time * FadeSpeed) / 2f);
    }
}

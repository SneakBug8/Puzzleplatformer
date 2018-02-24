using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MapCamera : MonoBehaviour
{
    Camera Camera;
    PostEffect PostEffect;
    public int MapSize = 30;
    private float defSize;

    public GameObject MiniMap;

    bool Active;
    public bool SwitchOnClick;
	public bool PreventPlayerMoving;

    // Use this for initialization
    void Start()
    {
        Camera = GetComponent<Camera>();
        PostEffect = GetComponent<PostEffect>();

        defSize = Camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Active = !Active;
            if (!SwitchOnClick || Active)
            {
                ApplyEffects();
            }
            else
            {
                DisapplyEffects();
            }
        }
        else if (!SwitchOnClick && Input.GetKeyUp(KeyCode.M))
        {
            DisapplyEffects();
        }
    }

    void ApplyEffects()
    {
        Camera.orthographicSize = MapSize;
        MiniMap.SetActive(false);
        PostEffect.enabled = true;
        Player.Global.CanMove = !PreventPlayerMoving;
    }

    void DisapplyEffects()
    {
        Camera.orthographicSize = defSize;
        MiniMap.SetActive(true);
        PostEffect.enabled = false;
        Player.Global.CanMove = true;
    }
}

using UnityEngine;

public class KeyTrigger : Trigger
{
    public KeyCode Key;
    public override bool Active()
    {
        return Input.GetKeyDown(Key);
    }
}
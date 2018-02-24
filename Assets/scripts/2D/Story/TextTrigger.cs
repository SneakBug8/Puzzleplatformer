using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class TextTrigger : MonoBehaviour
{
    public string TextString;
    public StoryText Text;
    public Trigger[] Triggers;

    public LogicalActions LogicalAction;

    public bool ActiveOnce;
    bool activatedPreviously = false;

    private void Update()
    {
        bool activation;

        if (LogicalAction == LogicalActions.Or)
        {
            activation = false;
        }
        else
        {
            activation = true;
        }
        foreach (var trigger in Triggers)
        {
            if (LogicalAction == LogicalActions.Or)
            {
                activation = trigger.Active() || activation;
            }
            else if (LogicalAction == LogicalActions.And)
            {
                activation = trigger.Active() && activation;
            }
        }

        if ((!ActiveOnce || !activatedPreviously) && activation)
        {
            Activate();
            activatedPreviously = true;
        }
    }
    private void Activate()
    {
        Text.PrintText(TextString).SetFade(true).DisableAfterTime(5f).Enable();
    }
}

public enum LogicalActions
{
    Or, And
}
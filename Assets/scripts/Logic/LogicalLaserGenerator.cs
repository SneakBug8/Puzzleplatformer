using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalLaserGenerator : LogicalEnd
{
    public bool AutoRelaunch;
    protected GameObject Laser;
    public bool ChangeState;
	public bool Inverse;

    public override void Process()
    {
        if (ChangeState && Element.Return)
        {
            Laser.SetActive(!Laser.activeSelf);
        }
        else
    	{
			bool active = (!Inverse && Element.Return) || (Inverse && !Element.Return);
            if (!active)
            {
                Laser.SetActive(false);
            }
            else if (active && AutoRelaunch)
            {
                Laser.SetActive(true);
            }
        }
    }
}

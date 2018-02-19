using UnityEngine;

[RequireComponent(typeof(Animator))][RequireComponent(typeof(Collider2D))]
public class LogicalSpikes : LogicalEnd {
    protected Animator Animator;
    bool Hidden;
    public bool AutoShow;
	void Start()
	{
		Animator = GetComponent<Animator>();
	}

    private void OnCollisionEnter2D(Collision2D other) {
        if (!Hidden && other.gameObject == Player.Global.gameObject) {
            Player.Global.Die();
        }
    }

	public override void Process() {
		if (Element.Return) {
            Hidden = true;
			SetTrigger("Hide");
		}
		else if (!Element.Return && AutoShow) {
            Hidden = false;
			SetTrigger("Show");
		}
	}

	public void SetTrigger(string trigger) {
		Animator.SetTrigger(trigger);
	}
}
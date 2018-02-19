using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalSpawner : LogicalEnd
{
    public GameObject Spawned;
    public bool Recreate;
    [HideInInspector]
    public GameObject Instance;
    public override void Process()
    {
        if (Element.Return)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if (!Recreate && Instance != null)
        {
            return;
        }

        if (Recreate && Instance != null && Vector3.Distance(Instance.transform.position, transform.position) < 1)
        {
            return;
        }

        if (Recreate && Instance != null)
        {
            StartCoroutine(FadeAndDestroy(Instance.GetComponent<SpriteRenderer>(), Color.red));
        }

        Instance = Instantiate(Spawned, transform.position, Quaternion.identity);
    }

    IEnumerator FadeAndDestroy(SpriteRenderer renderer, Color fadeto)
    {
        while (true)
        {
            renderer.color = Color.Lerp(renderer.color, fadeto, 0.05f);

            if (renderer.color == fadeto) {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        Destroy(renderer.gameObject);
    }
}

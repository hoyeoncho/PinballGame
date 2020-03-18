using System.Collections;
using UnityEngine;


public class IteratorUtility
{
    public static IEnumerator UpdateAlpha(Renderer renderer, float time, bool isFade)
    {
        Renderer r = renderer;

        float prev = isFade ? 1 : 0;
        float next = isFade ? 0 : 1;

        float currTime = Time.time;
        Color color = r.material.color;
        while (Time.time - currTime <= time)
        {
            color.a = Mathf.Lerp(prev, next, (Time.time - currTime) / time);
            r.material.color = color;

            yield return null;
        }

        color.a = next;
        r.material.color = color;

        yield break;
    }
}

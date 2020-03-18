using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaController : MonoBehaviour
{
    IEnumerator iUpdateAlpha = null;
    bool isFade = true;

    private void Awake()
    {
        iUpdateAlpha = IteratorUtility.UpdateAlpha(GetComponent<Renderer>(), 1f, isFade);
    }


    private void Update()
    {
        if (iUpdateAlpha == null) return;
        if (!iUpdateAlpha.MoveNext())
        {
            isFade = !isFade;
            iUpdateAlpha = IteratorUtility.UpdateAlpha(GetComponent<Renderer>(), 1f, isFade);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public RectTransform recTransform;
    public bool statsToggle = false;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.F1)) statsToggle = !statsToggle;

        if (!statsToggle)
        {
            recTransform.localPosition = new Vector3(-307f, 270f, 0f);
            recTransform.localScale = new Vector3(0.4231645f, 0.4231645f, 0.4231645f);
        }
        else
        {
            ZoomStats();
        }
    }

    private void ZoomStats()
    {
        recTransform.localPosition = Vector3.zero;
        recTransform.localScale = new Vector3(0.72602f, 0.72602f, 0.72602f);
    }
}

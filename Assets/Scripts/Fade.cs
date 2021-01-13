using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public int fadeOffset, fadeDuration;
    public Color fadeColor = new Color(0, 0, 0);
    public bool start, fadeIn;

    private long tStart;
    private bool done;
    private Image img;
    private Action<BaseEventData> cb = null;

    public enum FadeEvent
    {
        NONE, MENU_START_OUT
    }

    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        if (start) fadeFrom(gameObject, fadeIn);
    }

    // Update is called once per frame
    void Update()
    {
        if (done) return;

        float alpha = Mathf.Clamp((time() - tStart) / (float)fadeDuration, 0, 1);

        if (alpha >= 1)
        {
            done = true;
            img.enabled = !fadeIn;
            if(cb != null) cb(null);
        }
        else
        {
            if (fadeIn) alpha = 1 - alpha;
            fadeColor.a = Mathf.Pow(alpha, 3);
            img.color = fadeColor;
        }
    }

    private void doFade(bool fadeIn)
    {
        done = false;
        img.enabled = true;
        this.fadeIn = fadeIn;
        tStart = time() + fadeOffset;
    }

    public void fadeFrom(GameObject obj, bool fadeOut)
    {
        cb = null;
        if (obj)
        {
            EventTrigger et = obj.GetComponent<EventTrigger>();
            if (et) cb = et.OnSubmit;
        }

        doFade(fadeOut);
    }


    public void FadeOut(BaseEventData ev) { 
        fadeFrom(((PointerEventData)ev).pointerEnter, false);
    }
    public void FadeIn(BaseEventData ev) { 
        fadeFrom(((PointerEventData)ev).pointerEnter, true);
    }

    private static int time() { return (int)(DateTime.Now.Ticks / (int)1e4); }
}

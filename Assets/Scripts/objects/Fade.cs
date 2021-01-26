using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public int fadeOffset, fadeDuration, darkenOffset, darkenDuration;
    public float fadeRange, darkenRange;
    public Color fadeColor = new Color(0, 0, 0);
    public bool start, fadeIn, fadeAudio;

    private int duration, offset;
    private long tStart;
    private Image img;
    private Action<BaseEventData> cb = null;
    private float range;
    private bool done, reEnableDnD = false, reEnableBtns = false;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        if (start) fadeFrom(gameObject, fadeIn, fadeOffset, fadeDuration, fadeRange);
    }

    // Update is called once per frame
    void Update()
    {
        if (done) return;

        float alpha = Mathf.Clamp((time() - tStart) / (float)duration, 0, 1);

        if (alpha >= 1)
        {
            done = true;
            img.enabled = !fadeIn;
            if(cb != null) cb(null);
        }
        else
        {
            if (fadeIn) alpha = 1 - alpha;
            fadeColor.a = range * Mathf.Pow(alpha, 3);
            img.color = fadeColor;
        }
        if(fadeAudio) Globals.player.scaleAllVolumes(1-alpha);
    }

    private void doFade(bool fadeIn)
    {
        done = false;
        img.enabled = true;
        this.fadeIn = fadeIn;
        tStart = time() + offset;
    }

    private void fadeFrom(GameObject obj, bool fadeOut, int off, int dur, float rng)
    {
        if (!obj) return;
        cb = null;
        
        EventTrigger et = obj.GetComponent<EventTrigger>();
        if (et) cb = et.OnSubmit;

        offset = off;
        duration = dur;
        range = rng;

        doFade(fadeOut);
    }

    public void enableThings() {
        ButtonHandler.buttonsActive = reEnableBtns;
        Ball.staticDnDEnable = reEnableDnD;
    }

    public void disableThings() {
        reEnableBtns = ButtonHandler.buttonsActive;
        ButtonHandler.buttonsActive = false;
        reEnableDnD = Ball.staticDnDEnable;
        Ball.staticDnDEnable = false;
    }


    public void FadeOut(BaseEventData  ev) {
        fadeFrom(Button.getLast(ev), false, fadeOffset, fadeDuration, fadeRange);
    }
    public void FadeIn(BaseEventData ev) {
        fadeFrom(Button.getLast(ev), true, fadeOffset, fadeDuration, fadeRange);
    }

    public void DarkenOut(BaseEventData ev) {
        fadeFrom(Button.getLast(ev), false, darkenOffset, darkenDuration, darkenRange);
    }
    public void DarkenIn(BaseEventData ev) {
        fadeFrom(Button.getLast(ev), true, darkenOffset, darkenDuration, darkenRange);
    }

    private static int time() { return (int)(DateTime.Now.Ticks / (int)1e4); }
}

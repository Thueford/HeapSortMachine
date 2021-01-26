
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public static GameObject lastBtnDown { get; private set; }
    public static GameObject lastBtnOver { get; private set; }
    public static GameObject lastBtnHolder { get; private set; }

    private void Start()
    {
        //Debug.Log("Mecha Start");

        EventTrigger et = GetComponent<EventTrigger>();
        if (et == null) et = gameObject.AddComponent<EventTrigger>();

        et.triggers.Add(newEventEntry(EventTriggerType.PointerDown, OnMouseDown));
        et.triggers.Add(newEventEntry(EventTriggerType.PointerUp, OnMouseUp));
        et.triggers.Add(newEventEntry(EventTriggerType.PointerEnter, OnMouseEnter));
        et.triggers.Add(newEventEntry(EventTriggerType.PointerExit, OnMouseExit));

        if(transform.parent.gameObject.name == "ButtonHolder")
        {
            et.triggers.Add(newEventEntry(EventTriggerType.PointerDown, OnHolderMouseDown));
            et.triggers.Add(newEventEntry(EventTriggerType.PointerUp, OnHolderMouseUp));
        }

        // make sure added events are triggered before user defined
        et.triggers.Reverse();
    }

    private static EventTrigger.Entry newEventEntry(EventTriggerType id, params UnityAction<BaseEventData>[] events)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = id;
        entry.callback = new EventTrigger.TriggerEvent();

        foreach (UnityAction<BaseEventData> cb in events)
        {
            UnityAction<BaseEventData> call = new UnityAction<BaseEventData>(cb);
            entry.callback.AddListener(call);
        }
        return entry;
    }

    public static GameObject getLast(BaseEventData ev, bool checkBtn = true)
    {
        if(checkBtn) { 
            if (lastBtnDown) return lastBtnDown;
            if (lastBtnOver) return lastBtnOver;
        }

        PointerEventData ped = (PointerEventData)ev;
        if (ped.pointerPress) return ped.pointerPress;
        if (ped.pointerEnter) return ped.pointerEnter;
        if (ped.pointerPressRaycast.gameObject) return ped.pointerPressRaycast.gameObject;
        return null;
    }

    public static void OnMouseDown(BaseEventData ev)
    {
        lastBtnDown = getLast(ev, false);
        if (lastBtnDown) lastBtnDown.GetComponent<Image>().rectTransform.localScale = new Vector3(0.9f, 0.9f, 0);
    }

    public static void OnMouseUp(BaseEventData ev)
    {
        if (!lastBtnDown) return;
        lastBtnDown.GetComponent<Image>().rectTransform.localScale = new Vector3(1, 1, 0);
        lastBtnDown = null;
    }

    public static void OnMouseEnter(BaseEventData ev)
    {
        lastBtnOver = getLast(ev, false);
        if (lastBtnOver) lastBtnOver.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
    }

    public static void OnMouseExit(BaseEventData ev)
    {
        if (!lastBtnOver) return;
        if (lastBtnOver) lastBtnOver.GetComponent<Image>().color = Color.white;
        lastBtnOver = null;
    }

    public void OnHolderMouseDown(BaseEventData ev)
    {
        lastBtnHolder = getLast(ev, false);
        if (lastBtnHolder) lastBtnHolder.GetComponent<Image>().sprite = ButtonHandler.self.sprHolderDown;
    }

    public void OnHolderMouseUp(BaseEventData ev)
    {
        if (!lastBtnHolder) return;
        if (lastBtnHolder) lastBtnHolder.GetComponent<Image>().sprite = ButtonHandler.self.sprHolderUp;
        lastBtnHolder = null;
    }

    
}

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private static GameObject lastBtnDown, lastBtnOver, lastBtnHolder;

    private void Start()
    {
        Debug.Log("Mecha Start");

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
    }

    private static EventTrigger.Entry newEventEntry(EventTriggerType id, params UnityEngine.Events.UnityAction<BaseEventData>[] events)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = id;
        entry.callback = new EventTrigger.TriggerEvent();
        foreach (UnityEngine.Events.UnityAction<BaseEventData> cb in events)
        {
            UnityEngine.Events.UnityAction<BaseEventData> call = new UnityEngine.Events.UnityAction<BaseEventData>(cb);
            entry.callback.AddListener(call);
        }
        return entry;
    }

    public static void OnMouseDown(BaseEventData ev)
    {
        lastBtnDown = ((PointerEventData)ev).pointerEnter;
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
        lastBtnOver = ((PointerEventData)ev).pointerEnter;
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
        lastBtnHolder = ((PointerEventData)ev).pointerEnter;
        if (lastBtnHolder) lastBtnHolder.GetComponent<Image>().sprite = ButtonHandler.self.sprHolderDown;
    }

    public void OnHolderMouseUp(BaseEventData ev)
    {
        if (!lastBtnHolder) return;
        if (lastBtnHolder) lastBtnHolder.GetComponent<Image>().sprite = ButtonHandler.self.sprHolderUp;
        lastBtnHolder = null;
    }
}

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private static GameObject lastBtn;

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
        //lastBtn = ((PointerEventData)ev).pointerEnter;
        if (lastBtn) lastBtn.GetComponent<Image>().rectTransform.localScale = new Vector3(0.9f, 0.9f, 0);
    }

    public static void OnMouseUp(BaseEventData ev)
    {
        if (lastBtn) lastBtn.GetComponent<Image>().rectTransform.localScale = new Vector3(1, 1, 0);
    }

    public static void OnMouseEnter(BaseEventData ev)
    {
        lastBtn = ((PointerEventData)ev).pointerEnter;
        if (lastBtn) lastBtn.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
    }

    public static void OnMouseExit(BaseEventData ev)
    {
        if (lastBtn) lastBtn.GetComponent<Image>().color = Color.white;
    }

    public void OnHolderMouseDown(BaseEventData ev)
    {
        //lastBtn = ((PointerEventData)ev).pointerEnter;
        if (lastBtn) lastBtn.GetComponent<Image>().sprite = ButtonHandler.self.sprHolderDown;
    }

    public void OnHolderMouseUp(BaseEventData ev)
    {
        if (lastBtn) lastBtn.GetComponent<Image>().sprite = ButtonHandler.self.sprHolderUp;
    }
}

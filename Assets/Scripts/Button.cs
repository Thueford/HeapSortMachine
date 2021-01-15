using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private static GameObject lastBtnDown, lastBtnOver, lastBtnHolder;
    public Dialogue dialogue;

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

    public void dialogueButton(int N)
    {
        dialogue.Hilfe1_1();
        if (N == 1) 
        {
            dialogue.Hilfe1_1();
        }
        if (N == 2)
        { 
            dialogue.Hilfe1_2();
        }
        if (N == 3)
        {
            
           dialogue.Hilfe2_1(); 
        }
        if (N == 4)
        { 
         dialogue.Hilfe2_2(); 
        }
        if (N == 5)
        { 
         dialogue.Hilfe2_3(); 
        }
        if (N == 6)
        {
            dialogue.Test_1_1();
        }
        if (N == 7)
        {
            dialogue.Test_1_2();
        }
        if (N == 8)
        {
            dialogue.Test_2_1();
        }
        if (N == 9)
        {
            dialogue.Test_2_2();
        }
        if (N == 10)
        {
            dialogue.Test_2_3();
        }
        else
        {
            Debug.Log("whats the stage");
        }
       
    }
}

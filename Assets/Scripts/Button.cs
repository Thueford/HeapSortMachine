using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        GetComponent<EventTrigger>().GetComponent<IPointerDownHandler>().OnPointerDown(null);
    }

    void OnMouseOver()
    {
        Debug.Log("Sprite Clicked");
        GetComponent<EventTrigger>().GetComponent<IPointerDownHandler>().OnPointerDown(null);
    }
}

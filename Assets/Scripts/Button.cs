using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

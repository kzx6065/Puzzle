using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseTest : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        print("Begin" + eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("Drag" + eventData);
        transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("End" + eventData);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class Interactivity : MonoBehaviour
{
    public void PointerClick(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        if (pointerEventData != null && pointerEventData.button == PointerEventData.InputButton.Left)
        {
            ExecuteEvents.ExecuteHierarchy(gameObject, eventData, ExecuteEvents.pointerClickHandler);
        }
    }
}
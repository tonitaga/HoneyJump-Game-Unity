using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerUpPlatform : MonoBehaviour, IPointerUpHandler
{

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer Up");
    }
}

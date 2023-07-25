using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectInstansiatorAtPoint : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject instantiatingObject;

    [SerializeField]
    private uint maxInstances;
    private uint currentInstances = 0;

    private void Start()
    {
        currentInstances = maxInstances;
        RefreshInstancesCountUI();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentInstances-- == 0)
            return;
        RefreshInstancesCountUI();
        Vector3 instansiate_position = Camera.main.ScreenToWorldPoint(eventData.position);
        instansiate_position.z = instantiatingObject.transform.position.z;
        Instantiate(instantiatingObject, instansiate_position, Quaternion.identity);
    }

    private void RefreshInstancesCountUI()
    {
        GetComponentInChildren<TextMeshProUGUI>().text
            = "×" + currentInstances.ToString();
    }
}

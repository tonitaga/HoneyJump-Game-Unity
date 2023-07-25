using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject instantiatingObject;

    [SerializeField]
    private int maxInstances;
    [SerializeField]
    private int currentInstances = 0;

    private GameObject platform;

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text
            = "×" + maxInstances.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentInstances++ >= maxInstances)
            return;
        Vector3 instansiate_position = Camera.main.ScreenToWorldPoint(eventData.position);
        instansiate_position.z = instantiatingObject.transform.position.z;
        platform = Instantiate(instantiatingObject, instansiate_position, Quaternion.identity);
        var platformManager = platform.GetComponent<PlatformManager>();
        platformManager.Slot = gameObject;
        int result = maxInstances - currentInstances;
        GetComponentInChildren<TextMeshProUGUI>().text
            = "×" + result.ToString();
    }

    public void OnPlatformDestroyed()
    {
        Debug.Log("Entered OnPlatformDestroyed");
        currentInstances--;
    }
}
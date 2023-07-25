using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour, IButton
{
    [SerializeField]
    private ButtonManager ButtonManager;

    public void OnClick()
    {
        ButtonManager.RestartPushButtonReleased();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (ButtonManager == null)
            ButtonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
    }
}

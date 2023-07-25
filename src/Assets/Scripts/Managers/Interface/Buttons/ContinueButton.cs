using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour, IButton
{
    [SerializeField]
    private ButtonManager ButtonManager;

    [SerializeField]
    private GameObject OppositeButton;

    public void OnClick()
    {
        ButtonManager.ContinuePushButtonReleased(gameObject,OppositeButton);
    }

    void Start()
    {
        if(ButtonManager == null)
            ButtonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        if (OppositeButton == null)
            OppositeButton = GameObject.Find("PauseButton"); ;
    }
}

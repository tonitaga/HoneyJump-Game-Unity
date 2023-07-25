using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour, IButton
{
    [SerializeField]
    private ButtonManager ButtonManager;

    [SerializeField]
    private GameObject OppositeButton;

    public void OnClick()
    {
        ButtonManager.PausePushButtonReleased(gameObject, OppositeButton);
    }

    private void Start()
    {
        if (ButtonManager == null)
            ButtonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        if (OppositeButton == null)
            OppositeButton = GameObject.Find("ContinueButton"); ;
    }
}

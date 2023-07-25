using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformModeButton : MonoBehaviour, IButton
{
    [SerializeField]
    private ButtonManager ButtonManager;

    [SerializeField]
    private GameObject OppositeButton;

    public void OnClick()
    {
        ButtonManager.GameModeButton(gameObject, OppositeButton, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (ButtonManager == null)
            ButtonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        if (OppositeButton == null)
            OppositeButton = GameObject.Find("Play"); ;

    }
}

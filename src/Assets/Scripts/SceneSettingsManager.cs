using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettingsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ShowingPanelSettings;

    public static SceneSettingsManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void RestartPushButtonReleased()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
    }

    public void PausePushButtonReleased()
    {
        ShowingPanelSettings.SetActive(true);
        ShowingPanelSettings.GetComponentInParent<Canvas>().sortingOrder = 1;
        Time.timeScale = 0.0f;
    }

    public void ContinuePushButtonReleased()
    {
        ShowingPanelSettings.SetActive(false);
        ShowingPanelSettings.GetComponentInParent<Canvas>().sortingOrder = 0;
        if (Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
    }
}

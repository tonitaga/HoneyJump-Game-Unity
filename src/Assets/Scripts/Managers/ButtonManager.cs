using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private GameManager GameManager;

    public void GameModeButton(GameObject button, GameObject oppositeButton, int index)
    {
        SetActiveButtons(button, oppositeButton);
        GameManager.ChangeGameMode(index);
    }

    public void RestartPushButtonReleased()
    {
        GameManager.LoadScene(SceneManager.GetActiveScene());
    }

    public void PausePushButtonReleased(GameObject button, GameObject oppositeButton)
    {
        SetActiveButtons(button, oppositeButton);
        GameManager.PauseGame();
    }

    public void ContinuePushButtonReleased(GameObject button, GameObject oppositeButton)
    {
        SetActiveButtons(button,oppositeButton);
        GameManager.UnpauseGame();
    }

    // <summary>
    // Активирует или деактивирует кнопку паузы и делает обратное действие с кнопкой продолжения
    // </summary>
    // <param name="state">True активирует кнопку паузы, false активирует кнопку продолжения</param>
    public void SetActiveButtons(GameObject button, GameObject oppositeButton)
    {
        Debug.Log("Entered Changing active buttons");
        button.SetActive(false);
        oppositeButton.SetActive(true);
    }

    private void Start()
    {
        if(GameManager == null)
            GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}

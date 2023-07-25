using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private HoneyBallManager HoneyBall;

    [SerializeField]
    private InterfaceManager Canvas;

    [SerializeField]
    private ButtonManager ButtonManager;

    //private float BallSpawnDelay = 0.5f;

    public void GameOver()
    {
        Debug.Log("Entered Game Over");
    }

    public void WinGame()
    {
        Debug.Log("Congratulations");
    }
    
    /// <summary>
    /// »спользуйте чтобы мен€ть режим игр
    /// </summary>
    // <param name="index">0 - режим расстановки платформ, 1 - режим симул€ции</param>
    public void ChangeGameMode(int index)
    {
        switch (index)
        {
            case 0:
                PlatformMode();
                break;
            case 1:
                SimulationMode();
                break;
            default:
                break;
        }
    }

    private void PlatformMode()
    {
        HoneyBall.ResetBall();
        Canvas.OpenCloseInventory(true);
        var platforms = GameObject.FindGameObjectsWithTag("Platform");
        Debug.Log("Entered simulation mode");
        Debug.Log(platforms.Length);
        foreach (var item in platforms)
        {
            item.GetComponent<PlatformManager>().PlatformMode = true;
        }
    }

    private void SimulationMode()
    {
        HoneyBall.Activate(true);
        Canvas.OpenCloseInventory(false);
        var platforms = GameObject.FindGameObjectsWithTag("Platform");
        Debug.Log("Entered simulation mode");
        Debug.Log(platforms.Length);
        foreach (var item in platforms)
        {
            item.GetComponent<PlatformManager>().PlatformMode = false;
        }
    }

    public void LoadScene(Scene nextScene)
    {
        SceneManager.LoadScene(nextScene.buildIndex);
        if (Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void UnpauseGame()
    {
        if(Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(HoneyBall == null)
            HoneyBall = GameObject.Find("HoneyBall").GetComponent<HoneyBallManager>();
        if (ButtonManager == null)
            ButtonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        if (Canvas == null)
            Canvas = GameObject.Find("Canvas").GetComponent<InterfaceManager>();
        PlatformMode();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GamePauseController : MonoBehaviour
{
    public static bool IsPause = false;
    public static bool IsGameOver = false;
    public static UnityEvent OnPauseOn = new UnityEvent();
    public static UnityEvent OnPauseOff = new UnityEvent();
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public EnemySpawnController EnemySpawnController;

    private void Awake()
    {
        OnPauseOn.AddListener(StopTime);
        OnPauseOn.AddListener(EnablePauseMenu);
        OnPauseOff.AddListener(ResumeTheFlowOfTime);
        OnPauseOff.AddListener(DisablePauseMenu);        
    }

    private void Start()
    {
        GameOverMenu.SetActive(false);
        PauseMenu.SetActive(false);
        IsPause = false;
        IsGameOver = false;
    }

    private void Update()
    {
        if (IsGameOver)
        {
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause(!IsPause);
        }
        if(EnemySpawnController != null)
        {
            if(EnemySpawnController.TotalEnemyCount == PlayerResourceController.FragsCount && Time.time > 5f)
                IsGameOver = true;
        }
    }

    private void StopTime()
    {        
        Time.timeScale = 0f;
    }

    private void ResumeTheFlowOfTime()
    {
        Time.timeScale = 1.0f;
    }

    private void EnablePauseMenu()
    {
        PauseMenu.SetActive(true);
    }

    private void DisablePauseMenu()
    {
        PauseMenu.SetActive(false);
    }

    public static void SetPause(bool value)
    {
        IsPause = value;
        if (IsPause)
            OnPauseOn?.Invoke();
        else
            OnPauseOff?.Invoke();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main menu", LoadSceneMode.Single);
    }
}
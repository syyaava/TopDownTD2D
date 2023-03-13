using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class GamePauseController : MonoBehaviour
{
    public static bool IsPause = false;
    public static UnityEvent OnPauseOn = new UnityEvent();
    public static UnityEvent OnPauseOff = new UnityEvent();
    public GameObject PauseMenu;

    private void Awake()
    {
        OnPauseOn.AddListener(StopTime);
        OnPauseOn.AddListener(EnablePauseMenu);
        OnPauseOff.AddListener(ResumeTheFlowOfTime);
        OnPauseOff.AddListener(DisablePauseMenu);        
    }

    private void Start()
    {
        PauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause(!IsPause);
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
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TimeChanger : MonoBehaviour
{
    public List<TimeChangeButton> TimeChangeButtons = new List<TimeChangeButton>();
    public TimeScaleController TimeScaleController;
    public Color selectedTimeScaleColor;
    public Color defaultTimeScaleColor;

    private TimeChangeButton currentPressedButton;

    private void Start()
    {
        var currentTimeScale = TimeScaleController.TimeScale;
        var activeButton = TimeChangeButtons.FirstOrDefault(x => x.TimeScale == currentTimeScale);
        if (activeButton == null)
            throw new MissingComponentException($"Button with time scale = {currentTimeScale} not found.");
        
        SetCurrentActiveTimeScaleButton(activeButton);
    }

    private void SetCurrentActiveTimeScaleButton(TimeChangeButton activeButton)
    {
        foreach (var button in TimeChangeButtons)
        {
            button.IsActive = false;
            button.GetComponent<Button>().image.color = defaultTimeScaleColor;
        }
        activeButton.IsActive = true;
        activeButton.GetComponent<Button>().image.color = selectedTimeScaleColor;
        currentPressedButton = activeButton;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            var index = TimeChangeButtons.IndexOf(currentPressedButton);
            if (index >= TimeChangeButtons.Count - 1)
                ChangeTimeScale(TimeChangeButtons[0]);
            else
                ChangeTimeScale(TimeChangeButtons[index + 1]);
        }
    }

    public void ChangeTimeScale(TimeChangeButton button)
    {
        var pressedButton = TimeChangeButtons.FirstOrDefault(x => x.TimeScale == button.TimeScale);
        if (pressedButton == null)
            return;

        TimeScaleController.SetupTimeScale(pressedButton.TimeScale);
        SetCurrentActiveTimeScaleButton(pressedButton);
    }
}

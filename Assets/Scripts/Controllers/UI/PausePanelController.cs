using Enums;
using Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelController : MonoBehaviour
{
    public void ClosePausePanel()
    {
        UISignals.Instance.onClosePanel?.Invoke(UIPanels.PausePanel);
        Time.timeScale = 1f;
    }
    public void MainMenuBtn()
    {
        Time.timeScale = 1f;

        UISignals.Instance.onClosePanel?.Invoke(UIPanels.PausePanel);
        UISignals.Instance.onOpenPanel?.Invoke(UIPanels.StartPanel);
        UISignals.Instance.onClosePanel?.Invoke(UIPanels.LevelPanel);
        CoreGameSignals.Instance.onRestartLevel?.Invoke();

    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}

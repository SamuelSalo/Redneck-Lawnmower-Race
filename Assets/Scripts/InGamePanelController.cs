using UnityEngine;

public class InGamePanelController : MonoBehaviour
{
    #region Variables
    //Controls the ingame panels
    public GameObject FinishPanel;
    public GameObject PausePanel;
    public GameObject InGameUIPanel;
    public GameObject OptionsPanel;
    public GameObject QuitConfirmPanel;
    public GameObject FailPanel;
    #endregion
    #region Methods
    public void Finish ()
    {
        InGameUIPanel.SetActive(false);
        FinishPanel.SetActive(true);
    }
    public void Pause (bool val)
    {
        PausePanel.SetActive(val);
        InGameUIPanel.SetActive(!val);
    }
    public void Options (bool val)
    {
        OptionsPanel.SetActive(val);
        PausePanel.SetActive(!val);
    }
    public void QuitConfirm (bool val)
    {
        QuitConfirmPanel.SetActive(val);
        PausePanel.SetActive(!val);
    }
    public void Fail ()
    {
        FailPanel.SetActive(true);
        InGameUIPanel.SetActive(false);
    }
    #endregion
}

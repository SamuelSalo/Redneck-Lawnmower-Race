using UnityEngine;

public class PanelController : MonoBehaviour
{
    #region Variables
    //Controls the main menu panels
    public GameObject MainPanel;
    public GameObject OptionsPanel;
    public GameObject LevelPanel;
    public GameObject QuitConfirmPanel;
    #endregion
    #region Methods
    public void Options (bool val)
    {
        MainPanel.SetActive(!val);
        OptionsPanel.SetActive(val);
    }
    public void LevelSelect (bool val)
    {
        MainPanel.SetActive(!val);
        LevelPanel.SetActive(val);
    }
    public void QuitConfirm (bool val)
    {
        MainPanel.SetActive(!val);
        QuitConfirmPanel.SetActive(val);
    }
    #endregion
}

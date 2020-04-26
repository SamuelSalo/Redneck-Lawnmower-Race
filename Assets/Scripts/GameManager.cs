using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class GameManager : MonoBehaviour
{
    #region Variables
    public float timer = 0.0f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI finishTimeText;
    public InGamePanelController panelController;
    public SceneController sceneController;
    private bool runTimer = false;
    public Rigidbody playerRb;
    public LawnmowerLogic playerLogic;
    public GameLogic gameLogic;
    #endregion
    #region Monobehaviour Callbacks
    private void Start()
    {
        StartCoroutine(Countdown());
    }
    public void FixedUpdate ()
    {
        if(runTimer)
        {
            timer += Time.fixedDeltaTime;
            timerText.text = timer.ToString("0.00");
        }
    }
    #endregion
    #region Methods
    public void Crash ()
    {
        runTimer = false;
        playerLogic.Crash();
        panelController.Fail();
        gameLogic.enabled = false;
    }
    public void Finish ()
    {
        runTimer = false;

        if (timer < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "Time"))
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Time", timer);

        finishTimeText.text = $"Your time was {timer.ToString("0.00")} seconds!";
        panelController.Finish();
        gameLogic.enabled = false;
        playerLogic.Crash();
    }
    public void Pause ()
    {
        Time.timeScale = 0f;
        panelController.Pause(true);
    }
    public void UnPause ()
    {
        Time.timeScale = 1f;
        panelController.Pause(false);
    }
    #endregion
    #region Coroutines
    private IEnumerator Countdown()
    {
        playerRb.constraints = RigidbodyConstraints.FreezeAll;
        countdownText.enabled = true;
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        runTimer = true;
        playerRb.constraints = RigidbodyConstraints.None;
        countdownText.enabled = false;
    }
    #endregion
}
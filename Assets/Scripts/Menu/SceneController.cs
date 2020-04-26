using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneController : MonoBehaviour
{
    #region Variables
    //This script controls fading in and out of scenes, and exiting the application.
    public void Quit () => Application.Quit();
    public void FadeToLevel(string name) => StartCoroutine(FadeOut(name));
    #endregion
    #region Coroutines
    private IEnumerator FadeOut (string name)
    {
        Time.timeScale = 1f;
        //Set fadeout animation, wait until it finishes and load determined level
        GameObject.FindWithTag("Fader").GetComponent<Animator>().SetTrigger("fadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(name);
    }
    #endregion
}
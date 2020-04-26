using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameBestTimeText : MonoBehaviour
{
    //Shows "New Best!" flashing text in finish screen if best time was beaten in level
    void Start()
    {
        transform.gameObject.SetActive(GameObject.FindWithTag("GameManager")
            .GetComponent<GameManager>().timer > PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "Time"));
    }
}

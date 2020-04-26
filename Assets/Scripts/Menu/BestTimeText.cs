using UnityEngine;
using TMPro;

public class BestTimeText : MonoBehaviour
{
    //Loads saved best time for level in level select and adds it into a ui text component
    public string levelName;
    private void Start ()
    {
        GetComponent<TextMeshProUGUI>().text = "Best time: " + (PlayerPrefs.GetFloat(levelName + "Time") == 0.00f ? "N/A" : PlayerPrefs.GetFloat(levelName + "Time").ToString("0.00"));
    }
}

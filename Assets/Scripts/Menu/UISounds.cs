using UnityEngine;

public class UISounds : MonoBehaviour
{
    //Plays a ui sound on demand
    public void PlayBlip () => GetComponent<AudioSource>().Play();
}

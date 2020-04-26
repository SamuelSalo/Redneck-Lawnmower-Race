using UnityEngine;

public class GameLogic : MonoBehaviour
{
    #region Variables
    private GameManager gameManager => GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    #endregion
    #region MonoBehaviour Callbacks
    private void OnCollisionEnter (Collision col)
    {
        //End game if player crashes
        if (col.transform.CompareTag("Obstacle"))
        {
            gameManager.Crash();
        }
    }
    private void OnTriggerEnter (Collider col)
    {
        //Finish game when finishline is crossed
        if (col.transform.CompareTag("Finish"))
        {
            gameManager.Finish();
        }
        //End game if player crashes
        if (col.transform.CompareTag("Obstacle"))
        {
            gameManager.Crash();
        }
    }
    #endregion
}

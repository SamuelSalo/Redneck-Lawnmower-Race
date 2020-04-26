using UnityEngine;

public class LawnmowerTouchControls : MonoBehaviour
{
    #region Variables
    private LawnmowerLogic lawnmowerLogic;
    private int steerDirection = 1;
    private bool steer;
    #endregion
    #region MonoBehaviour Callbacks
    private void Start ()
    {
        lawnmowerLogic = GetComponent<LawnmowerLogic>();
    }
    private void FixedUpdate()
    {
        //Steer lawnmower based on steering direction and stop steering when player stops pressing
        lawnmowerLogic.steerDirection = Mathf.Lerp(lawnmowerLogic.steerDirection, steer ? steerDirection : 0f, 0.1f);
    }
    #endregion
    #region Methods
    public void UiTouchUp ()
    {
        steer = false;
        //Switch steer target direction depending on what it currently is
        steerDirection = steerDirection == 1 ? -1 : 1;
    }
    public void UiTouchDown ()
    {
        steer = true;
    }
    #endregion
}
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
//AxleInfo class to hold information about wheelaxles, not needed in this usecase but simplifies things
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
public class LawnmowerLogic : MonoBehaviour {

    #region Variables
    public List<AxleInfo> axleInfos; 
    public float maxMotorTorque;
    public float steerTorque => maxMotorTorque * 0.75f;
    public float maxSteeringAngle;
    public bool driving = true;
    public float steerDirection = 0.0f;

    public Animator characterAnimator;
    #endregion
    #region Monobehaviour Callbacks
    private void FixedUpdate()
    {
        //Apply motor torque and steering controller by controller script
        //Slow down while turning
        var motor = (steerDirection != 0 ? maxMotorTorque : steerTorque) * (driving ? 1f : 0f);
        var steering = maxSteeringAngle * steerDirection;

        //Find all applyable wheels and apply variables
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            //Update visual wheel mesh rotations
            UpdateWheelMeshes(axleInfo.leftWheel);
            UpdateWheelMeshes(axleInfo.rightWheel);
        }
        UpdateAnimators();
    }
    private void UpdateAnimators()
    {
        characterAnimator.SetFloat("Steer", steerDirection);
        //characterAnimator.SetFloat("Steer", steerDirection);
    }
    #endregion
    #region Methods
    private void UpdateWheelMeshes(WheelCollider wheel)
    {
        if (wheel.transform.childCount == 0) return;
        //get child of each wheel and apply collider's rotation and position
        var wheelMesh = wheel.transform.GetChild(0);

        wheel.GetWorldPose(out var pos, out var rot);
     
        wheelMesh.transform.position = pos;
        wheelMesh.transform.rotation = rot;
    }
    public void Crash ()
    {
        maxMotorTorque = 0;
        steerDirection = 0;
    }
    #endregion
}
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables
    public Transform target;
    public Vector3 offset;
    public float moveSpeed;
    public float turnSpeed;
    #endregion
    #region Monobehaviour Callbacks
    private void Update()
    {
        //Define target direction vector and look rotation quaternion
        var dir = target.position - transform.position;
        var rot = Quaternion.LookRotation(dir, Vector3.up);

        //Smoothly turn camera
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, turnSpeed * Time.deltaTime);

        //Define target camera position and smoothly move camera to it
        var pos = target.position + target.forward * offset.z + target.right * offset.x + target.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, pos, moveSpeed * Time.deltaTime);
    }
    #endregion
}

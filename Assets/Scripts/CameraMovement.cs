using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{   
    // give camera a target to follow
    public Transform target;
    public float smoothing; // camera track speed

    // camera bounds
    // unused
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Fix camera to player
    void LateUpdate()
    {
        if (transform.position != target.position) {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // set bounds to camera, so it doesnt go off screen
            // unused for now
            // targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            // targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);


            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }

}

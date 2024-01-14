using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform tf;
    public Transform playerTransform;
    [SerializeField] Vector3 offset;
    private void FixedUpdate()
    {
        tf.position = Vector3.Lerp(tf.position, playerTransform.position + offset, Time.fixedDeltaTime * 5f);
    }
}

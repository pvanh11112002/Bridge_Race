using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Khai báo
    [SerializeField] Vector3 offset;
    public Transform tf;                            // It's own pos
    public Transform playerTransform;
    #endregion

    private void FixedUpdate()
    {
        tf.position = Vector3.Lerp(tf.position, playerTransform.position + offset, Time.fixedDeltaTime * 5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Cái này là nháp 
public class DraftCode : MonoBehaviour
{
    #region Khai báo
    [SerializeField] private LayerMask groundLayer;
    public float speed ;
    public FloatingJoystick variableJoystick;
    public Animator anim;
    public Vector3 dir;  
    private string currentAnim;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizon = variableJoystick.Horizontal;
        float vertical = variableJoystick.Vertical;
        dir = new Vector3(horizon * speed, 0, vertical * speed); // Lấy hướng di từ input
                                                                 //rb.velocity = dir;
        transform.rotation = Quaternion.LookRotation(dir);
        Vector3 nextPoint = dir * speed * Time.deltaTime + transform.position;
        //Debug.Log(nextPoint);
        
        ChangeAnim("run");
            //Debug.Log("hihi: " + CanMove(nextPoint, dir));
        transform.position = CheckGround(nextPoint);
        

    }
    public Vector3 CheckGround(Vector3 nextPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 2f, groundLayer))
        {
            return hit.point + Vector3.up * 1.1f;
        }
        return transform.position;
    }
    protected void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(animName);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
}

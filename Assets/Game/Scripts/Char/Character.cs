using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObj
{
    #region Khai báo
    [SerializeField] private LayerMask stairLayer;
    [SerializeField] private LayerMask groundLayer;  
    [SerializeField] private PlayerBricks playerBrickPrefabs;
    [SerializeField] private Transform brickHolder;    
    [HideInInspector]public Stage stage;
    public Vector3 dir;
    public Animator anim;
    private string currentAnim;
    private List<PlayerBricks> playerBricks = new List<PlayerBricks>();
    #endregion
    public int BrickCount => playerBricks.Count;
    protected virtual void Start()
    {
        
    }
    public virtual void OnInit()
    {
        ClearBrick();                                                                   // Clear gạch
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
    public bool CanMove(Vector3 nextPoint)
    {
        // Check màu bậc thang
        // Khác màu thì đổi màu stair
        bool isCanMove = true;
        RaycastHit hit;
        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 2f, stairLayer))
        {
            Stair stair = hit.collider.GetComponent<Stair>();
            if (stair.colorType != colorType && playerBricks.Count > 0)
            {
                stair.ChangeColor(colorType);
                RemoveBrick();
                stage.NewBrick(colorType);
            }
            if (stair.colorType != colorType && playerBricks.Count <= 0 && dir.z > 0)
            {
                isCanMove = false;
            }
        }
        return isCanMove;
    }
    public void AddBrick()
    {
        PlayerBricks playerBrick = Instantiate(playerBrickPrefabs, brickHolder);
        playerBrick.ChangeColor(colorType);
        playerBrick.transform.localPosition = Vector3.up * 0.25f * playerBricks.Count;
        playerBricks.Add(playerBrick);
    }
    public void RemoveBrick()
    {
        if (playerBricks.Count > 0)
        {
            PlayerBricks playerBrick = playerBricks[playerBricks.Count - 1];
            playerBricks.RemoveAt(playerBricks.Count - 1);
            Destroy(playerBrick.gameObject);
        }
    }
    public void ClearBrick()
    {
        for (int i = 0; i < playerBricks.Count; i++)
        {
            Destroy(playerBricks[i]);
        }
        playerBricks.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            Brick brick = other.GetComponent<Brick>();
            if (brick.colorType == colorType)
            {
                brick.OnDespawn();
                AddBrick();
                Destroy(brick.gameObject);

            }
        }
    }
    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(animName);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
}

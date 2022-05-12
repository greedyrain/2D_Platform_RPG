using System;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    PlayerInput input;
    public Rigidbody2D rb;
    private CapsuleCollider2D cc;

    [Header("SlopeCheck")] 
    [SerializeField] private float slopeCheckDistance = 0.5f;
    [SerializeField] private LayerMask groundLayer;
    private float slopeDownAngle;
    private float slopeDonwAngleOld;
    private float slopeSideAngle;
    private Vector2 slopeNormalPerp;
    private bool isOnSlope;

    [SerializeField] private PhysicsMaterial2D noFriction;
    [SerializeField] private PhysicsMaterial2D fullFriction;
 

    public PlayerData playerData;
    public bool isFalling => rb.velocity.y < 0 && !PlayerGroundCheck.Instance.isGround;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        input.EnableGamePlayInputs();
    }

    private void FixedUpdate()
    {
        SlopeCheck();
        if (isOnSlope && !input.Move)
            cc.sharedMaterial = fullFriction;
        
        else if (input.Move)
            cc.sharedMaterial = noFriction;
    }

    /// <summary>
    /// check if the player is on the slope;
    /// </summary>
    private void SlopeCheck()
    {
        SlopeCheckVertical();
    }

    /// <summary>
    /// 平行于接触面的检测；
    /// </summary>
    void SlopeCheckHorizontal()
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(transform.position,Vector2.right,slopeCheckDistance,groundLayer);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(transform.position,-Vector2.right,slopeCheckDistance,groundLayer);
        if (slopeHitFront)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);
        }
        else if (slopeHitBack)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
        }
        else
        {
            slopeSideAngle = 0.0f;
            isOnSlope = false;
        }
    }

    /// <summary>
    /// 垂直接触面的检测；
    /// </summary>
    void SlopeCheckVertical()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, slopeCheckDistance, groundLayer);
        if (hit)
        {
            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;
            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);
            if (slopeDownAngle != slopeDonwAngleOld)
            {
                isOnSlope = true;
            }
            slopeDonwAngleOld = slopeDownAngle;
            Debug.DrawRay(hit.point,slopeNormalPerp,Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
        }
    }

    public void Move(float speed)
    {
        if (input.Move)
        {
            transform.localScale = new Vector3(input.AxisX, 1f, 1f);
            SetVelocityX(speed * input.AxisX);
            //
            // if (PlayerGroundCheck.Instance.isGround && !isOnSlope)
            // {
            //     SetVelocity(new Vector3(speed * input.AxisX,0.0f));
            // }
            // else if (PlayerGroundCheck.Instance.isGround && isOnSlope)
            // {
            //     SetVelocity(new Vector3(speed *slopeNormalPerp.x* -input.AxisX,speed *slopeNormalPerp.y* -input.AxisX));
            // }
            // else if (!PlayerGroundCheck.Instance.isGround)
            // {
            //     SetVelocityX(speed * input.AxisX);
            // }
        }
    }

    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector2(rb.velocity.x, velocityY);
    }
}
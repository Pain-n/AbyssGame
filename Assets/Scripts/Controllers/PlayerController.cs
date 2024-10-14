using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel PlayerData;

    public float GroundCheckOffset;
    public LayerMask GroundMask;
    public float GravityForce;
    private void Awake()
    {
       
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (PlayerData.IsAttacking)
        {
            PlayerData.Direction = Vector2.zero;
        }
        else
        {
            PlayerData.Direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        PlayerData.Animator.SetFloat("XInput", PlayerData.Direction.x);
        PlayerData.Animator.SetFloat("YInput", PlayerData.Direction.y);

        Gravity();
        Falling();
    }

    private void FixedUpdate()
    {
        
    }

    public void JumpForce()
    {
        PlayerData.RB.velocity += Vector3.up * PlayerData.JumpForce;
    }

    public void Jumped()
    {
        PlayerData.IsInAir = true;
    }

    public void Falling()
    {
        PlayerData.Animator.SetBool("Falling", !IsGrounded());
    }

    public bool IsGrounded()
    {
        Vector3 spherePos = new Vector3(PlayerData.RB.position.x, PlayerData.RB.position.y - GroundCheckOffset, PlayerData.RB.position.z);
        if (Physics.CheckSphere(spherePos, 0.1f, GroundMask)) return true;
        return false;
    }

    private void Gravity()
    {
        if (!IsGrounded()) PlayerData.RB.velocity += Vector3.up * GravityForce * Time.deltaTime;
        else if (PlayerData.RB.velocity.y < 0) PlayerData.RB.velocity = new Vector3(PlayerData.RB.velocity.x,-2, PlayerData.RB.velocity.z);
    }
}

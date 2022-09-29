using UnityEngine;

public class ArvidMovement : MonoBehaviour
{
    public Rigidbody controller;
    public Transform cam;
    public int playerIndex;
    
    public float speed = 3f;
    public float originalSpeed;

    public float turnSmoothTime = 2f;
    private float turnSmoothVelocity;

    private void Start()
    {
        Cursor.visible = false;

        originalSpeed = speed;
    }

    void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UnityEditor.EditorWindow.focusedWindow.maximized = !UnityEditor.EditorWindow.focusedWindow.maximized;
            }
        
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                    turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                transform.Translate(moveDir.normalized * speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())
            {
                Jump();
            }

            if (Input.GetMouseButton(1))
            {
                speed = 0f;
            }
            if (!Input.GetMouseButton(1))
            {
                speed = originalSpeed;
            }
        }
    }
    
    private void Jump()
    {
        controller.AddForce(Vector3.up * 200f);
    }
        
    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        bool result =  Physics.SphereCast(transform.position, 0.3f, -transform.up, out hit, 1f);
        return result;
    }
}
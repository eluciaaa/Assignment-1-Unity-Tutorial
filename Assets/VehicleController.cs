using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    private Vector2 movementInput;

    public float impulse;
    public float turnrate;

    public CheckpointController target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnMove(InputValue action)
    {
        movementInput = action.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // forward/backward movement
        rb.AddRelativeForce(movementInput.y * impulse, 0, 0);

        // sideways movement
        rb.AddRelativeForce(0, 0, -movementInput.x * impulse);

        float dx = (Mouse.current.position.x.value - Screen.width / 2) / turnrate;
        float rotationSpeed = 0.05f;

        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx * rotationSpeed, 0);
        }
    }
}

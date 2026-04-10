using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VehicleController : MonoBehaviour
{
    private Vector2 movementInput;

    public float impulse;
    public float turnrate;
    public float starttime;
    public TextMeshProUGUI timelbl;
    public TextMeshProUGUI laplbl;
    public CheckpointController target;
    public CheckpointController firstCheckpoint;
    public int lapCount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starttime = Time.time;

        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;
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

        timelbl.text = string.Format(
            "Current Time: {0:F2}s",
            Time.time - starttime
        );

        laplbl.text = "Current Lap: " + lapCount;
    }
}

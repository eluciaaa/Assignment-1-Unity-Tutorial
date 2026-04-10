using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public CheckpointController next;

    public MeshRenderer left;
    public MeshRenderer right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        VehicleController vehicle = other.gameObject.GetComponent<VehicleController>();

        if (vehicle != null)
        {
            if (vehicle.target == this)
            {
                if (this == vehicle.firstCheckpoint)
                {
                    vehicle.lapCount++;
                    vehicle.starttime = Time.time;
                }
                vehicle.target = next;
                if (next != null)
                {
                    next.left.materials[0].color = Color.red;
                    next.right.materials[0].color = Color.red;
                }

                left.materials[0].color = Color.white;
                right.materials[0].color = Color.white;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

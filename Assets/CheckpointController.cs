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
        Debug.Log("trigger enter " + other.transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

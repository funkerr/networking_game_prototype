using UnityEditor;
using UnityEngine;
using Unity.Netcode;

public class DirtTrailScript : NetworkBehaviour
{
    public float trailWidth = 0.2f; // Width of the trail
    public float minDistance = 0.1f; // Minimum distance between two points on the trail
    public Transform[] wheels; // Array of transforms representing the wheels of the vehicle
    public TrailRenderer _trailRenderer; // Reference to the Line Renderer component

    private Vector3[] positions; // Array to store the trail positions

    void Start()
    {

        _trailRenderer.startWidth = trailWidth;
        _trailRenderer.endWidth = trailWidth;
        positions = new Vector3[0];
    }

    void Update()
    {
        // Check if any of the wheels have moved a significant distance
        bool shouldUpdateTrail = false;
        foreach (Transform wheel in wheels)
        {
            if (Vector3.Distance(wheel.position, positions[positions.Length - 1]) > minDistance)
            {
                shouldUpdateTrail = true;
                break;
            }
        }

        // Update the trail positions if necessary
        if (shouldUpdateTrail)
        {
            UpdateTrailPositions();
        }
    }

    void UpdateTrailPositions()
    {
        // Add the positions of the wheels to the trail
        foreach (Transform wheel in wheels)
        {
            Vector3 wheelPosition = wheel.position;

            // Only add a new position if the distance between the last point and the current wheel position is significant
            if (positions.Length == 0 || Vector3.Distance(wheelPosition, positions[positions.Length - 1]) > minDistance)
            {
                // Add the new position to the trail
                // ArrayUtility.Add(ref positions, wheelPosition);
            }
        }

      
    }
}
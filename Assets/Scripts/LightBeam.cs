using UnityEngine;

public class LightBeam : MonoBehaviour
{
    public float beamLength = 10f; // Length of the light beam

    private LineRenderer lineRenderer;
    private GameObject source; // Reference to the Source game object

    void Start()
    {
        // Find the Source game object dynamically based on its name
        source = GameObject.Find("Source");

        // Ensure the Source game object is found
        if (source == null)
        {
            Debug.LogError("Source game object not found in the scene!");
            return;
        }

        // Create an empty game object for the light beam
        GameObject lightBeamObject = new GameObject("LightBeam");
        lightBeamObject.transform.position = Vector3.zero; // Adjust position as needed

        // Initialize the LineRenderer component on the new LightBeam object
        lineRenderer = lightBeamObject.AddComponent<LineRenderer>();

        // Set up the LineRenderer properties
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // Generate the light beam
        GenerateLightBeam();
    }

    void Update()
    {
        // Update the light beam in case the Source object moves or rotates
        //GenerateLightBeam();
    }

    void GenerateLightBeam()
    {
        // Calculate the origin position based on the Source block's position and rotation
        Vector3 origin = source.transform.position + new Vector3(0f, 0.5f, 0f);
        Quaternion rotation = Quaternion.Euler(0f, source.transform.rotation.eulerAngles.y, 0f);
        Vector3 direction = rotation * Vector3.forward;

        // Calculate the end position of the light beam
        Vector3 endPosition = origin + direction * beamLength;

        // Set the positions for the LineRenderer
        lineRenderer.SetPosition(0, origin);
        lineRenderer.SetPosition(1, endPosition);
    }
}

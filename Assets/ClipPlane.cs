using UnityEngine;

[ExecuteInEditMode]
public class ClipPlane : MonoBehaviour
{
    public Material targetMaterial;

    void Update()
    {
        if (targetMaterial == null) return;

        // Get the plane's forward facing direction (Normal)
        Vector3 normal = transform.up; 
        // Get the plane's center position in the world
        Vector3 position = transform.position;

        // Send data to the shader
        targetMaterial.SetVector("_PlaneNormal", new Vector4(normal.x, normal.y, normal.z, 0));
        targetMaterial.SetVector("_PlanePosition", new Vector4(position.x, position.y, position.z, 1));
    }
}
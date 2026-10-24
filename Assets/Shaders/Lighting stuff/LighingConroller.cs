
using UnityEngine;

public class LightingConroller : MonoBehaviour
{
    [Header("Objects using the Illumination Shader")]
    public Renderer[] targetObjects;

    private const string Ambient = "AmbientEnabled";
    private const string Diffuse = "DiffuseEnabled";
    private const string Specular = "SpecularEnabled";

    private MaterialPropertyBlock propertyBlock;

    void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();
        SetLightingMode(1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetLightingMode(1);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetLightingMode(2);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetLightingMode(3);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            SetLightingMode(4);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            SetLightingMode(5);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            SetLightingMode(6);

        if (Input.GetKeyDown(KeyCode.Alpha7))
            SetLightingMode(7);
    }

    void SetLightingMode(int mode)
    {
        float ambient = 0f;
        float diffuse = 0f;
        float specular = 0f;

        switch (mode)
        {
            case 1: //Nothing
                break;

            case 2: //Ambient
                ambient = 1f;
                break;

            case 3: // Specular
                specular = 1f;
                break;

            case 4: // Ambient + Specular
                ambient = 1f;
                specular = 1f;
                break;

        }

        foreach (Renderer target in targetObjects)
        {
            if (target == null)
                continue;

            target.GetPropertyBlock(propertyBlock);

            propertyBlock.SetFloat(Ambient, ambient);
            propertyBlock.SetFloat(Diffuse, diffuse);
            propertyBlock.SetFloat(Specular, specular);

            target.SetPropertyBlock(propertyBlock);
        }

        Debug.Log("Lighting mode: " + mode);
    }
}

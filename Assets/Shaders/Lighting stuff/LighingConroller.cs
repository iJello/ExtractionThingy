using UnityEngine;
using UnityEngine.InputSystem;

public class LighingConroller : MonoBehaviour
{
    public Renderer[] targetObjects;

    public InputActionReference light1;
    public InputActionReference light2;
    public InputActionReference light3;
    public InputActionReference light4;
    public InputActionReference light5;

    private const string Ambient = "_AmbientEnabled";
    private const string Diffuse = "_DiffuseEnabled";
    private const string Specular = "_SpecularEnabled";
    private const string Wrap = "_WrapEnabled";

    private MaterialPropertyBlock propertyBlock;

    void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();

        GameObject[] objects = GameObject.FindGameObjectsWithTag("LightAffected");
        targetObjects = new Renderer[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            targetObjects[i] = objects[i].GetComponent<Renderer>();
        }

        SetLightingMode(1);
    }

    void OnEnable()
    {
        light1.action.Enable();
        light2.action.Enable();
        light3.action.Enable();
        light4.action.Enable();
        light5.action.Enable();
    }

    void OnDisable()
    {
        light1.action.Disable();
        light2.action.Disable();
        light3.action.Disable();
        light4.action.Disable();
        light5.action.Disable();
    }

    void Update()
    {
        if (light1.action.WasPressedThisFrame())
            SetLightingMode(1);

        if (light2.action.WasPressedThisFrame())
            SetLightingMode(2);

        if (light3.action.WasPressedThisFrame())
            SetLightingMode(3);

        if (light4.action.WasPressedThisFrame())
            SetLightingMode(4);

        if (light5.action.WasPressedThisFrame())
            SetLightingMode(5);
    }

    void SetLightingMode(int mode)
    {
        float ambient = 0f;
        float diffuse = 0f;
        float specular = 0f;
        float wrap = 0f;

        switch (mode)
        {
            case 1: // Nothing
                break;

            case 2: // Ambient
                ambient = 1f;
                break;

            case 3: // Specular
                specular = 1f;
                break;

            case 4: // Ambient + Specular
                ambient = 1f;
                specular = 1f;
                break;

            case 5: // Ambient + Specular + Wrap
                ambient = 1f;
                specular = 1f;
                wrap = 1f;
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
            propertyBlock.SetFloat(Wrap, wrap);

            target.SetPropertyBlock(propertyBlock);
        }

        
    }
}
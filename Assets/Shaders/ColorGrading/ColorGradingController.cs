using UnityEngine;
using UnityEngine.InputSystem;

public class ColorGradingController : MonoBehaviour
{
    public Material gradingMaterial;
    public Texture2D[] luts;

    public InputActionReference lut0;
    public InputActionReference lut1;
    public InputActionReference lut2;
    public InputActionReference lut3;
    private bool contributionEnabled = false;
    private void OnEnable()
    {
        lut0.action.Enable();
        lut1.action.Enable();
        lut2.action.Enable();
        lut3.action.Enable();

        lut0.action.performed += OnLUT0;
        lut1.action.performed += OnLUT1;
        lut2.action.performed += OnLUT2;
        lut3.action.performed += OnLUT3;
    }

    private void OnDisable()
    {
        lut1.action.performed -= OnLUT1;
        lut2.action.performed -= OnLUT2;
        lut3.action.performed -= OnLUT3;

        lut1.action.Disable();
        lut2.action.Disable();
        lut3.action.Disable();
    }
    private void OnLUT0(InputAction.CallbackContext context)
    {

        contributionEnabled = !contributionEnabled;
        gradingMaterial.SetFloat("_Contribution", contributionEnabled ? 1f : 0f);
    }
    private void OnLUT1(InputAction.CallbackContext context)
    {
        SetLUT(0);
    }

    private void OnLUT2(InputAction.CallbackContext context)
    {
        SetLUT(1);
        Debug.Log("Cool");
    }

    private void OnLUT3(InputAction.CallbackContext context)
    {
        SetLUT(2);
        Debug.Log("Warm");
    }

    public void SetLUT(int index)
    {
        if (gradingMaterial == null || luts == null ||
            index < 0 || index >= luts.Length ||
            luts[index] == null)
            return;

        gradingMaterial.SetTexture("_LUT", luts[index]);
    }
}
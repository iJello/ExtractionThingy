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

    private bool LUTToggle = true;
    public float ContributionDefault = 0.05f    ;

    private void OnEnable()
    {
        lut0.action.performed += OnLUT0;
        lut1.action.performed += OnLUT1;
        lut2.action.performed += OnLUT2;
        lut3.action.performed += OnLUT3;

        lut0.action.Enable();
        lut1.action.Enable();
        lut2.action.Enable();
        lut3.action.Enable();
    }

    private void OnDisable()
    {
        lut0.action.performed -= OnLUT0;
        lut1.action.performed -= OnLUT1;
        lut2.action.performed -= OnLUT2;
        lut3.action.performed -= OnLUT3;

        lut0.action.Disable();
        lut1.action.Disable();
        lut2.action.Disable();
        lut3.action.Disable();
    }

    private void OnLUT0(InputAction.CallbackContext context)
    {
        LUTToggle = !LUTToggle;

        if (gradingMaterial != null)
            gradingMaterial.SetFloat(
                "_Contribution",
                LUTToggle ? ContributionDefault : 0f
            );
    }

    private void OnLUT1(InputAction.CallbackContext context)
    {
        if (gradingMaterial != null)
        {
            gradingMaterial.SetFloat("_Contribution", ContributionDefault);
        }
        SetLUT(0);
    }

    private void OnLUT2(InputAction.CallbackContext context)
    {
        if (gradingMaterial != null)
        {
            gradingMaterial.SetFloat("_Contribution", ContributionDefault);
        }
        SetLUT(1);
    }

    private void OnLUT3(InputAction.CallbackContext context)
    {
        if (gradingMaterial != null)
        {
            gradingMaterial.SetFloat("_Contribution", 0.9f);
        }
        SetLUT(2);
    }

    public void SetLUT(int index)
    {
        if (gradingMaterial == null)
        {
            Debug.LogError("Grading Material is not assigned!");
            return;
        }

        if (luts == null || index < 0 || index >= luts.Length || luts[index] == null)
        {
            Debug.LogError("LUT is missing or index is invalid: " + index);
            return;
        }

        gradingMaterial.SetTexture("_LUT", luts[index]);

        Debug.Log("Switched to LUT: " + luts[index].name);
    }
}
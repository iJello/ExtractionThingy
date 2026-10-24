
using UnityEngine;

public abstract class MovesBase : MonoBehaviour
{
    public string moveName;
    public int actionPointCost = 1;

    public abstract void Action(Creature user, Creature target);


    protected virtual void DamageFlash(Creature target, Color elementColor)
    {
        if (target == null)
        {
            return;
        }

        CreatureShaderController shaderController = target.GetComponent<CreatureShaderController>();

        if (shaderController != null)
        {
            shaderController.FlashElement(elementColor);
        }
            
    }
}
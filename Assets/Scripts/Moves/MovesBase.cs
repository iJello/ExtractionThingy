
using UnityEngine;

public abstract class MovesBase : MonoBehaviour
{
    public string moveName;
    public int actionPointCost = 1;
    //1 - 3 low
    //4-6 mid
    // 7+ high
    
    public int aiPriority = 5;
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
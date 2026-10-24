
using UnityEngine;

public class BasicAttack : MovesBase
{
    public int damage = 10;
    public Color typeColor = Color.red;
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        if(target.shaderController != null)
        {
            DamageFlash(target, typeColor);
        }

        Debug.Log(user.name + " used " + moveName);
    }
}
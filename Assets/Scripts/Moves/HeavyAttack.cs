
using UnityEngine;

public class HeavyAttack : MovesBase
{
    public int damage = 30;
    public Color typeColor = Color.purple;
    void Start()
    {
        this.actionPointCost = 3;
    }

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
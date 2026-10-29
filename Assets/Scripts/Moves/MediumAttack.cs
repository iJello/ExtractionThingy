
using UnityEngine;

public class MediumAttack : MovesBase
{
    public int damage = 20;
    public Color typeColor = Color.orange;
    void Start()
    {
        this.actionPointCost = 2;
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
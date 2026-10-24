
using UnityEngine;

public class BasicAttack : MovesBase
{
    public int damage = 10;

    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        Debug.Log(user.name + " used " + moveName);
    }
}

using UnityEngine;

public class BasicFire : MovesBase
{
    public int damage = 10;
    public Color typeColor = Color.orange;
    public Sprite StatusIcon;
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        target.AddStatus(StatusType.Burn, StatusIcon, 2);
        if(target.shaderController != null)
        {
            DamageFlash(target, typeColor);
        }

        Debug.Log(user.name + " used " + moveName);
    }
}

using UnityEngine;

public class EnergyDrain : MovesBase
{
    public int damage = 10;
    public Color typeColor = Color.green;
    public Sprite StatusIcon;
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        user.AddStatus(StatusType.Regen, StatusIcon, 3);
        if(target.shaderController != null)
        {
            DamageFlash(target, typeColor);
        }

        Debug.Log(user.name + " used " + moveName);
    }
}
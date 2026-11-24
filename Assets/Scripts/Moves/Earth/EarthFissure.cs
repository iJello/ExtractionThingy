
using UnityEngine;

public class EarthFissure : MovesBase
{
    public int damage = 50;
    public Color typeColor = Color.brown;
    public Sprite StatusIcon;
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        user.AddStatus(StatusType.FissureDebuff, StatusIcon, 1);
        if(target.shaderController != null)
        {
            DamageFlash(target, typeColor);
        }

        Debug.Log(user.name + " used " + moveName);
    }
}
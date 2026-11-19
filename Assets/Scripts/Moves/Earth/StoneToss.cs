
using UnityEngine;

public class StoneToss : MovesBase
{

    public int damage = 20;
    public Color typeColor = Color.brown;
    public Sprite StatusIcon;
    void Awake()
    {
        moveName = "StoneToss";
    }
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        target.AddStatus(StatusType.StoneTossDebuff, StatusIcon, 1);
        if(target.shaderController != null)
        {
            DamageFlash(target, typeColor);
        }

        Debug.Log(user.name + " used " + moveName);
    }
}
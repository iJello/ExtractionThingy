
using UnityEngine;

public class RushingStream : MovesBase
{

    public int damage = 10;
    public Color typeColor = Color.blue;
    public Sprite StatusIcon;
    void Awake()
    {
        moveName = "RushingStream";
    }
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        user.AddStatus(StatusType.Swiftstream, StatusIcon, 3);
        if(target.shaderController != null)
        {
            DamageFlash(target, typeColor);
        }

        Debug.Log(user.name + " used " + moveName);
    }
}
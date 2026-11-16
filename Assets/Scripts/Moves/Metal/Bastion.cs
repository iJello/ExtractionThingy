
using UnityEngine;

public class Bastion : MovesBase
{

    public int damage = 10;
    public Color typeColor = Color.gray;
    public Sprite StatusIconDefend;
    public Sprite StatusIconRegen;
    void Awake()
    {
        moveName = "Bastion";
    }
    public override void Action(Creature user, Creature target)
    {
        user.AddStatus(StatusType.Defend, StatusIconDefend, 2);
        user.AddStatus(StatusType.Regen, StatusIconRegen, 1);
        user.defensePoints += 3;
        target.TakeDamage(damage);
        
    }
    
}
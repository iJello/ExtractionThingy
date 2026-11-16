
using UnityEngine;

public class ElectroSurge : MovesBase
{

    public int damage = 10;
    public Color typeColor = Color.yellow;
    public Sprite StatusIcon;
    void Awake()
    {
        moveName = "ElectroSurge";
    }
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        if(Chance(0.5f))
        {
            target.AddStatus(StatusType.Paralyze, StatusIcon, 4);
        }
    }
    bool Chance(float chance)
    {
        return Random.value < chance;
    }
}
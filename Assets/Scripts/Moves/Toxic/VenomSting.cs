
using UnityEngine;

public class VenomSting : MovesBase
{

    public int damage = 10;
    public Color typeColor = Color.green;
    public Sprite StatusIcon;
    void Awake()
    {
        moveName = "VenomSting";
    }
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        if(Chance(0.3f))
        {
            target.AddStatus(StatusType.Poison, StatusIcon, 3);
        }
    }
    bool Chance(float chance)
    {
        return Random.value < chance;
    }
}
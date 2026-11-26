
using UnityEngine;

public class FlameBurst : MovesBase
{

    public int damage = 10;
    public Color typeColor = Color.orange;
    public Sprite StatusIcon;
    void Awake()
    {
        moveName = "FlameBurst";
    }
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        if(Chance(0.1f))
        {
            target.AddStatus(StatusType.Burn, StatusIcon, 2);
        }
    }
    bool Chance(float chance)
    {
        return Random.value < chance;
    }
}

using UnityEngine;

public class FieryExplosion : MovesBase
{

    public int damage = 30;
    public Color typeColor = Color.orange;
    public Sprite StatusIcon;
    void Awake()
    {
        moveName = "FireyExplosion";
    }
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        user.TakeDamage(damage/2);
        target.AddStatus(StatusType.Burn, StatusIcon, 3);
    }
    bool Chance(float chance)
    {
        return Random.value < chance;
    }
}
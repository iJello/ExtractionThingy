
using UnityEngine;

public class ThunderStorm : MovesBase
{

    public int damage = 10;
    public Color typeColor = Color.orange;
    public Sprite StatusIcon;
    void Awake()
    {
        moveName = "Thunderstorm";
    }
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        target.AddStatus(StatusType.Paralyze, StatusIcon, 3);
        user.AddStatus(StatusType.Paralyze, StatusIcon, 1);
    }
    bool Chance(float chance)
    {
        return Random.value < chance;
    }
}
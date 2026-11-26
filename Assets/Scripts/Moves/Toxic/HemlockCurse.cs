
using UnityEngine;

public class HemlockCurse: MovesBase
{

    public int damage = 10;
    public int massiveDamage = 50;
    public Color typeColor = Color.green;
    public Sprite StatusIcon;
    void Awake()
    {
        moveName = "VenomSting";
    }
    public override void Action(Creature user, Creature target)
    {
        if(target.HasStatus(StatusType.Poison))
        {
            target.TakeDamage(massiveDamage);
            target.RemoveStatus(StatusType.Poison);
        }
    }
    bool Chance(float chance)
    {
        return Random.value < chance;
    }
}

using UnityEngine;

public class FrostBite : MovesBase
{

    public int damage = 10;
    public Color typeColor = Color.cyan;
    public Sprite StatusIcon;
    void Awake()
    {
        moveName = "FrostBite";
    }
    public override void Action(Creature user, Creature target)
    {
        target.TakeDamage(damage);
        if(Chance(0.25f))
        {
            target.AddStatus(StatusType.Freeze, StatusIcon, 3);
        }
       
    }
    bool Chance(float chance)
    {
        return Random.value < chance;
    }
}
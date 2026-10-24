using UnityEngine;

public abstract class MovesBase : MonoBehaviour
{
    public string moveName;
    public int actionPointCost = 1;

    public abstract void Action(Creature user, Creature target);
}
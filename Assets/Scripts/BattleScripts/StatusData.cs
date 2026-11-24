
using UnityEngine;

[System.Serializable]
public class StatusData
{
    public StatusType type;
    public Sprite icon;
    public int duration;
    public int stacks;

    public StatusData(StatusType type, Sprite icon, int duration)
    {
        this.type = type;
        this.icon = icon;
        this.duration = duration;
        this.stacks = 1;
    }
}

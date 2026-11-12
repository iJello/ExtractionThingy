
using UnityEngine;
using System.Collections.Generic;

public class Creature : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public int block;
    public int defensePoints;
    public Sprite defendIcon;
    //Shader stuff
    public CreatureShaderController shaderController;

    public List<MovesBase> moves = new List<MovesBase>();

    //Statuses
    
    [Header("Status Effects")]
    public List<StatusData> activeStatuses = new List<StatusData>();

    public StatusIconUI statusIconUI;

    private void Awake()
    {
        health = maxHealth;
        if (shaderController == null)
        {
            shaderController = GetComponent<CreatureShaderController>();
        }
    
    }

    public void TakeDamage(int dmg)
    {
  
        float reduction = Mathf.Clamp(defensePoints * 0.10f, 0f, 1f);
        int reducedDamage = Mathf.CeilToInt(dmg * (1f - reduction));

   
        

 
        int absorbed = Mathf.Min(block, reducedDamage);
        block -= absorbed;
        reducedDamage -= absorbed;

        health = Mathf.Max(0, health - reducedDamage);

        Debug.Log($"{name} has {health}/{maxHealth} HP remaining.");
    }

    public void Heal(int healAmount)
    {
        health = Mathf.Min(maxHealth, health + healAmount);
    }

    public void AddBlock(int blockAmount)
    {
        block += Mathf.Max(0, blockAmount);
    }

    public bool IsAlive()
    {
        return health > 0;
    }
    
    public void AddStatus(StatusType type, Sprite icon, int duration)
    {

        StatusData newStatus = new StatusData(type, icon, duration);

        activeStatuses.Add(newStatus);

        UpdateStatusUI();

        Debug.Log(name + " gained " + type);
    }

    public bool HasStatus(StatusType type)
    {
        return activeStatuses.Exists(status => status.type == type);
    }

    public void RemoveStatus(StatusType type)
    {
        activeStatuses.RemoveAll(status => status.type == type);

        UpdateStatusUI();
    }

    public void UpdateStatusUI()
    {
        if (statusIconUI != null)
        {
            statusIconUI.UpdateIcons(activeStatuses);
        }
    }

    public void TickStatuses()
    {
        for (int i = activeStatuses.Count - 1; i >= 0; i--)
        {
            activeStatuses[i].duration--;

            if (activeStatuses[i].duration <= 0)
            {
                Debug.Log(name + " lost " + activeStatuses[i].type);

                activeStatuses.RemoveAt(i);
            }
        }

        UpdateStatusUI();
    }
    //Status Effect Shenanigans

    //To add status target.AddStatus(StatusType.X, StatusIcon, X turns)
    public void ApplyStatusEffects()
    {
        foreach (StatusData status in activeStatuses)
        {
            switch (status.type)
            {
                case StatusType.Poison:
                    TakeDamage(5);
                    Debug.Log(name + " took 5 poison");
                    break;

                case StatusType.Burn:
                    TakeDamage(10);
                    Debug.Log(name + " took 10 burn");
                    break;

                case StatusType.Regen:
                    Heal(5);
                    Debug.Log(name + " regen 5 HP");
                    break;
                
            }
        }
    }


}

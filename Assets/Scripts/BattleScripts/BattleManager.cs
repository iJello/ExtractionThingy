
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Creature player;
    public Creature opponent;

    public Creature currentCreature;
    public Creature targetCreature;

    public int currentAP;

    private int playerBaseAP = 1;
    private int opponentBaseAP = 1;

    private int playerStoredAP = 0;
    private int opponentStoredAP = 0;

    private bool playerTurn = true;

    private void Start()
    {
        currentCreature = player;
        targetCreature = opponent;

        StartTurn();
    }

    public void StartTurn()
    {
        if (playerTurn)
        {
            currentCreature = player;
            targetCreature = opponent;

            currentAP = playerBaseAP + playerStoredAP;
            playerStoredAP = 0;

            // Increase base AP for the next player turn.
            playerBaseAP = Mathf.Min(6, playerBaseAP + 1);
        }
        else
        {
            currentCreature = opponent;
            targetCreature = player;

            currentAP = opponentBaseAP + opponentStoredAP;
            opponentStoredAP = 0;

            // Increase base AP for the next opponent turn.
            opponentBaseAP = Mathf.Min(6, opponentBaseAP + 1);
        }

        Debug.Log(currentCreature.name +
                  "'s turn. AP: " + currentAP);
    }

    //  ATTACK
    public void Attack(MovesBase move)
    {
        if (move == null || currentCreature == null ||
            targetCreature == null)
            return;

        if (!currentCreature.moves.Contains(move))
        {
            Debug.Log("This creature does not know that move.");
            return;
        }

        if (currentAP < move.actionPointCost)
        {
            Debug.Log("Not enough AP!");
            return;
        }

        currentAP -= move.actionPointCost;

        move.Action(currentCreature, targetCreature);

        Debug.Log("Remaining AP: " + currentAP);
    }

    //  DEFEND
    public void Defend(int points)
    {
        if (!CanSpend(points))
            return;

        currentAP -= points;
        currentCreature.defensePoints += points;

        Debug.Log(currentCreature.name +
                  " invested " + points +
                  " AP into defense.");
    }

    //STORE
    public void Store()
    {
        int storedAP = playerTurn ? playerStoredAP : opponentStoredAP;

        // Calculate how many points can still be stored.
        int pointsToStore = Mathf.Min(currentAP, 12 - storedAP);

        if (pointsToStore <= 0)
        {
            Debug.Log("Stored AP is already at its maximum.");
            return;
        }

        currentAP -= pointsToStore;

        if (playerTurn)
            playerStoredAP += pointsToStore;
        else
            opponentStoredAP += pointsToStore;

        Debug.Log("Stored " + pointsToStore + " AP.");
    }
    // HEAL
    public void Heal(int points)
    {
        if (!CanSpend(points))
            return;

        currentAP -= points;

        
        int healAmount = Mathf.CeilToInt(
            currentCreature.maxHealth * 0.05f * points
        );

        currentCreature.Heal(healAmount);

        Debug.Log(currentCreature.name +
                  " healed for " + healAmount + " HP.");
    }

    private bool CanSpend(int points)
    {
        if (points <= 0 || points > currentAP)
        {
            Debug.Log("Invalid AP amount.");
            return false;
        }

        return true;
    }

    public void EndTurn()
    {
        if (player == null || opponent == null)
            return;

        if (!player.IsAlive() || !opponent.IsAlive())
        {
            Debug.Log("Battle is over!");
            return;
        }

        playerTurn = !playerTurn;
        Debug.Log("TurnSwitch");
        StartTurn();
    }
}

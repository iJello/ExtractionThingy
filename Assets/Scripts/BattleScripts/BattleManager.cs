
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public Creature player;
    public Creature opponent;

    //Active Move buttons
    public MoveButton[] moveButtons;
    public GameObject actionButtons;

    public Creature currentCreature;
    public Creature targetCreature;

    public int currentAP;
    private int currentBaseAP;

    private int playerBaseAP = 0;
    private int opponentBaseAP = 0;

    private int playerStoredAP = 0;
    private int opponentStoredAP = 0;

    private bool playerTurn = true;

    //UI stuff
    public Slider playerHealthBar;
    public Slider enemyHealthBar;
    public GameObject PlayerTurnIndicator;
    public GameObject EnemyTurnIndicator;
    public TMP_Text apTurnText;

    private void Awake()
    {
            
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        currentCreature = player;
        targetCreature = opponent;

        StartTurn();
        HandleUI();
    }

    public void StartTurn()
    {
        if (playerTurn)
        {
            currentCreature = player;
            targetCreature = opponent;

            UpdateMoveButtons();
            playerBaseAP = Mathf.Min(6, playerBaseAP + 1);
            currentBaseAP = playerBaseAP;
            currentAP = currentBaseAP + playerStoredAP;
            PlayerTurnIndicator.SetActive(true);
            EnemyTurnIndicator.SetActive(false);
            currentAP = playerBaseAP + playerStoredAP;


            playerStoredAP = 0;
            

            
            //DefendIconStuff
            player.defensePoints = 0;
            player.RemoveStatus(StatusType.Defend); 
            //Check Status
            CheckEarlyStatus();

            
        }
        else
        {
            currentCreature = opponent;
            targetCreature = player;
            UpdateMoveButtons();
            opponentBaseAP = Mathf.Min(6, opponentBaseAP + 1);
            currentBaseAP = opponentBaseAP;
            currentAP = currentBaseAP + opponentStoredAP;
            PlayerTurnIndicator.SetActive(false);
            EnemyTurnIndicator.SetActive(true);
            currentAP = opponentBaseAP + opponentStoredAP;
            opponentStoredAP = 0;

          
            //Defend stuff
            opponent.defensePoints = 0;
            opponent.RemoveStatus(StatusType.Defend);
            //CheckStatuses
            CheckEarlyStatus();
            
        }

        Debug.Log(currentCreature.name +
                  "'s turn. AP: " + currentAP);
    }

    //  ATTACK stuff
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
        HandleUI();
        CheckDead();
    }

    //  DEFEND
    public void Defend(int points)
    {
        if (!CanSpend(points))
            return;

        currentAP -= points;
        currentCreature.defensePoints += points;

        // Add defend icon
        currentCreature.AddStatus(
            StatusType.Defend,
            currentCreature.defendIcon,
            2
        );

        Debug.Log(currentCreature.name +
                  " invested " + points +
                  " AP into defense.");

        HandleUI();
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
        HandleUI();
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

        

        //Store
        if (playerTurn)
        {
            int pointsToStore = Mathf.Min(currentAP, 6 - playerStoredAP);
            playerStoredAP += pointsToStore;
        }
        else
        {
            int pointsToStore = Mathf.Min(currentAP, 6 - opponentStoredAP);
            opponentStoredAP += pointsToStore;
        }
        currentCreature.ApplyStatusEffects();
        currentCreature.TickStatuses();
        Debug.Log(currentCreature.name +
                  " stored remaining AP. Player stored: " +
                  playerStoredAP + ", Opponent stored: " +
                  opponentStoredAP);

        // Switch turns
        playerTurn = !playerTurn;

        Debug.Log("TurnSwitch");

        StartTurn();
        HandleUI();
    }
    public void HandleUI()
    {
        if (player != null && playerHealthBar != null)
        {
            playerHealthBar.maxValue = player.maxHealth;
            playerHealthBar.value = player.health;
        }

        if (opponent != null && enemyHealthBar != null)
        {
            enemyHealthBar.maxValue = opponent.maxHealth;
            enemyHealthBar.value = opponent.health;
        }
        if(playerTurn)
        {
            if (apTurnText != null)
            {
                apTurnText.text = currentAP.ToString() + " AP / " + currentBaseAP.ToString() + " AP";
            }
        }
        else
        {
            if (apTurnText != null)
            {
                apTurnText.text = currentAP.ToString() + " AP/ " + opponentBaseAP.ToString() + " AP" ;
            }
        }
        
    }
    public void CheckDead()
    {
        if (!player.IsAlive() || !opponent.IsAlive())
        {
            Debug.Log("Battle is over!");

            if (!player.IsAlive())
            {
                actionButtons.SetActive(false);
                GameManager.instance.Lose();
            }
            else if (!opponent.IsAlive())
            {
                actionButtons.SetActive(false);
                GameManager.instance.Win();
            }

            return;
        }
    }
    public void UpdateMoveButtons()
    {

        foreach (MoveButton button in moveButtons)
        {
            button.ClearButton();
        }

        for (int i = 0; i < currentCreature.moves.Count; i++)
        {
            if (i >= moveButtons.Length)
                break;

            moveButtons[i].AssignMove(currentCreature.moves[i]);
        }
    }
    public void CheckEarlyStatus()
    {
        if(currentCreature.HasStatus(StatusType.Paralyze))
        {
            currentAP -= 2;
        }
        if(currentCreature.HasStatus(StatusType.FissureDebuff))
        {
            currentAP -= playerBaseAP/2;
        }
        if(currentCreature.HasStatus(StatusType.StoneTossDebuff))
        {
            currentAP -= 1;
        }

    }
}

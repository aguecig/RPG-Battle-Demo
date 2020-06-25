using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogue : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public void InitialEncounterMessage(string enemyName)
    {
        _text.text = "You have encountered a " + enemyName + "!";
    }

    public void DamageEnemyMessage(int damage)
    {
        _text.text = "Inflicted " + damage + " points of damage to the enemy!";
    }

    public void OutOfMagicMessage()
    {
        _text.text = "You are out of magic points!";
    }

    public void RunFromEncounterMessage()
    {
        _text.text = "Got away safely!";
    }

    public void CannotRunFromEncounterMessage()
    {
        _text.text = "Can't run!";
    }

    public void EnemyAbilityMessage(string message)
    {
        StartCoroutine(EnemyAbilityMessageRoutine(message));
    }

    IEnumerator EnemyAbilityMessageRoutine(string message)
    {
        yield return new WaitForSeconds(3);

        _text.text = message;
    }

    public void OnBattleWon()
    {
        _text.text = "You won the battle!";
    }
}

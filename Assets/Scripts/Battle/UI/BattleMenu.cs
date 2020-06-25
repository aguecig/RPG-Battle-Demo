using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleMenu : MonoBehaviour
{
    [SerializeField]
    private bool _canRun = true;
    [SerializeField]
    private bool _playersTurn = true;

    [SerializeField]
    private Player _player;
    [SerializeField]
    private BattleDialogue _battleDialogue;

    [SerializeField]
    private Enemy _enemy;

    void Update()
    {

    }

    public void SetEnemy(string enemy)
    {
        string enemyID = enemy + "(Clone)";
        _enemy = GameObject.Find(enemyID).transform.GetComponent<Enemy>();
    }

    public void Attack()
    {
        if (_playersTurn == true)
        {
            int damage = _player.GetAttackStrength();
            _enemy.TakeDamage(damage);
            _battleDialogue.DamageEnemyMessage(damage);

            StartEnemyTurn();
        }
    }

    public void Magic()
    {
        if (_playersTurn == true)
        {
            int mp = _player.GetMagicPoints();

            if (mp > 0)
            {
                int damage = _player.GetMagicStrength();
                _enemy.TakeDamage(damage);
                _player.LoseMagic(1);
                _battleDialogue.DamageEnemyMessage(damage);

                StartEnemyTurn();
            }
            
            else
            {
                _battleDialogue.OutOfMagicMessage();
            }
        }
    }

    public void Run()
    {
        if (_playersTurn == true)
        {
            if (_canRun == true)
            {
                _battleDialogue.RunFromEncounterMessage();
                StartCoroutine(RunAwayRoutine());
            }

            else
            {
                _battleDialogue.CannotRunFromEncounterMessage();
            }
        }
    }

    IEnumerator RunAwayRoutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Home Town");
    }

    public void AlterRunStatus(bool status)
    {
        _canRun = status;
    }

    public void MakeItPlayersTurn()
    {
        StartCoroutine(PlayersTurnRoutine());
    }

    IEnumerator PlayersTurnRoutine()
    {
        yield return new WaitForSeconds(2);
        _playersTurn = true;
    }

    void StartEnemyTurn()
    {
        _playersTurn = false;

        int enemyHP = _enemy.GetEnemyHP();

        if (enemyHP > 0)
        {
            _enemy.UseAbility();
        }

        else
        {
            _enemy.DestroyEnemy();
            _battleDialogue.OnBattleWon();
            StartCoroutine(ReturnToMapRoutine());
        }
    }

    IEnumerator ReturnToMapRoutine()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Home Town");
    }
}

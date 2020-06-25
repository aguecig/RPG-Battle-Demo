using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _hp;
    [SerializeField]
    private string[] _abilities;

    [SerializeField]
    private Player _player;
    [SerializeField]
    private BattleMenu _battleMenu;
    [SerializeField]
    private BattleDialogue _battleDialogue;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform.GetComponent<Player>();
        _battleMenu = GameObject.Find("Battle Menu").transform.GetComponent<BattleMenu>();
        _battleDialogue = GameObject.Find("Battle Dialogue").transform.GetComponent<BattleDialogue>();
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
    }

    public void UseAbility()
    {
        int abilityIndex = Random.Range(0, 2);

        string abilityName = _abilities[abilityIndex];

        if (transform.tag == "Bat")
        {
            if (abilityName == "Attack")
            {
                _player.TakeDamage(2);
                _battleDialogue.EnemyAbilityMessage("Bat attacked for 2 points of damage!");
            }

            else if (abilityName == "Leer")
            {
                _battleMenu.AlterRunStatus(false);
                _battleDialogue.EnemyAbilityMessage("Bat used Leer...You can no longer escape the battle!");
            }
        }

        else if (transform.tag == "Skull")
        {
            if (abilityName == "Attack")
            {
                _player.TakeDamage(2);
                _battleDialogue.EnemyAbilityMessage("Skull attacked for 2 points of damage!");
            }

            else if (abilityName == "Magic Drain")
            {
                _player.LoseMagic(1);
                _battleDialogue.EnemyAbilityMessage("Skull used Magic Drain and drained 1 point of magic from you!");
            }
        }

        else if (transform.tag == "Wasp")
        {
            if (abilityName == "Attack")
            {
                _player.TakeDamage(1);
                _battleDialogue.EnemyAbilityMessage("Wasp attacked for 1 point of damage!");
            }

            else if (abilityName == "Poison")
            {
                _player.ChangePoisonStatus(true);
                _battleDialogue.EnemyAbilityMessage("Wasp poisoned you with its stinger!");
            }
        }

        _battleMenu.MakeItPlayersTurn();
    }

    public int GetEnemyHP()
    {
        return _hp;
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}

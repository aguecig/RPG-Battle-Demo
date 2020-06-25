using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemies;

    [SerializeField]
    private BattleDialogue _battleDialogue;

    [SerializeField]
    private BattleMenu _battleMenu;

    // Start is called before the first frame update
    void Start()
    {
        int enemyIndex = Random.Range(0, 3);

        Instantiate(_enemies[enemyIndex], new Vector3(6, 3, 0), Quaternion.identity);

        _battleDialogue.InitialEncounterMessage(_enemies[enemyIndex].tag);

        _battleMenu.SetEnemy(_enemies[enemyIndex].tag);
    }
}

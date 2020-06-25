using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    [SerializeField]
    private int _findEnemyProbability = 25;
    [SerializeField]
    private float _enemySearchInterval = 1.0f;
    [SerializeField]
    private float _lastEnemySearchTime = 0.0f;
    [SerializeField]
    private bool _searchingForEnemy = false;

    [SerializeField]
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _searchingForEnemy = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _searchingForEnemy = false;
        }
    }

    public void SearchForEnemy()
    {
        if (_searchingForEnemy == true && Time.time - _lastEnemySearchTime > _enemySearchInterval)
        {
            _lastEnemySearchTime = Time.time;

            int probabilityValue = Random.Range(1, 101);

            if (probabilityValue <= _findEnemyProbability)
            {
                StartCoroutine(TransitonToBattleRoutine());
            }
        }
    }

    IEnumerator TransitonToBattleRoutine()
    {
        Debug.Log("An enemy was found!");
        _player.FoundEnemy();

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(1);
    }
}

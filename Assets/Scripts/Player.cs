using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _hp = 10;
    [SerializeField]
    private int _mp = 4;
    [SerializeField]
    private bool _isPoisoned = false;
    [SerializeField]
    private int _attackStrength = 1;
    [SerializeField]
    private int _magicStrength = 2;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private bool _canMove = true;

    [SerializeField]
    private Rigidbody2D _playerRigidbody;

    [SerializeField]
    private Map _map;
    [SerializeField]
    private Audio _audio;
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private StatusBar _statusBar;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        
        if (scene.name == "Battle")
        {
            _canMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove == true)
        {
            PlayerMovement();
        }
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 velocity = new Vector2(0, 0);

        if (horizontalInput != 0)
        {
            velocity = new Vector2(horizontalInput * _speed, 0);
            _animator.SetFloat("right", horizontalInput);
            _animator.SetFloat("any", 1);
        }

        else if (verticalInput != 0)
        {
            velocity = new Vector2(0, verticalInput * _speed);
            _animator.SetFloat("up", verticalInput);
            _animator.SetFloat("any", 1);
        }

        _playerRigidbody.MovePosition(_playerRigidbody.position + velocity * Time.fixedDeltaTime);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            _map.SearchForEnemy();
        }

        if (horizontalInput == 0 && verticalInput == 0)
        {
            _animator.SetFloat("up", 0);
            _animator.SetFloat("right", 0);
            _animator.SetFloat("any", 0);
        }
    }

    public void FoundEnemy()
    {
        _canMove = false;
        _animator.SetFloat("any", 0);

        _audio.StopAudio();
        transform.Find("Exclamation Point").gameObject.SetActive(true);
    }

    public int GetAttackStrength()
    {
        return _attackStrength;
    }

    public int GetMagicStrength()
    {
        return _magicStrength;
    }

    public int GetMagicPoints()
    {
        return _mp;
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;

        _statusBar.WriteStatusText(_hp, _mp, _isPoisoned);
    }

    public void LoseMagic(int drain)
    {
        _mp -= drain;

        if (_mp < 0)
        {
            _mp = 0;
        }

        _statusBar.WriteStatusText(_hp, _mp, _isPoisoned);
    }

    public void ChangePoisonStatus(bool status)
    {
        _isPoisoned = status;

        _statusBar.WriteStatusText(_hp, _mp, _isPoisoned);
    }
}

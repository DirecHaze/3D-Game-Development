using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState
    {
        Attack,
        Follow,
    }

    [SerializeField]
    private CharacterController _enemyController;
    [SerializeField]
    private float _yVelocity, _gravity, _speed;
    private Vector3 _direction, _velocity;
    [SerializeField]
    private EnemyState _currentState = EnemyState.Follow;
    [SerializeField]
    private float _attackDelay = 1.5f, _attackAgain;
    private void Start()
    {
        _enemyController = GetComponent<CharacterController>();
  
    }
    private void Update()
    {
       
        switch (_currentState)
        {
            case EnemyState.Follow:
                Movement();
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }




    }
    private void Movement()
    {
        if(_enemyController.isGrounded == true)
        {
            _direction = GameObject.Find("Player").transform.position - transform.position;
            _direction.Normalize();
            _velocity = _direction * _speed;
           
        }
        else
        {
            _yVelocity -= _gravity * Time.deltaTime;
        }
        _direction.y = 0;
        transform.localRotation = Quaternion.LookRotation(_direction);
        _velocity.y = _yVelocity;
        _enemyController.Move(_velocity * Time.deltaTime);
    }
    private void Attack()
    {
        Health PlayerHealth = GameObject.Find("Player").GetComponent<Health>();
        if (Time.time > _attackAgain)
        {
            PlayerHealth.DamageHealth(10);
            _attackAgain = Time.time + _attackDelay;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _currentState = EnemyState.Attack;
        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _currentState = EnemyState.Follow;
        }
    }
}

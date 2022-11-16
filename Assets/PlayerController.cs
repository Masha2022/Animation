using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _speedChangeValue = 0.1f;

    private Animator _animator;
    private static readonly int Speed = Animator.StringToHash("speed");
    private static readonly int Damage1 = Animator.StringToHash("Damage1");
    private static readonly int Damage2 = Animator.StringToHash("Damage2");

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _speed = 10;
            gameObject.transform.position += Vector3.forward * _speedChangeValue;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _speed = -10;
            gameObject.transform.position += Vector3.back * _speedChangeValue;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var damage = Random.Range(1, 3);
            if (damage == 1)
            {
                _animator.SetTrigger(Damage1);
            }

            if (damage == 2)
            {
                _animator.SetTrigger(Damage2);
            }
        }

        _animator.SetFloat(Speed, _speed);
    }
}
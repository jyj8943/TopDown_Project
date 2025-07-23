using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection
    {
        get { return movementDirection; }
    }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection
    {
        get { return lookDirection; }
    }

    private Vector2 knockBack = Vector2.zero;
    private float knockBackDuration = 0.0f;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
        if (knockBackDuration > 0)
        {
            knockBackDuration -= Time.fixedDeltaTime;
        }
    }

    protected virtual void HandleAction()
    {
        
    }

    private void Movement(Vector2 direction)
    {
        direction = direction * 5;
        if (knockBackDuration > 0.0f)
        {
            direction *= 0.2f;
            direction += knockBack;
        }

        _rigidbody.velocity = direction;
    }

    private void Rotate(Vector2 direction)
    {
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotz) > 90f;

        characterRenderer.flipX = isLeft;

        if (weaponPivot != null)
        {
            weaponPivot.rotation = Quaternion.Euler(0f, 0f, rotz);
        }
    }

    public void ApplyKnockBack(Transform other, float power, float duration)
    {
        knockBackDuration = duration;
        knockBack = (other.position - transform.position).normalized * power;
    }
}

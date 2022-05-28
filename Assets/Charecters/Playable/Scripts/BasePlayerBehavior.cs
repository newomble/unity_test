using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasePlayerBehavior : MonoBehaviour
{
    public float movespeed = 1f;
    Rigidbody2D rb;
    Vector2 directionalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue moveValue)
    {
        directionalInput = moveValue.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        this.moveCharecter();
    }

    private void moveCharecter()
    {
        if (this.HadMovementInput())
        {
            Vector2 nextPosition = this.CalculateNextPosition();
            if (this.CanMoveTo(nextPosition))
            {
                rb.MovePosition(nextPosition);
            }
        }
    }

    private bool HadMovementInput()
    {
        return directionalInput != Vector2.zero;
    }

    private bool CanMoveTo(Vector2 nextPosition)
    {
        //TODO
        return true;
    }

    private Vector2 CalculateNextPosition()
    {
        return rb.position + movespeed * Time.fixedDeltaTime * directionalInput;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : ZombiesSystem
{
    Rigidbody2D rigidbody2d;
    [Range(1f, 50f)]
    [SerializeField] private float speed = 3f;

    // 오른쪽에서 왼쪽으로 이동하니 direction = -1을 준다.
    private int direction = -1;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + Time.deltaTime * speed * direction;
        rigidbody2d.MovePosition(position);
    }

    protected override void Behaviour()
    {

    }

    protected override void Die()
    {

    }
}

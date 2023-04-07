using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;

    [Range(50f, 130f)]
    [SerializeField] private float speed = 70f;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + Time.deltaTime * speed;
        rigidbody2d.MovePosition(position);
    }

    // 충돌처리
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Zombie"))
        {
            animator.SetTrigger("Zombie Touch");
            Invoke("DestroyBullet",0.5f);
        }
    }

    private void DestroyBullet()
    {
        animator.gameObject.SetActive(false);
    }
}

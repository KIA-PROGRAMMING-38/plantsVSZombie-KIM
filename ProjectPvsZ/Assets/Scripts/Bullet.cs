using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Range(50f, 130f)]
    [SerializeField] private float speed = 100f;
    private int attackPower;
    Rigidbody2D rigidbody2d;
    Animator animator;

    // �Ѿ� ������Ʈ�� ���� ���� Ǯ�� ĳ���� _ManagedPool ��� ������ �����Ѵ�.
    private IObjectPool<Bullet> _ManagedPool;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + Time.deltaTime * speed;
        rigidbody2d.MovePosition(position);
    }

    // SetManagedPool �Լ��� ����� �Ű������� ���� Ǯ�� _ManagedPool�� �����ϵ��� ������ش�.
    public void SetManagedPool(IObjectPool<Bullet> pool)
    {
        _ManagedPool = pool;
    }

    // �浹ó��
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Zombie"))
        {
            animator.SetTrigger("Zombie Touch");
            Invoke("DestroyBullet", 0.5f);
        }
    }

    private void DestroyBullet()
    {
        _ManagedPool.Release(this);
    }

    public void SetAttackPower(int damage)
    {
        attackPower = damage;
    }
}

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

    // 총알 오브젝트를 관리 중인 풀을 캐싱할 _ManagedPool 멤버 변수를 선언한다.
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

    // SetManagedPool 함수를 만들고 매개변수로 받은 풀을 _ManagedPool에 저장하도록 만들어준다.
    public void SetManagedPool(IObjectPool<Bullet> pool)
    {
        _ManagedPool = pool;
    }

    // 충돌처리
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

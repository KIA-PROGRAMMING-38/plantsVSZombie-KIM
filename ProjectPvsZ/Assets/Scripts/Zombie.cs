using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;
    [Range(1f, 50f)]
    [SerializeField] private float ZombieWalkspeed = 15f;
    private bool canWalk, canAttack;
    [Range(1, 20)]
    [SerializeField]private int hp;

    // 코루틴 최적화
    WaitForSeconds waitForSeconds = new WaitForSeconds(1);


    // 오른쪽에서 왼쪽으로 이동하니 direction = -1을 준다.
    private int direction = -1;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        canWalk = true;
        canAttack = true;
        // 체력
        hp = 10;
    }

    private void Update()
    {
        CheckPlant();
        CheckHealth();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 ZombiePosition = transform.position;
        if (canWalk)
        {
            ZombiePosition.x = ZombiePosition.x + Time.deltaTime * ZombieWalkspeed * direction;
            rigidbody2d.MovePosition(ZombiePosition);
        }
        else if (canWalk == false)
        {
            ZombiePosition.x = 0;
        }
    }

    // 좀비 죽음 확인
    void CheckHealth()
    {

        if (hp <= 2)
        {
            animator.SetInteger("Zombie Health", 2);
            canAttack = false;
        }

        if (hp <= 0)
        {
            animator.SetInteger("Zombie Health", 0);
            canWalk = false;
            Invoke("ZombieDeath", 1.1f);
        }
    }

    // 식물 감지
    void CheckPlant()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 0.3f, LayerMask.GetMask("Plants"));
        if (hit.collider != null)
        {
            animator.SetBool("Zombie Attack", true);
            canWalk = false;
            if (canAttack)
            {
                StartCoroutine(Eating(hit.collider));
            }
        }
        else
        {
            StopCoroutine("Eating");
            animator.SetBool("Zombie Attack", false);
            canWalk = true;
        }
    }
    // 코루틴
    IEnumerator Eating(Collider2D collider)
    {
        canAttack = false;
        yield return waitForSeconds;
        canAttack = true;
        if (collider != null)
        {
            collider.gameObject.GetComponent<peaShooter>().hp--;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hp--;
        }
    }
    
    void ZombieDeath()
    {
        Destroy(gameObject);
    }
}

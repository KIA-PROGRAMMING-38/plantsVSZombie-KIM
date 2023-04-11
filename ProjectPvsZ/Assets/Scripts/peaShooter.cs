using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class peaShooter : PlantsSystem
{
    [SerializeField]
    private GameObject _BulletPrefab;

    private Transform _spwanPosition;

    // 멤버 변수로 총알 오브젝트를 관리할 IObjectPool<Bullet> 타입의 _Pool 변수를 선언해준다.
    private IObjectPool<Bullet> _Pool;

    private float _elapsedTime;

    // Awake 함수에서 _Pool 멤버 변수에 Object Pool을 생성해서 넣어준다.
    private void Awake()
    {
        _spwanPosition = transform.Find("SpwanPosition");
        _Pool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestoryBullet, maxSize: 20);
    }
    private void Start()
    {
        // 공격력
        amount = 1;

        // 공격 쿨타임
        cooltime = 3.5f;
        // 공격 범위

        // 체력
        hp = 6;
    }

    private bool _attackTrigger;
    public bool AttackTrigger
    {
        get => _attackTrigger;
        set
        {
            _attackTrigger = value;
            if (false == _attackTrigger)
                _elapsedTime = 0f;
        }
    }
    private void Update()
    {
        if (AttackTrigger == true)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > cooltime)
            {
                Behaviour();
                _elapsedTime = 0f;
            }
        }

        if(hp <= 0)
        {
            Die();
        }

    }

    public void peaShooterAttack()
    {
        var bullet = _Pool.Get();
        bullet.SetAttackPower(amount);
        bullet.transform.position = _spwanPosition.position;
    }
    // 총알 오브젝트를 생성할 때 호출될 함수인 CreateBullet 함수를 만든다.
    // 가지고 있는 프리팹으로 총알 오브젝트를 생성한 다음 생성된  bullet 오브젝트에 자신이 등록되어야 할 풀을 알려주고 반환한다.
    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_BulletPrefab).GetComponent<Bullet>();
        bullet.SetManagedPool(_Pool);
        return bullet;
    }

    // 풀에서 오브젝트를 빌려올 때 사용될 OnGetBullet 함수
    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    // 오브젝트 풀에 돌려줄 때 사용될 OnReleaseBullet 함수
    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    // 풀에서 오브젝트를 파괴할 때 사용될 OnDestroyBullet 함수
    private void OnDestoryBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    // 행위
    protected override void Behaviour()
    {
        // 좀비가 범위에 들어오면 공격 상태
        peaShooterAttack();
    }

    // 죽음
    protected override void Die()
    {
        Destroy(gameObject);
    }


}

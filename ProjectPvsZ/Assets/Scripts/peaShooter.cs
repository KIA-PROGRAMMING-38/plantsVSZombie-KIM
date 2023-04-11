using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class peaShooter : PlantsSystem
{
    [SerializeField]
    private GameObject _BulletPrefab;

    private Transform _spwanPosition;

    // ��� ������ �Ѿ� ������Ʈ�� ������ IObjectPool<Bullet> Ÿ���� _Pool ������ �������ش�.
    private IObjectPool<Bullet> _Pool;

    private float _elapsedTime;

    // Awake �Լ����� _Pool ��� ������ Object Pool�� �����ؼ� �־��ش�.
    private void Awake()
    {
        _spwanPosition = transform.Find("SpwanPosition");
        _Pool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestoryBullet, maxSize: 20);
    }
    private void Start()
    {
        // ���ݷ�
        amount = 1;

        // ���� ��Ÿ��
        cooltime = 3.5f;
        // ���� ����

        // ü��
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
    // �Ѿ� ������Ʈ�� ������ �� ȣ��� �Լ��� CreateBullet �Լ��� �����.
    // ������ �ִ� ���������� �Ѿ� ������Ʈ�� ������ ���� ������  bullet ������Ʈ�� �ڽ��� ��ϵǾ�� �� Ǯ�� �˷��ְ� ��ȯ�Ѵ�.
    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_BulletPrefab).GetComponent<Bullet>();
        bullet.SetManagedPool(_Pool);
        return bullet;
    }

    // Ǯ���� ������Ʈ�� ������ �� ���� OnGetBullet �Լ�
    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    // ������Ʈ Ǯ�� ������ �� ���� OnReleaseBullet �Լ�
    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    // Ǯ���� ������Ʈ�� �ı��� �� ���� OnDestroyBullet �Լ�
    private void OnDestoryBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    // ����
    protected override void Behaviour()
    {
        // ���� ������ ������ ���� ����
        peaShooterAttack();
    }

    // ����
    protected override void Die()
    {
        Destroy(gameObject);
    }


}

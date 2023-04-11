using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterSystem : MonoBehaviour
{
    Animator animator;

    // protected�� Ŭ���� ���ο��� ���� ����, �ش� Ŭ������ ��ӹ��� Ŭ�������� ���� �����ϴ�.
    protected int amount; // ���ݷ� Ȥ�� ������ �ڿ���
    protected float cooltime; // ���� ��Ÿ��
    protected float range; // ����, ���� ����
    public int hp; // ü��

    // �ڵ��� ���յ��� ���߰�, �������� ���̱� ���� �������� protected�� ����غ���.
    protected abstract void Behaviour();
    protected abstract void Die();

}


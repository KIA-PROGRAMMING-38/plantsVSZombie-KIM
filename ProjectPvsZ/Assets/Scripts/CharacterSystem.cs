using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterSystem : MonoBehaviour
{
    Animator animator;

    // protected는 클래스 내부에서 접근 가능, 해당 클래스를 상속받은 클래스에서 접근 가능하다.
    protected int amount; // 공격력 혹은 에너지 자원양
    protected float cooltime; // 공격 쿨타임
    protected float range; // 공격, 방어등 범위
    public int hp; // 체력

    // 코드의 결합도를 낮추고, 유연성을 높이기 위한 도전으로 protected를 사용해본다.
    protected abstract void Behaviour();
    protected abstract void Die();

}


using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class PlantsSystem : CharacterSystem
{
    protected float plantsCardCooltime; // �Ĺ� ī�� ��� ��Ÿ��
    protected int plantsCardCost; // �Ĺ� ī�带 ����� ���
    protected int Level; // �Ĺ� ī�带 ��� ������ ���� 
}

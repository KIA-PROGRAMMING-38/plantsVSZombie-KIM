using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class PlantsSystem : CharacterSystem
{
    protected float plantsCardCooltime; // 식물 카드 사용 쿨타임
    protected int plantsCardCost; // 식물 카드를 사용할 비용
    protected int Level; // 식물 카드를 사용 가능한 레벨 
}

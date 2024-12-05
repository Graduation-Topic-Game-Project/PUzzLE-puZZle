using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "New BattleInformation", menuName = "ScriptableObject/BattleInformation", order = 3)]
public class BattleInformation : ScriptableObject
{
    public BattleData battleData;

    public List<GameObject> Enemies { get => battleData.EnemyPrefab;}
}

[Serializable]
public class BattleData
{
    [Header("�����d�|�X�{���ĤH")]
    public List<GameObject> EnemyPrefab;
}

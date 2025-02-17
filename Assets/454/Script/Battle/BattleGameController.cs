using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class BattleGameController : MonoBehaviour
{
    /// <summary>�԰��}�l(����԰�Ĳ�o�@��)</summary>
    public event EventHandler Event_BattleStart;
    /// <summary>�^�X�}�l</summary>
    public event EventHandler Event_StartTurn; //�^�X�}�l
    /// <summary>��ܳƾ԰ϫ��� [true = ��� false = �������]</summary>
    public event Action<bool> Event_SpecifyPuzzle; //��ܫ���
    /// <summary>���ϩ�m����</summary>
    public event EventHandler Event_PuzzlePlaceCompleted; //���ϩ�m����
    /// <summary>����L��</summary>
    public event EventHandler Event_SettlementBoard; //����L��
    /// <summary>����ĤH�ޯ�</summary>
    public event EventHandler Event_SettlementEnemySkill; //����ĤH�ޯ�
    /// <summary>�Ĭ𶥬q</summary>
    public event Func<Coroutine> Event_Confrontation; //�Ĭ𶥬q
    /// <summary>�P�w:�O�_�����Ĥ�Ҧ��`</summary>
    public event Action Event_IsAllEnemyDead; //�P�w:�O�_�����Ĥ�Ҧ��`
    /// <summary>�ӧQ</summary>
    public event Action Event_Win; //�ӧQ
    /// <summary>�����^�X</summary>
    public event EventHandler Event_EndTurn; //�����^�X

    [Header("���d��T")]
    public BattleInformation battleInformation;

    [Header("�٦�")]
    public Partner[] partners = new Partner[4]; //�n�԰����٦�

    [Header("���")]
    public List<Enemy> enemies = new List<Enemy>();
    //�u���}�l�C���ͦ��ĤH�M�I��ޯ�ɷ|�ΡA�ˮ`�p�ⵥ�bBattleGameController��InstancedEnemy

    public List<Enemy> InstancedEnemy; //��Ҥƪ��ĤH

    [Header("�O�_�ӧQ"), Tooltip("true = win")]
    public bool IsWin;

    private void Start()
    {
        Event_BattleStart?.Invoke(this, EventArgs.Empty);
        CallEvent_StartTurn(); //�^�X�}�l�ƥ�
    }

    /// <summary>
    /// �o�e�^�X�}�l�ƥ�
    /// </summary>
    public void CallEvent_StartTurn()
    {
        Event_StartTurn?.Invoke(this, EventArgs.Empty);
        //Debug.Log("�s���^�X�}�l");
    }

    /// <summary>
    /// �o�e��ܫ��Ϩƥ�{true = ��� false = �������}
    /// </summary>
    public void CallEvent_SpecifyPuzzle(bool Specify_Or_NoSpecify)
    {
        Event_SpecifyPuzzle?.Invoke(Specify_Or_NoSpecify);
    }

    /// <summary>
    /// �o�e���ϩ�m�����ƥ�
    /// </summary>
    public void CallEvent_PlacedPuzzle()
    {
        Event_PuzzlePlaceCompleted?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// �o�e����L�����Ϩƥ�
    /// </summary>
    public void CallEvent_SettlementBoard()
    {
        Event_SettlementBoard?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// �o�e����ĤH�ޯ�ƥ�
    /// </summary>
    public void CallEvent_SettlementEnemySkill()
    {
        Event_SettlementEnemySkill?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// �o�e�Ĭ�ƥ�
    /// </summary>
    public void CallEvent_Confrontation()
    {
        Event_Confrontation?.Invoke();

        /*Debug.LogWarning("���~�A�Ĭ��{���^�Ǩ�{");
        return null;*/
    }

    /// <summary>
    /// �o�e�O�_�����Ĥ�Ҧ��`�P�w�ƥ�
    /// </summary>
    public void CallEvent_IsAllEnemyDead()
    {
        Event_IsAllEnemyDead?.Invoke();
        // Debug.Log("CallEvent_IsWin()");
    }

    /// <summary>
    /// �o�e�^�X�����ƥ�
    /// </summary>
    public void CallEvent_EndTurn()
    {
        Event_EndTurn?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// �o�e�ӧQ�ƥ�
    /// </summary>
    public void CallEvent_Win()
    {
        Event_Win?.Invoke();
        Debug.Log("CallEvent_Win()");
    }


}

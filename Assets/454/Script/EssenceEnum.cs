using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ΥH�x�s����P������ƪ��R�A���O
/// </summary>
public static class EssenceEnum
{
    /// <summary> �O�q����_�зǦ� </summary>
    public static readonly Color32 Strengthe_Color = new Color32(255, 0, 0, 255); // 
    /// <summary> ���z����_�зǦ� </summary>
    public static readonly Color32 Wisdom_Color = new Color32(0, 115, 255, 255); // 
    /// <summary> �H������_�зǦ� </summary>
    public static readonly Color32 Belief_tColor = new Color32(255, 215, 0, 255); // ������
    /// <summary> �F���_�зǦ� </summary>
    public static readonly Color32 Soul_Color = new Color32(195, 0, 255, 255); // 

    public enum Essence
    {
        None_�L�ݩ� = 0,
        Strengthe_�O�q = 1, //�O�q
        Wisdom_���z = 2,  //���z
        Belief_�H�� = 3, //�H��
        Soul_�F�� = 4, //�F��
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLibrary : MonoBehaviour
{
    public List<Puzzle> puzzleLibrary; //���Ϯw
    public GameObject puzzlePreparations; //�����W�����ϳƾ԰Ϥ�����
    public Vector3[] puzzlePreparationsTransform = new Vector3[6]; //���ϳƾ԰Ϫ����m�A�Ψӹ�ͦ��ɪ���m��

    private void Start()
    {

    }

    public void Load_puzzlePreparations() //����ƾ԰Ϧ�m
    {
        int preparationsCount = puzzlePreparationsTransform.Length;
        for (int i = 0; i < preparationsCount; i++)
        {

        }
    }

}

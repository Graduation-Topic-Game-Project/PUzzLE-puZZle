using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLibrary : MonoBehaviour
{
    public List<Puzzle> puzzleLibrary; //���Ϯw
    public GameObject puzzlePreparations; //�����W�����ϳƾ԰Ϥ�����
    public Vector3[] puzzlePreparationsTransform = new Vector3[6]; //���ϳƾ԰Ϫ����m�A�Ψӹ�ͦ��ɪ���m��

    private void Awake()
    {
        Load_puzzlePreparations();  //����ƾ԰Ϧ�m
    }

    /// <summary>
    /// ����ƾ԰Ϧ�m
    /// </summary>
    public void Load_puzzlePreparations() //����ƾ԰Ϧ�m
    {
        //puzzlePreparationsTransform[0] = puzzlePreparations.transform.GetChild(0).gameObject.transform.position;
        for (int i = 0; i < 6; i++)
        {
            puzzlePreparationsTransform[i] = puzzlePreparations.transform.GetChild(i).gameObject.transform.position;
        }
    }
}

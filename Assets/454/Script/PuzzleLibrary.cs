using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PuzzleLibrary : MonoBehaviour
{
    public BattleGameController battleGameController;
    public List<PuzzleData> puzzleLibrary; //���Ϯw
    public Parther[] parthers = new Parther[4]; //�n�԰����٦�
    public GameObject puzzlePreparations; //�����W�����ϳƾ԰Ϥ�����
    public Vector3[] puzzlePreparationsTransform = new Vector3[6]; //���ϳƾ԰Ϫ����m�A�Ψӹ�ͦ��ɪ���m��

    private void Awake()
    {
        Load_puzzlePreparations();  //����ƾ԰Ϧ�m
        battleGameController.BattleStart += this.Load_PuzzleLibrary;
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
    /// <summary>
    /// �N�٦�ҫ������Ϭ~�J���Ϯw
    /// </summary>
    public void Load_PuzzleLibrary(object sender, EventArgs e)
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log($"���J��{i+1}�ӹ٦����");
            if (parthers[i] != null)
            {
                puzzleLibrary.AddRange(parthers[i].thisParther.parthersPuzzle);
                //parthers[i].thisParther.parthersPuzzle.
                Debug.Log($"��{i + 1}�ӹ٦���ϸ��J����");
            }
            else
                Debug.Log($"��{i + 1}�ӹ٦�null");
       }
    }
}

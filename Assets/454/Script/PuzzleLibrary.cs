using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLibrary : MonoBehaviour
{
    public List<Puzzle> puzzleLibrary; //拼圖庫
    public GameObject puzzlePreparations; //場景上的拼圖備戰區父物件
    public Vector3[] puzzlePreparationsTransform = new Vector3[6]; //拼圖備戰區物件位置，用來對生成時的位置的

    private void Awake()
    {
        Load_puzzlePreparations();  //獲取備戰區位置
    }

    /// <summary>
    /// 獲取備戰區位置
    /// </summary>
    public void Load_puzzlePreparations() //獲取備戰區位置
    {
        //puzzlePreparationsTransform[0] = puzzlePreparations.transform.GetChild(0).gameObject.transform.position;
        for (int i = 0; i < 6; i++)
        {
            puzzlePreparationsTransform[i] = puzzlePreparations.transform.GetChild(i).gameObject.transform.position;
        }
    }
}

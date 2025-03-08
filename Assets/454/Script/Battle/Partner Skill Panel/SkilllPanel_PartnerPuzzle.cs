using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilllPanel_PartnerPuzzle : MonoBehaviour
{
    public PartnerSkillPanelController partnerSkillPanelController;
    public PuzzleMasterController puzzleMasterController;

    public Puzzle nowPartnerPuzzle;
    PuzzleData nowPartnerPuzzleData;
    public GameObject InstanceLocation; //生成位置

    private void Awake()
    {

        if (partnerSkillPanelController == null) //獲取父物件上的PartnerSkillPanelController
        {
            partnerSkillPanelController = GetComponentInParent<PartnerSkillPanelController>();
        }
        if (puzzleMasterController == null) //獲取場景上的PuzzleMasterController
        {
            puzzleMasterController = FindObjectOfType<PuzzleMasterController>();
        }

        if (partnerSkillPanelController.nowPartner.partnerData.partnersPuzzle[0] != null)
        {
            nowPartnerPuzzleData = partnerSkillPanelController.nowPartner.partnerData.partnersPuzzle[0];
        }
    }

    private void OnEnable() //當SetActive(true)時觸發一次
    {
        ShowPartnerPuzzleImage();
    }

    /// <summary>顯示&更新夥伴拼圖圖片</summary>
    public void ShowPartnerPuzzleImage()
    {
        if (nowPartnerPuzzle != null)
            Destroy(nowPartnerPuzzle.gameObject);

        if (partnerSkillPanelController.nowPartner.partnerData.partnersPuzzle[0] == null)
        {
            Debug.Log("partnerData內無夥伴拼圖");
            return;
        }
        else //更新夥伴拼圖資料
        {
            nowPartnerPuzzleData = partnerSkillPanelController.nowPartner.partnerData.partnersPuzzle[0];
        }

        nowPartnerPuzzle = Instantiate(puzzleMasterController.puzzlePrefab, InstanceLocation.transform.position, InstanceLocation.transform.rotation, InstanceLocation.transform);
        nowPartnerPuzzle.puzzleData = nowPartnerPuzzleData;
        nowPartnerPuzzle.ReUpdate_PuzzleEssence_Image();
    }
}

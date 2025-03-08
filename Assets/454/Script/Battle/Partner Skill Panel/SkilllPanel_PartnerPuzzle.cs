using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilllPanel_PartnerPuzzle : MonoBehaviour
{
    public PartnerSkillPanelController partnerSkillPanelController;
    public PuzzleMasterController puzzleMasterController;

    public Puzzle nowPartnerPuzzle;
    PuzzleData nowPartnerPuzzleData;
    public GameObject InstanceLocation; //�ͦ���m

    private void Awake()
    {

        if (partnerSkillPanelController == null) //���������W��PartnerSkillPanelController
        {
            partnerSkillPanelController = GetComponentInParent<PartnerSkillPanelController>();
        }
        if (puzzleMasterController == null) //��������W��PuzzleMasterController
        {
            puzzleMasterController = FindObjectOfType<PuzzleMasterController>();
        }

        if (partnerSkillPanelController.nowPartner.partnerData.partnersPuzzle[0] != null)
        {
            nowPartnerPuzzleData = partnerSkillPanelController.nowPartner.partnerData.partnersPuzzle[0];
        }
    }

    private void OnEnable() //��SetActive(true)��Ĳ�o�@��
    {
        ShowPartnerPuzzleImage();
    }

    /// <summary>���&��s�٦���ϹϤ�</summary>
    public void ShowPartnerPuzzleImage()
    {
        if (nowPartnerPuzzle != null)
            Destroy(nowPartnerPuzzle.gameObject);

        if (partnerSkillPanelController.nowPartner.partnerData.partnersPuzzle[0] == null)
        {
            Debug.Log("partnerData���L�٦����");
            return;
        }
        else //��s�٦���ϸ��
        {
            nowPartnerPuzzleData = partnerSkillPanelController.nowPartner.partnerData.partnersPuzzle[0];
        }

        nowPartnerPuzzle = Instantiate(puzzleMasterController.puzzlePrefab, InstanceLocation.transform.position, InstanceLocation.transform.rotation, InstanceLocation.transform);
        nowPartnerPuzzle.puzzleData = nowPartnerPuzzleData;
        nowPartnerPuzzle.ReUpdate_PuzzleEssence_Image();
    }
}

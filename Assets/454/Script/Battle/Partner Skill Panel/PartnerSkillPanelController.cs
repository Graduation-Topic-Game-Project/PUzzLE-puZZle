using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerSkillPanelController : MonoBehaviour
{
    public Partner nowPartner;

    public bool isOpen;

    private void Awake()
    {
        OpenSkillPlane(false);
    }
    public void OpenSkillPlane(bool OpenOrClose)
    {
        isOpen = OpenOrClose;
        gameObject.SetActive(OpenOrClose);
    }

}

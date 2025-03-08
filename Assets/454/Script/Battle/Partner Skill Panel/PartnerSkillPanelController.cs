using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnerSkillPanelController : MonoBehaviour
{
    public Partner nowPartner;

    private void Awake()
    {
        OpenSkillPlane(false);
    }
    public void OpenSkillPlane(bool OpenOrClose)
    {
        gameObject.SetActive(OpenOrClose);
    }

}

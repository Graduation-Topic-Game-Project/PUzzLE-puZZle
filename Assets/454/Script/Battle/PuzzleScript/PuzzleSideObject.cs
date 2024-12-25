using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleSideObject : MonoBehaviour
{
    public Image sideImage;
    public GameObject sideLinkLight;
    public Image sideLightImage;
    public List<Sprite> PuzzleSideLightSprite = new List<Sprite>();

    public void LinkGlowing()
    {
        sideLinkLight.GetComponent<CanvasGroup>().alpha = 0.25f;
    }
}

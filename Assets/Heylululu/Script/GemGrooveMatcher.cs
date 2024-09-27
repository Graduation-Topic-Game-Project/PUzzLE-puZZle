using UnityEngine;

public class GemGrooveMatcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �ˬd�O�_���_��
        if (other.CompareTag("GemRed") || other.CompareTag("GemYellow") ||
            other.CompareTag("GemBlue") || other.CompareTag("GemPink") ||
            other.CompareTag("GemGray"))
        {
            // ����d�g���C��
            string grooveColor = gameObject.tag; // ���]�d�g�����ҬO�p "GrooveRed"

            // �ˬd�C��O�_�ǰt
            if (other.CompareTag("Gem" + grooveColor.Replace("Groove", ""))) // �Ҧp�G�p�G grooveColor �O "GrooveRed"�A�h�ǰt "GemRed"
            {
                Debug.Log("�����\");
            }
            else
            {
                Debug.Log("������");
            }
        }
    }
}

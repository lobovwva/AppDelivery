using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipController : MonoBehaviour
{
    // ������ �� ��������� Text
    private Text tooltipText;

    private void Start()
    {
        // �������� ������ �� ��������� Text
        tooltipText = GetComponent<Text>();

        // �������� ��������� ��� ������
        HideTooltip();
    }

    public void ShowTooltip(string text)
    {
        // ��������� ����� ���������
        tooltipText.text = text;

        // �������� GameObject � ����������
        gameObject.SetActive(true);

        // ��������� �������� ��� ������� ��������� ����� 5 ������
        StartCoroutine(HideTooltipAfterDelay(5f));
    }

    private IEnumerator HideTooltipAfterDelay(float delay)
    {
        // ���� ��������
        yield return new WaitForSeconds(delay);

        // �������� ���������
        HideTooltip();
    }

    private void HideTooltip()
    {
        // ��������� GameObject � ����������
        gameObject.SetActive(false);
    }
}

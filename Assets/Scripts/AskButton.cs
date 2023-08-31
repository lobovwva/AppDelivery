using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AskButton : MonoBehaviour
{
    // ������ �� TooltipController
    public TooltipController tooltipController;

    private void Start()
    {
        // ����������� ����� OnButtonClick � ������� OnClick ������
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        // ���������� ��������� ��� ������� �� ������
        tooltipController.ShowTooltip("�������� ����� � �������, ������� ������ ���� ����. �� ��� ���� ��������� ����� � ������. " +
            "������������ � ������ - � ��������� ���������� ���� ������. ������������ � ������� - ������������. �������� ������ - �� ���� ������ ���������");
    }
}

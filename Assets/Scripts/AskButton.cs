using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AskButton : MonoBehaviour
{
    // Ссылка на TooltipController
    public TooltipController tooltipController;

    private void Start()
    {
        // Привязываем метод OnButtonClick к событию OnClick кнопки
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        // Показываем подсказку при нажатии на кнопку
        tooltipController.ShowTooltip("Персонаж бежит с факелом, освещая только свой путь. На его пути находятся бочки и факелы. " +
            "Столкнувшись с бочкой - у персонажа отнимается один огонек. Столкнувшись с факелом - прибавляется. Основная задача - не дать факелу потухнуть");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipController : MonoBehaviour
{
    // Ссылка на компонент Text
    private Text tooltipText;

    private void Start()
    {
        // Получаем ссылку на компонент Text
        tooltipText = GetComponent<Text>();

        // Скрываем подсказку при старте
        HideTooltip();
    }

    public void ShowTooltip(string text)
    {
        // Обновляем текст подсказки
        tooltipText.text = text;

        // Включаем GameObject с подсказкой
        gameObject.SetActive(true);

        // Запускаем корутину для скрытия подсказки через 5 секунд
        StartCoroutine(HideTooltipAfterDelay(5f));
    }

    private IEnumerator HideTooltipAfterDelay(float delay)
    {
        // Ждем задержку
        yield return new WaitForSeconds(delay);

        // Скрываем подсказку
        HideTooltip();
    }

    private void HideTooltip()
    {
        // Выключаем GameObject с подсказкой
        gameObject.SetActive(false);
    }
}

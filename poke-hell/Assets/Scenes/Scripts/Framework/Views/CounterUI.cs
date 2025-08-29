using UnityEngine;
using TMPro;

public class CounterUI : MonoBehaviour
{
    public TextMeshProUGUI bulletCounter;

    void OnEnable()
    {
        BulletManager.onCountChanged += UpdateCounter;
        UpdateCounter(BulletManager.bulletNum);
    }

    void OnDisable()
    {
        BulletManager.onCountChanged -= UpdateCounter;
    }

    void UpdateCounter(int num)
    {
        bulletCounter.text = $"{num}";
    }
}

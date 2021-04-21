using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthPointsView : MonoBehaviour
{
    [SerializeField] private Text healthTextUI;
    private string baseText;

    void Start()
    {
        baseText = healthTextUI.text;
    }

    public void UpdateHealthUI(int curHP, int maxHP)
    {
        healthTextUI.text = $"{baseText} {curHP}/{maxHP}";
    }
}

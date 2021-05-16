using UnityEngine;

[CreateAssetMenu(fileName = "New Combo Element", menuName = "ScriptableObjects/ComboElement")]
public class ComboElement : ScriptableObject
{
    [Tooltip("Quanto tempo o golpe demora até voltar ao estado de idle")]
    public float timeout;
    [Tooltip("Quanto tempo leva para terminar de cobrir a área determinada")]
    public float duration;
    [Tooltip("Em quantos segundos do ataque o combo pode ser engatilhado")]
    public float comboWindowStart;
    [Tooltip("Em quantos segundos do ataque o combo deixa de poder ser engatilhado")]
    public float comboWindowFinish;

    public int damage;
    [Tooltip("Se a área será progressivamente coberta da direita para esquerda ou ao contrário")]
    public bool goesRightToLeft;
}

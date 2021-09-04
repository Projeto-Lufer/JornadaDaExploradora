using UnityEngine;

[CreateAssetMenu(fileName = "New Combo Element", menuName = "ScriptableObjects/ComboElement")]
public class ComboElement : ScriptableObject
{
    [Tooltip("Quanto tempo o golpe demora at� voltar ao estado de idle")]
    public float timeout;
    [Tooltip("Quanto tempo leva para terminar de cobrir a �rea determinada")]
    public float duration;
    [Tooltip("Em quantos segundos do ataque o combo pode ser engatilhado")]
    public float comboWindowStart;
    [Tooltip("Em quantos segundos do ataque o combo deixa de poder ser engatilhado")]
    public float comboWindowFinish;

    public int damage;
    [Tooltip("Se a �rea ser� progressivamente coberta da direita para esquerda ou ao contr�rio")]
    public bool goesRightToLeft;

    public int knockback;
    public float knockbackTime;
}

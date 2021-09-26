using UnityEngine;

[CreateAssetMenu(fileName = "New Combo Element", menuName = "ScriptableObjects/ComboElement")]
public class ComboElement : ScriptableObject
{
    [Tooltip("Quanto tempo o golpe demora ate voltar ao estado de idle")]
    public float totalTime;
    [Tooltip("Quanto tempo o personagem fica preparando o ataque")]
    public float windUp;
    [Tooltip("Quanto tempo leva para terminar de cobrir a area determinada")]
    public float duration;
    [Tooltip("Em quantos segundos do ataque o combo pode ser engatilhado")]
    public float comboWindowStart;
    [Tooltip("Em quantos segundos do ataque o combo deixa de poder ser engatilhado")]
    public float comboWindowFinish;
    [Tooltip("Por quanto tempo o alvo ficará em hitstun")]
    public float hitstunDuration;
    [Tooltip("Por quanto tempo o personagem ficará sem poder atacar após terminar o ataque")]
    public float cooldown;

    public int damage;
    [Tooltip("Se a area sera progressivamente coberta da direita para esquerda ou ao contr�rio")]
    public bool goesRightToLeft;

    public int knockback;
    public float knockbackTime;

    [FMODUnity.EventRef]
    public string sfxAttack;
    [FMODUnity.EventRef]
    public string voiceSound;
}

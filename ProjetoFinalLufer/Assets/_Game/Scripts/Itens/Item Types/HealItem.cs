using UnityEngine;

public class HealItem : CollectableObject
{
    [SerializeField] private int healAmount;

    public override void Collect(ObjectCollector collector)
    {
        collector.GetComponent<PlayerHealthPoints>().AddHealth(healAmount);
        Destroy(gameObject);
    }
}
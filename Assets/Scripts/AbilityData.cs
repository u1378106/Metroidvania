using UnityEngine;

[CreateAssetMenu(menuName = "Ability Data")]
public class AbilityData : ScriptableObject
{
    public int Damage;
    public string abilityName;
    public GameObject ability;
    public GameObject damageEffect;
    public GameObject destroyEffect;
}

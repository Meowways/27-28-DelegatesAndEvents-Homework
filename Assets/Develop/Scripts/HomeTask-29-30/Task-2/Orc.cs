public class Orc : Enemy
{
    private float _strength;
    private float _damage;
    private float _armor;

    public void Initialize(OrcSettings orcSettings)
    {
        _strength = orcSettings.Strength;
        _damage = orcSettings.Damage;
        _armor = orcSettings.Armor;
    }

    public override string ShowStats() => $"Strength - {_strength}; Damage - {_damage}; Armor - {_armor};";
}

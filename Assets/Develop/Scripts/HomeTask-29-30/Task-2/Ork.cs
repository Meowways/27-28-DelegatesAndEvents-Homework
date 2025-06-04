using System.Diagnostics;

public class Ork : Enemy
{
    private float _strength;
    private float _damage;
    private float _armor;

    public override void Initialize(ISettings settings)
    {
        if (settings is OrkSettings orkSettings)
        {
            _strength = orkSettings.Strength;
            _damage = orkSettings.Damage;
            _armor = orkSettings.Armor;
        }
    }

    public override string GetStats()
    {
        return $"Strength - {_strength}; Damage - {_damage}; Armor - {_armor};";
    }
}

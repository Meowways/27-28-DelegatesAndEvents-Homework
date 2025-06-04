public class Elf : Enemy
{
    private float _intelligence;
    private float _magicDamage;
    private float _luck;

    public override void Initialize(ISettings settings)
    {
        if (settings is ElfSettings elfSettings)
        {
            _intelligence = elfSettings.Intelligence;
            _magicDamage = elfSettings.MagicDamage;
            _luck = elfSettings.Luck;
        }
    }

    public override string GetStats()
    {
        return $"Intelligence - {_intelligence}; MagicDamage - {_magicDamage}; Luck - {_luck};";
    }
}

public class Dragon : Enemy
{
    private float _agility;
    private float _rage;
    private float _speed;

    public override void Initialize(ISettings settings)
    {
        if (settings is DragonSettings dragonSettings)
        {
            _agility = dragonSettings.Agility;
            _rage = dragonSettings.Rage;
            _speed = dragonSettings.Speed;
        }
    }

    public override string GetStats()
    {
        return $"Agility - {_agility}; Rage - {_rage}; Speed - {_speed};";
    }
}

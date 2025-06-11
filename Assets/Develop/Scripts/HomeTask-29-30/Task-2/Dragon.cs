public class Dragon : Enemy
{
    private float _agility;
    private float _rage;
    private float _speed;

    public void Initialize(DragonSettings dragonSettings)
    {
        _agility = dragonSettings.Agility;
        _rage = dragonSettings.Rage;
        _speed = dragonSettings.Speed;
    }

    public override string ShowStats() => $"Agility - {_agility}; Rage - {_rage}; Speed - {_speed};";

}

using System;
using UnityEngine;

[Serializable]
public class DragonSettings : ISettings
{
    [field: SerializeField] public float Agility { get; private set; }
    [field: SerializeField] public float Rage { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
}

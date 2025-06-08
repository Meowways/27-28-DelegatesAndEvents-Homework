using System;
using UnityEngine;

[Serializable]
public class OrcSettings : ISettings
{
    [field: SerializeField] public float Strength { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float Armor { get; private set; }
}

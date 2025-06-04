using System;
using UnityEngine;

[Serializable]
public class ElfSettings : ISettings
{
    [field: SerializeField] public float Intelligence { get; private set; }
    [field: SerializeField] public float MagicDamage { get; private set; }
    [field: SerializeField] public float Luck { get; private set; }
}

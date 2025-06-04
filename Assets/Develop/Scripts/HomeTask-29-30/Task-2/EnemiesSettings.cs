using System;
using UnityEngine;

[Serializable]
public class EnemiesSettings : MonoBehaviour
{
    [field: SerializeField] public DragonSettings[] DragonSettings {  get; private set; }
    [field: SerializeField] public OrkSettings[] OrkSettings { get; private set; }
    [field: SerializeField] public ElfSettings[] ElfSettings { get; private set; }
}

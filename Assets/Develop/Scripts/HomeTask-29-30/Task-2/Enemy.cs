using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void Initialize(ISettings settings);

    public abstract string GetStats();
}

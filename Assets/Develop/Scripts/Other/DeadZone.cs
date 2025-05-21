using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private TriggerReceiver[] _triggerReceivers;

    private void Awake()
    {
        foreach (TriggerReceiver trigger in _triggerReceivers)
            trigger.TriggerEnter += OnTriggerEnter;
    }

    private void OnDestroy()
    {
        foreach (TriggerReceiver trigger in _triggerReceivers)
            trigger.TriggerEnter -= OnTriggerEnter;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
            enemy.SetDeathMark();
    }
}

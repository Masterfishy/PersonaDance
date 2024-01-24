using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Spawn Event")]
public class SpawnEvent : ScriptableObject
{
    public UnityAction<Poser> OnEventRaised;

    /// <summary>
    /// Invoke the Death Event
    /// </summary>
    public void RaiseEvent(Poser payload)
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke(payload);
        }
    }
}

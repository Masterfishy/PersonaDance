using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Events/Death Event")]
public class DeathEvent : ScriptableObject
{
    public UnityAction OnEventRaised;

    /// <summary>
    /// Invoke the Death Event
    /// </summary>
    public void RaiseEvent()
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke();
        }
    }
}

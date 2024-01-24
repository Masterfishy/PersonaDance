using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This represents a change of stance event
/// </summary>
[CreateAssetMenu(menuName = "Events/Change Stance Event")]
public class ChangeStanceEvent : ScriptableObject
{
    public UnityAction<StanceEnum> OnEventRaised;

    /// <summary>
    /// Invoke the Change Stance Event with the stance payload
    /// </summary>
    /// <param name="payload">The stance to change to</param>
    public void RaiseEvent(StanceEnum payload)
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke(payload);
        }
    }
}
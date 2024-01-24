using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class represents the hit event
/// </summary>
[CreateAssetMenu(menuName ="Events/Hit Event")]
public class HitEvent : ScriptableObject
{
    public UnityAction<StanceEnum> OnEventRaised;

    /// <summary>
    /// Invoke the Hit Event with the stance payload
    /// </summary>
    /// <param name="payload">The stance that the hit came from</param>
    public void RaiseEvent(StanceEnum payload)
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke(payload);
        }
    }
}

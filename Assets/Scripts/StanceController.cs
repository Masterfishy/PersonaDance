using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the Poser's current stance and reactions
/// </summary>
public class StanceController : MonoBehaviour
{
    public Stance AStance;
    public Stance DStance;
    public Stance SStance;
    public Stance WStance;
    public Stance CurrentStance;

    public Sprite GetStanceSprite()
    {
        if (CurrentStance != null)
        {
            return CurrentStance.StanceSprite;
        }

        return null;
    }

    /// <summary>
    /// Check if the incoming stance hit is the weakness of the current stance
    /// </summary>
    /// <param name="stance">The incoming stance</param>
    /// <returns>True if the stance is the current stance's weakness; false otherwise</returns>
    public bool IsCriticalHit(StanceEnum stance)
    {
        return stance == CurrentStance.Weakness;
    }

    /// <summary>
    /// Event callback when the Poser is hit with a stance
    /// </summary>
    /// <param name="stance">The stance the Poser was hit with</param>
    public void OnHit(StanceEnum stance)
    {
        if (stance == CurrentStance.Weakness)
        {
            OnChangeStance(CurrentStance.Stagger);
        }
    }

    /// <summary>
    /// Event callback when the Poser changes stances
    /// </summary>
    /// <param name="stance">The stance to change to</param>
    public void OnChangeStance(StanceEnum stance)
    {
        switch (stance)
        {
            case StanceEnum.A:
                CurrentStance = AStance;
                break;
            case StanceEnum.D:
                CurrentStance = DStance;
                break;
            case StanceEnum.S:
                CurrentStance = SStance;
                break;
            case StanceEnum.W:
                CurrentStance = WStance;
                break;
            default:
                break;
        }
    }
}

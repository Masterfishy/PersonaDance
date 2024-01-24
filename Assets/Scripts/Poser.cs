using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poser : MonoBehaviour
{
    public StanceController StanceController;
    public HealthController HealthController;

    public SpriteRenderer SpriteRender;
    public Slider HealthSlider;

    /// <summary>
    /// The Poser's target
    /// </summary>
    public Poser Target;

    public void HitWith(StanceEnum stance)
    {
        if (StanceController != null)
        {
            bool isCriticalHit = StanceController.IsCriticalHit(stance);

            // Change stance if hit is critical
            if (isCriticalHit)
            { 
                StanceController.OnHit(stance);
            }

            // Deal damage
            if (HealthController != null)
            {
                HealthController.OnHit(isCriticalHit);
            }
        }
    }

    /// <summary>
    /// Callback for when this Poser takes the A stance
    /// </summary>
    public void OnA()
    {
        TakeAStance(StanceEnum.A);    
    }

    /// <summary>
    /// Callback for when this Poser takes the D stance
    /// </summary>
    public void OnD()
    {
        TakeAStance(StanceEnum.D);
    }

    /// <summary>
    /// Callback for when this Poser takes the S stance
    /// </summary>
    public void OnS()
    {
        TakeAStance(StanceEnum.S);
    }

    /// <summary>
    /// Callback for when this Poser takes the W stance
    /// </summary>
    public void OnW()
    {
        TakeAStance(StanceEnum.W);
    }

    /// <summary>
    /// Change the stance of the Poser
    /// </summary>
    /// <param name="stance">The stance to take</param>
    private void TakeAStance(StanceEnum stance)
    {
        if (StanceController != null)
        {
            StanceController.OnChangeStance(stance);

            // Hit the target with a stance
            if (Target != null)
            {
                Target.HitWith(stance);
            }
        }
    }

    private void OnEnable()
    {
        if (HealthSlider != null && HealthController != null)
        {
            HealthSlider.maxValue = HealthController.MaxHealth;
        }
    }

    private void LateUpdate()
    {
        if (SpriteRender != null && StanceController != null)
        {
            SpriteRender.sprite = StanceController.GetStanceSprite();
        }

        if (HealthSlider != null && HealthController != null)
        {
            HealthSlider.value = HealthController.CurrentHealth;
        }
    }
}

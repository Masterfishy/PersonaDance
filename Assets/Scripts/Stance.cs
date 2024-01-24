using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StanceEnum
{
    W,
    A,
    S,
    D
}

/// <summary>
/// This class represents a stance a poser can take. 
/// Each stance has a weakness and a stagger stance.
/// </summary>
[CreateAssetMenu(menuName ="Stance")]
public class Stance : ScriptableObject
{
    /// <summary>
    /// The stance's enum
    /// </summary>
    public StanceEnum stance;

    /// <summary>
    /// This stance's weakness
    /// </summary>
    public StanceEnum Weakness;

    /// <summary>
    /// The stance that a Poser moves to upon being hit with this stance's weakness.
    /// </summary>
    public StanceEnum Stagger;

    /// <summary>
    /// The sprite for the stance
    /// </summary>
    public Sprite StanceSprite;
}

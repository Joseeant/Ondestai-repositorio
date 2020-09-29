using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Option
{
    public string buttonText;
    [Range(-10, 10)]
    public int moneyModifier;
    [Range(-10, 10)]
    public int alcoholModifier;
    [Range(-10, 10)]
    public int funModifier;
    public Sprite image;
    public string resultText;
    public bool activateShortcut;
    public Vector2 direction;
}

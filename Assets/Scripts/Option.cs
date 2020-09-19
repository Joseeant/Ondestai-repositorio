﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Option
{
    public string buttonText;
    [Range(-10, 10)]
    public int alcoholModifier;
    [Range(-10, 10)]
    public int funModifier;
    [Range(-10, 10)]
    public int moneyModifier;
    public Sprite image;
    public string resultText;
}
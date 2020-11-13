using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum weapon { sword,shield }

[CreateAssetMenu(fileName = "New Object", menuName = "NW/ New Object", order = 100)]
public class Object : ScriptableObject
{
    public weapon weapon;
    public int resist;
    public int armor;
}

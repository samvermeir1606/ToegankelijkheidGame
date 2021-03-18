using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ControlSettings_Level",menuName ="ControlSettings")]
public class ControlSettings : ScriptableObject
{
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;
}

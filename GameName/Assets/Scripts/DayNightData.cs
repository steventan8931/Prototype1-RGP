using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DayNightData", menuName = "Data", order = 1)]
public class DayNightData : ScriptableObject
{
    public Gradient m_AmbientColor;
    public Gradient m_DirectionalColor;
    public Gradient m_FogColor;
}

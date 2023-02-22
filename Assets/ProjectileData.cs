using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "ScriptableAsset/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    public Color color;
    public float scale;
    public float speed;
}

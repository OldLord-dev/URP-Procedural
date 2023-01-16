using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(fileName = "treeData", menuName = "Tree Data", order = 50)]
public class TreeData : ScriptableObject
{
    //[SerializeField]
   // private SpriteSet asteroidsSpriteSet;
    [SerializeField]
    private float asteroidScale;

    [SerializeField]
    private float asteroidPoints;

    public float AsteroidScale { get { return asteroidScale; } }
    //public float AsteroidSpeed { get { return asteroidSpeed; } }
    public float AsteroidPoints { get { return asteroidPoints; } }
    //public SpriteSet AsteroidsSpriteSet { get { return asteroidsSpriteSet; } }
}

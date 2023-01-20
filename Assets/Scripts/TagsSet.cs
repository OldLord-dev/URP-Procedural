using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "objectToPoolTagSet", menuName = "Tags Set", order = 51)]
public class TagsSet : ScriptableObject
{
    [SerializeField]
    private String[] tags;
    public String[] Tags { get { return tags; } }
}
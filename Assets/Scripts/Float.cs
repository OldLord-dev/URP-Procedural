using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "float", menuName = "Float", order = 52)]
public class Float : ScriptableObject
{
    [SerializeField]
    private float eqSlot;
    public float GetEqSlot { get { return eqSlot; } }
    public void EqSlot(float slot) { eqSlot = slot; }
}
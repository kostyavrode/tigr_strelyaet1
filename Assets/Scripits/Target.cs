using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static Target instance;
    private void Awake()
    {
        instance = this;
    }
    public Transform GetTargetPosition()
    {
        return transform;
    }
}

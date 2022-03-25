using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static GameObject randomGameObjectWithTag(string tag) {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(tag);
        if (targetObjects.Length > 0) {
            return targetObjects[(int)((targetObjects.Length - 1) * Random.value)];
        } else {
            return null;
        }
    }
    
}

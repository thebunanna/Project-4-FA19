using System;
using UnityEngine;
using System.Collections.Generic;

public class SmoothFollowTargets : MonoBehaviour
{
    public float distance = 20;

    public static List<GameObject> targets = new List<GameObject>();
    Vector3 offset;

    bool b;
    Bounds bounds = new Bounds();

    public static void AddTarget(GameObject g)
    {
        targets.Add(g);
    }

    //void Start()
    //{
    //    offset = transform.position - target.transform.position;
    //}
    float d;
    void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }



        bounds.size = Vector3.zero;

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.RemoveAt(i);
                continue;
            }
            bounds.Encapsulate(targets[i].transform.position);
        }

        d = Mathf.Max(bounds.size.x * (9/16f), bounds.size.z) * 4f;
        d = Mathf.Clamp(d, distance, float.MaxValue);

        Vector3 tp = bounds.center + Vector3.up * d;
        transform.position = Vector3.Lerp(transform.position, tp, Time.deltaTime * 5);
    }
}


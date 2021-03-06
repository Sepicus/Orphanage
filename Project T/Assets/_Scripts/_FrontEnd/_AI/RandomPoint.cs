﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPoint : MonoBehaviour {
    public float range = 10.0f;
    bool randomPoint(Vector3 center, float range, out Vector3 result) {
        for (int i = 0; i < 2; i++) {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        StartCoroutine(PickPoint());
        return false;
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            StartCoroutine(PickPoint());
        }
    }

    IEnumerator PickPoint() {
        Vector3 point;
        if (randomPoint(transform.position, range, out point)) {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
        }
        yield return point;
    }
}
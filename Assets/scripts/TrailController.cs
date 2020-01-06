﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    public TrailPieceBank bank;
    public float waitingTimeBetweenTrailPieces = 0.2f;
    Coroutine leaveTrailCoroutine;

    // Update is called once per frame
    void Update()
    {
        if (!bank)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            leaveTrailCoroutine = StartCoroutine(LeaveTrail());
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(leaveTrailCoroutine);
        }
    }

    private IEnumerator LeaveTrail()
    {
        while (true)
        {
            bank.InstantiateTrailPiece(transform.position);
            yield return new WaitForSeconds(waitingTimeBetweenTrailPieces);
        }
    }
}
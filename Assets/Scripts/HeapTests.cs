﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeapTests
{
    public static bool[] validHeaps = new bool[7];
    public static int currentHeap = 6;

    public static int[] getHeap(int n) {
        Joint[] tmp = Joint.getJoints(n);
        return new int[] {tmp[0].hole1.content ? tmp[0].hole1.content.value : -1,
            tmp[0].hole2.content ? tmp[0].hole2.content.value : -1,
            tmp[1].hole2.content ? tmp[1].hole2.content.value : -1};
    }

    public static int getLastHeap() {
        for (int i = 6; i >= 0; i--){
            if (!validHeaps[i]) return i;
        }
        return -1;
    }
}
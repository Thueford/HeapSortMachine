using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joint : MonoBehaviour
{
    public Hole hole1;
    public Hole hole2;
    public int id;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake() {
        Globals.joints.Add(this);
    }

    public void onClick() {
        if (!(Globals.stage == Globals.Stage.STAGE_3 || Globals.stage == Globals.Stage.STAGE_4)) {
            Debug.Log("Wrong Stage");
            return;
        }
        if (hole1.content == null || hole2.content == null) {
            Debug.Log("One hole empty, swap canceled");
            return;
        }
        if (hole1.value != HeapTests.currentHeap) {
            Debug.Log("That heap is currently not active");
            Dialogue.notLastSubtree();
            return;
        }
        int[] heap = HeapTests.getHeap(hole1.value);

        if ((heap[1] == this.hole2.content.value && heap[1] < heap[2]) ||
                (heap[2] == this.hole2.content.value && heap[2] < heap[1])) {
            Debug.Log("One should swap only the larger ball up");

            Dialogue.changeLittleOne();

            return;
        }
        Ball.swapTwo(hole1.content, hole2.content);

        Globals.globals.heapChkBtns[hole1.value].GetComponent<Image>().sprite = ButtonHandler.self.sprHeapUnchk;
        HeapTests.validHeaps[hole1.value] = false;
        if (Globals.stage == Globals.Stage.STAGE_3 && hole1.value > 0) {
            Globals.globals.heapChkBtns[(int)Math.Floor((double)(hole1.value-1)/2)].GetComponent<Image>().sprite = ButtonHandler.self.sprHeapUnchk;
            HeapTests.validHeaps[(int)Math.Floor((double)(hole1.value-1)/2)] = false;
        }
        if (hole2.value < 7) {

            Dialogue.heap_destroy();

            int[] heapChild = HeapTests.getHeap(hole2.value);
            Debug.Log(heapChild);
            if (heapChild[1] != heapChild[2]) {
                Globals.globals.heapChkBtns[hole2.value].GetComponent<Image>().sprite = ButtonHandler.self.sprHeapUnchk;
                HeapTests.validHeaps[hole2.value] = false;
            }
        }
        HeapTests.currentHeap = HeapTests.getLastHeap();
    }

    public static Joint[] getJoints(int n) {
        if (n > 6) return null;
        Joint[] tmp = new Joint[2];
        foreach (Joint j in Globals.joints) {
            if (j.hole1.value == n) tmp[tmp[0] ? 1 : 0] = j;
        }
        return tmp[0].hole2.value < tmp[1].hole2.value ? tmp : new Joint[] {tmp[1], tmp[0]};
    }
}

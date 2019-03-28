using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCollectable : MonoBehaviour {
    public float LoadTime;
    public GameObject[] collectable= new GameObject [8];

    int[] order = new int[] { 0, 3, 6, 4, 7, 5, 2, 1 };
    int i;
	void Start () {
        i = 0;
        InvokeRepeating("InstCollectable", LoadTime, LoadTime);
	}

    void InstCollectable()
    {
        int n = order[i];
        collectable[n].SetActive(true);
        i++;

    }
}

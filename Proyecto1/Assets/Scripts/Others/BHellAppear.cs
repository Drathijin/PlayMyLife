using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHellAppear : MonoBehaviour {

    public GameObject[] bulletHells;
    public float TimeAppear, TimeDisappear;
    int n = 0, l = 0;
	
	// Update is called once per frame
	void Start () {
        InvokeRepeating("Appear", TimeAppear,TimeAppear );
        
        InvokeRepeating("Disappear", TimeDisappear,TimeDisappear );
        
    }
    void Appear()
    {
        bulletHells[n].SetActive(true);
        if (n < bulletHells.Length - 1)
        {
            n++;
        }
        else n = 0;

    }
    void Disappear()
    {
        
        bulletHells[l].SetActive(false);
        

        if (l < bulletHells.Length - 1)
        {
            l++;
        }
        else l = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProtections : MonoBehaviour
{
    public bool left, right, top;
    GameObject helmet, leftShield, rightShield;
    void Start()
    {
        helmet = transform.Find("Helmet").gameObject;
        leftShield = transform.Find("LeftShield").gameObject;
        rightShield = transform.Find("RightShield").gameObject;
        
        EquipShield(left, right, top);
    }

    private void EquipShield(bool left, bool right, bool top)
    {
        if (top)
        {
            helmet.SetActive(true);
        }
        else
            helmet.SetActive(false);

        if (left)
        {
            leftShield.SetActive(true);
        }
        else
            leftShield.SetActive(false);

        if (right)
        {
            rightShield.SetActive(true);
        }
        else
            rightShield.SetActive(false);
    }
}
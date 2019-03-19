using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPinPong : MonoBehaviour {

    public Transform pointB;
    public float speed;
    private Vector2 initialPos;
    private Vector2 finalPos;
    private Vector2 dir;
    int state;


    void Start()
    {
        if(transform.position.x > pointB.position.x)
        {
            initialPos = pointB.position;
            finalPos = transform.position;
        } else if(transform.position.x < pointB.position.x)
        {
            initialPos = transform.position;
            finalPos = pointB.position;
        } else if(transform.position.y > pointB.position.y)
        {
            initialPos = transform.position;
            finalPos = pointB.position;
        }
        else
        {
            initialPos = transform.position;
            finalPos = initialPos;
        }

        state = GetState(initialPos, finalPos);
        if (state == 4) this.enabled=false;
        dir = new Vector2(finalPos.x - initialPos.x, finalPos.y - initialPos.y);
    }
    void Update()
    {
        if (ChangeSpeed(initialPos, finalPos, transform.position, state))
        {
            speed *= -1;
        }
        transform.Translate(speed * Time.deltaTime * dir.normalized);
    }


    static bool ChangeSpeed(Vector2 a, Vector2 b, Vector2 position, int state)
    {
        switch (state)
        {
            case (1):
                {
                    if ((position.x < a.x && position.y < a.y) || (position.x > b.x && position.y > b.y)) return true;
                    return false;
                }
            case (2):
                {
                    if ((position.x < a.x && position.y > a.y) || (position.x > b.x && position.y < b.y)) return true;
                    return false;
                }
            case (3):
                {
                    if ((position.y < b.y) || (position.y > a.y)) return true;
                    return false;
                }
        }
        return true;
    }
    static int GetState(Vector2 a, Vector2 b)
    {
        if (a.y < b.y && a.x!=b.x) { return 1; }
        if (a.y > b.y && a.x != b.x) { return 2; }
        if (a.y != b.y ) { return 3; }
        return 4;
    }

}


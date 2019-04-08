using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHellShoot : MonoBehaviour {

    public float shootFreq = 2f;
    public Transform[] ShootPoints = new Transform[4]; //obtener los transforms de cada shootpoints como un array que más tarde facilita el uso de Random.
    public Bullet bullet;   // Prefab de bullet que tiene el script EnemyBullet
    private GameObject pool;

    void Start()
    { 
        pool = GameObject.Find("BulletPool");
        InvokeRepeating("ShootBullet", 0.5f, shootFreq);   //Invocar shootBullet
    }
    void ShootBullet()
    {
        int n = Random.Range(0, ShootPoints.Length-1);  //Un nº aleatorio entre [0,3] que corresponde a los 4 shootpoints de bullethell
        Bullet newbullet = Instantiate(bullet, ShootPoints[n].position, Quaternion.identity, pool.transform);  // instanciar la bala en shootpoint correpondiente al numero aleatorio
        Vector2 newDir = new Vector2(ShootPoints[n].position.x - transform.position.x, ShootPoints[n].position.y - transform.position.y);  // vector direccion que envia a changeDirecion de bullet
        // corresponde al vector formado por la posicion de Bullet hell con su shootpoint.
        newbullet.ChangeDir(newDir);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject ObjParticle;
    private float TimeDirect = 0f;
    private Vector3 target = new Vector3(0,1850,0);
    private int direct = 1;
    void Update()
    {
        TimeDirect += (100 * Time.deltaTime);
        int tidirect = (int)TimeDirect;
        if ((tidirect % 35) == 0) direct *=-1;
        float speed = (Random.Range(1.0f, 1.5f));
        target.x = ObjParticle.transform.position.x + (2000* direct);

        Vector3 Move = (target - ObjParticle.transform.position).normalized;
        ObjParticle.transform.position += Move * speed * Time.deltaTime;
        Destroy(ObjParticle,1.9f);

    }
}

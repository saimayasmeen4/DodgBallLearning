using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_3 : MonoBehaviour
{
    public GameObject ball; //ball1, ball2;
    GameObject b, b1, b2,b3;
    GameObject[] balls;
    public float spownTime, t1, t2, t3;
    public float SpawnDelay, d1, d2, d3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("createBall", spownTime, SpawnDelay);
        InvokeRepeating("CreateBall1", t1, d1);
        InvokeRepeating("CreateBall2", t2, d2);
        InvokeRepeating("CreateBall3", t3, d3);
    }

    private GameObject createBall()
    {
        Vector3 pos;
        pos.x = -48;
        pos.y = -34;
        pos.z = 48;
        b = Instantiate(ball) as GameObject;
        b.AddComponent<Rigidbody>();
        b.GetComponent<Rigidbody>().useGravity = false;
        b.transform.position = pos;
        b.GetComponent<Rigidbody>().AddForce(-600,-1000,0);

        return (b);
    }

    private GameObject CreateBall1()
    {
        Vector3 pos1;
        pos1.x = -48;
        pos1.y = -175;
        pos1.z = 48;
        b1 = Instantiate(ball) as GameObject;
        b1.AddComponent<Rigidbody>();
        b1.GetComponent<Rigidbody>().useGravity = false;
        b1.transform.position = pos1;
        b1.GetComponent<Rigidbody>().AddForce(-500,1000, 0);

        return b1;
    }

    private GameObject CreateBall2()
    {
        Vector3 pos2;
        pos2.x = -316;
        pos2.y = -34;
        pos2.z = 48;
        b2 = Instantiate(ball) as GameObject;
        b2.AddComponent<Rigidbody>();
        b2.GetComponent<Rigidbody>().useGravity = false;
        b2.transform.position = pos2;
        b2.GetComponent<Rigidbody>().AddForce(500,-1000, 0);

        return b2;
    }

    private GameObject CreateBall3()
    {
        Vector3 pos3;
        pos3.x = -314;
        pos3.y = -175;
        pos3.z = 48;
        b3 = Instantiate(ball) as GameObject;
        b3.AddComponent<Rigidbody>();
        b3.GetComponent<Rigidbody>().useGravity = false;
        b3.transform.position = pos3;
        b3.GetComponent<Rigidbody>().AddForce(500,1000, 0);

        return b3;
    }
}

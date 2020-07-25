using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MLAgents;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine.SceneManagement;
public class DuckAgent : Agent
{
    float moveSpeed = 5f;
    new private Rigidbody rigidBody;
    public GameObject duck, ball;
    public GameObject[] borders;

    //EnvironmentParameters resetParams;
    //Vector3 initialPosition = duck.transform.position;

    public override void Initialize()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    public override void OnActionReceived(float[] vectorAction)
    {
        Vector2 move = new Vector2(vectorAction[0], vectorAction[1]);
        rigidBody.AddForce(move * moveSpeed);
        if(Vector3.Distance(ball.transform.position, transform.position)>0.01)
        {
            SetReward(1f);
        }

        if (Vector3.Distance(borders[0].transform.position, transform.position) < 0.01)
        {
            SetReward(-1f);
        }

       else if (Vector3.Distance(borders[1].transform.position, transform.position) < 0.01f)
        {
            SetReward(-1f);
        }

       else if (Vector3.Distance(borders[2].transform.position, transform.position) < 0.01f)
        {
            SetReward(-1f);
        }

       else if (Vector3.Distance(borders[3].transform.position, transform.position) < 0.01f)
        {
            SetReward(-1f);
        }
        else
        {
            SetReward(0.1f);
        }
        //SetReward(1f);
    }
    

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.position);
        sensor.AddObservation(Vector3.Distance(ball.transform.position, transform.position));
        sensor.AddObservation(Vector3.Distance(borders[0].transform.position, transform.position));
        sensor.AddObservation(Vector3.Distance(borders[1].transform.position, transform.position));
        sensor.AddObservation(Vector3.Distance(borders[2].transform.position, transform.position));
        sensor.AddObservation(Vector3.Distance(borders[3].transform.position, transform.position));
    }

    public override void Heuristic(float[] actionsOut)
    {
        Vector3 farword = Vector3.zero;
        Vector3 left = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) farword = transform.up;
        else if (Input.GetKey(KeyCode.DownArrow)) farword = -transform.up;

        if (Input.GetKey(KeyCode.LeftArrow)) left = -transform.right;
        else if (Input.GetKey(KeyCode.RightArrow)) left = transform.right;

        Vector3 combined = (farword + left).normalized;
        actionsOut[0] = combined.x;
        actionsOut[1] = combined.y;
    }
    public override void OnEpisodeBegin()
    {
        Vector3 pos;
        pos.x = -200; pos.y = -100; pos.z = 48;
        duck.transform.position = pos;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("ball"))
        {
            SetReward(-5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            EndEpisode();
        }
        if(collision.transform.CompareTag("wall"))
        {
            SetReward(-5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            EndEpisode();
        }
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FlightScript : MonoBehaviour
{

    public float AmbientSpeed = 100.0f;

    public float RotationSpeed = 100.0f;

    public float Boost = 100.0f;

    private Rigidbody _rigidBody;

    public GameObject plane;


    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        UpdateFunction();
    }

    void UpdateFunction()
    {

        Quaternion AddRot = Quaternion.identity;
        float roll = 0;
        float pitch = 0;
        float yaw = 0;


        roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime * RotationSpeed);
        pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * RotationSpeed);
        yaw = Input.GetAxis("Yaw") * (Time.fixedDeltaTime * RotationSpeed);
        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        _rigidBody.rotation *= AddRot;
        Vector3 AddPos = Vector3.forward;
        AddPos = _rigidBody.rotation * AddPos;
        _rigidBody.velocity = AddPos * (Time.fixedDeltaTime * AmbientSpeed);

        if (Input.GetButton("Boost"))
        {
            _rigidBody.velocity = AddPos * (Time.fixedDeltaTime * Boost);
        }


        //plain collition
        float TerrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
        if (TerrainHeight+2 > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, TerrainHeight + 2, transform.position.z);
        }
    }
}

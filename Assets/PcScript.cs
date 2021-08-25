using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcScript : MonoBehaviour
{
    private Rigidbody rbd;
    public float velocity = 10;
    private Quaternion rotIni;
    private float rotY;
    public float velRotY = 100;
    private AudioSource som;
    public LayerMask mask;
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rbd = GetComponent<Rigidbody>();
        rotIni = transform.localRotation;
        som = GetComponent<AudioSource>();
        rotY = 0;
        points = 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pill")
        {
            PlacarScript.score += points;
            DestroyObject(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveFront = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        rbd.velocity = new Vector3(moveHorizontal * velocity, rbd.velocity.y, moveFront * velocity);

        rotY += Input.GetAxis("Mouse X") * Time.deltaTime * velRotY;

        Quaternion lado = Quaternion.AngleAxis(rotY, Vector3.up);

        transform.localRotation = rotIni * lado;

        rbd.velocity = transform.TransformDirection(new Vector3(moveHorizontal * velocity, rbd.velocity.y, moveFront * velocity));

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            som.Play();

            RaycastHit hit;

            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100, mask))
            {
                Debug.Log("Tiro");
                hit.collider.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 500);
            }
        }
    }
}

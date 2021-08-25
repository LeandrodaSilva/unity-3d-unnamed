using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    private Quaternion rotIni;
    private float rotX;
    public float velRot = 100;

    // Start is called before the first frame update
    void Start()
    {
        rotIni = transform.localRotation;
        rotX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rotX += Input.GetAxis("Mouse Y") * Time.deltaTime * velRot;
        rotX = Mathf.Clamp(rotX, -60, 60);

        Quaternion head = Quaternion.AngleAxis(rotX, Vector3.left);

        transform.localRotation = rotIni * head;
    }
}

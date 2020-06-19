using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollow : MonoBehaviour
{
    [SerializeField]
    float sensitivity = 10f, xRotPos = 0f, yRotPos = 0f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // makes sure cursor is not visible and is locked to the game view
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // makes sure game object follows player
        transform.position = player.transform.position;

        // get inputs
        float xRot = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        float yRot = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        xRotPos = Mathf.Clamp(xRotPos - xRot, -50f, 12.5f);
        yRotPos += yRot;

        // apply rotation

        transform.localRotation = Quaternion.Euler(xRotPos, yRotPos, 0f);

    }
}

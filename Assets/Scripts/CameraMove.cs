using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{


    public int speedPlayer;
    private Vector2 moveVelociti;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelociti = moveInput.normalized * speedPlayer * Time.deltaTime;
        transform.position += (Vector3)moveVelociti;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Authors : Julien and Settha

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim;
    private bool moving;
    private Vector2 lastMove;

    void Start()
    {
        anim = GetComponent<Animator>();
        lastMove.y = -1;
    }

    // Update is called once per frame
    void Update()
    {
        moving = false;
        if (Input.GetAxisRaw("Horizontal") > 0f ||  Input.GetAxisRaw("Horizontal") < 0f)
        {
            moving = true;
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f)
        {
            moving = true;
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));

        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("Moving", moving);
		anim.SetFloat("LastMoveX",lastMove.x);
		anim.SetFloat("LastMoveY",lastMove.y);
    }

    ///<summary>
    /// Teleport the player to the given position
    ///<remaks> In our game, the z axes never change, so it is automatically set to 0, but if it needed, we can change it.</remaks>
    ///</summary>
    public void Teleport(float tpx, float tpy, float tpz = 0)
    {
        Vector3 tpposition;
        tpposition.x = tpx;
        tpposition.y = tpy;
        tpposition.z = tpz;
        transform.position = tpposition;
    }


    ///<summary>
    /// Change the poistionn of the camera and allow to zoom on the player if needed.
    ///<remaks> In our game, the x axes of our camera never change and is always 0, but if needed, we can change it.</remaks>
    ///</summary>
    public void ChangeCamerPosition(float camy, float camz, float camx = 0)
    {
        Transform camera = transform.GetChild(0);
        Vector3 cameraposition;
        cameraposition.x = camx;
        cameraposition.y = camy;
        cameraposition.z = camz;
        camera.position = cameraposition;
    }
}

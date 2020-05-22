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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Vector2 mousePos = Input.mousePosition;
            mousePos.x -= Screen.width / 2;
            mousePos.y -= Screen.height / 2;

            Vector3 moveDirection = new Vector2(mousePos.x, mousePos.y);

            rb.MovePosition(transform.position + moveDirection.normalized * speed * Time.fixedDeltaTime);

            //Animation
            if (moveDirection.x >= 0) transform.localScale = new Vector3(1, 1, 1);
            else transform.localScale = new Vector3(-1, 1, 1);

            anim.SetBool("Moving", true);
        }
        else anim.SetBool("Moving", false);
    }
}

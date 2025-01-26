using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingPart : MonoBehaviour
{
    private Vector2 difference;
    private Rigidbody2D rigidBody;
    private MovingPart movingPart;

    public GameObject nextWindow;
    public Button runeButton;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        movingPart = GetComponent<MovingPart>();
    }

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        //transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - difference.x, transform.position.y);
    }

    private void OnMouseUp()
    {
        rigidBody.gravityScale = 1;

        if(nextWindow != null)
        {
            nextWindow.SetActive(true);
        }
        if (gameObject.GetComponent<Hilt>())
        {
            if(gameObject.GetComponent<Hilt>().haveRune == true)
            {
                runeButton.interactable = true;
            }
        }
        Destroy(movingPart);
    }
}

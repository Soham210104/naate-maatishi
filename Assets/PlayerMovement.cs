using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = true;
    private float moveDuration = 20f;  // Duration in seconds
    private float timer = 0f;

    void Update()
    {
        if (canMove)
        {
            timer += Time.deltaTime;

            if (timer > moveDuration)
            {
                canMove = false;
            }
            else
            {
                MovePlayer();
            }
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");  // A/D or Left/Right
        float moveY = Input.GetAxis("Vertical");    // W/S or Up/Down
        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        // Move the player by setting the position for 2D
        transform.Translate(movement);
    }
}

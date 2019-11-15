using UnityEngine;

public class PlayerDetector2 : MonoBehaviour
{
    public PlayerController Player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            Player.JumpCountLeft = Player.MaxJumpCount;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            Player.JumpCountLeft = 0;
        }
    }
}
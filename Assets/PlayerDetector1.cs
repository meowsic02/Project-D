using UnityEngine;

public class PlayerDetector1 : MonoBehaviour
{
    public PlayerController Player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Object")
            Player.Detected1 = collision.name;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Ladder" && (Player.rigid.constraints & RigidbodyConstraints2D.FreezePositionY) == RigidbodyConstraints2D.FreezePositionY)
        {
            Player.rigid.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            Player.State = "Normal";
        }

        if (collision.tag == "Object")
            Player.Detected1 = null;
    }
}

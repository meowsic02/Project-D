using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int MaxJumpCount = 1;
    public int JumpCountLeft = 0;

    public float WalkSpeed = 1f;
    public float JumpForce = 1f;
    public float ClimbSpeed = 1f;

    public string Detected1 = null;
    public string State = "Normal";

    public Rigidbody2D rigid;

    public GameObject Inventory;
    public GameObject EscMenu;

    bool InventoryOpen = false;
    bool EscMenuOpen = false;

    bool Key_A = false;
    bool Key_D = false;
    bool Key_W = false;
    bool Key_S = false;
    bool Key_Space = false;

    int screenHeight = 800;
    int screenWidth = 800;

    private void Awake()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    private void Update()
    {
        MoveKeyDetection();
        UIKey();
        EscKey();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void MoveKeyDetection()
    {
        if (Input.GetKey(KeyCode.A))
            Key_A = true;
        if (Input.GetKey(KeyCode.D))
            Key_D = true;
        if (Input.GetKey(KeyCode.Space))
            Key_Space = true;
        if (Input.GetKey(KeyCode.W))
            Key_W = true;
        if (Input.GetKey(KeyCode.S))
            Key_S = true;
    }

    void Move() //움직임(물리) 함수
    {
        //보통상태 일때
        if (State == "Normal")
        {
            if (Key_A)
            {
                rigid.transform.Translate(Vector2.left * WalkSpeed * Time.deltaTime);
                Key_A = false;
            }
            else if (Key_D)
            {
                rigid.transform.Translate(Vector2.right * WalkSpeed * Time.deltaTime);
                Key_D = false;
            }

            if (Key_Space)
            {
                if (JumpCountLeft > 0)
                {
                    rigid.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                    JumpCountLeft--;
                }
                Key_Space = false;
            }

            if (Key_W)
            {
                if (Detected1 == "Ladder")
                {
                    State = "isClimbing";
                    rigid.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                    rigid.transform.Translate(Vector2.up * ClimbSpeed * Time.deltaTime);
                }
                Key_W = false;
            }
            else if (Key_S)
            {
                if (Detected1 == "Ladder")
                {
                    State = "isClimbing";
                    rigid.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                    rigid.transform.Translate(Vector2.down * ClimbSpeed * Time.deltaTime);
                }
                Key_S = false;
            }
        }

        //(사다리, 로프 등)오르는상태 일때
        if (State == "isClimbing")
        {
            if (Key_A)
            {
                Key_A = false;
            }
            else if (Key_D)
            {
                Key_D = false;
            }

            if (Key_Space)
            {
                rigid.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
                rigid.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                State = "Normal";
                Key_Space = false;
            }

            if (Key_W)
            {
                if (Detected1 == "Ladder")
                {
                    rigid.transform.Translate(Vector2.up * ClimbSpeed * Time.deltaTime);
                }
                Key_W = false;
            }
            else if (Key_S)
            {
                if (Detected1 == "Ladder")
                {
                    rigid.transform.Translate(Vector2.down * ClimbSpeed * Time.deltaTime);
                }
                Key_S = false;
            }
        }
    }

    void UIKey() //UI 관련 키
    {
        //인벤토리 키
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!InventoryOpen)
            {
                Inventory.GetComponent<RectTransform>().sizeDelta = new Vector2(screenWidth / 5 * 4, screenHeight / 10 * 7);
                Inventory.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Screen.width / 3 / 5, Screen.width / 3 / 5);

                Inventory.SetActive(true);
                InventoryOpen = true;
            }
            else if (InventoryOpen)
            {
                Inventory.SetActive(false);
                InventoryOpen = false;
            }
        }
    }

    void EscKey() //Esc키
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!EscMenuOpen)
            {
                EscMenu.GetComponent<RectTransform>().sizeDelta = new Vector2(screenWidth, screenHeight);

                Time.timeScale = 0;
                EscMenu.SetActive(true);
                EscMenuOpen = true;
            }
            else if (EscMenuOpen)
            {
                Time.timeScale = 1;
                EscMenu.SetActive(false);
                EscMenuOpen = false;
            }
        }
    }
}

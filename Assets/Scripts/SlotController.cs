using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public GridLayoutGroup Gridgroup;
    Transform[] Slot = null;

    private void OnEnable()
    {
        /*for (int i = 0; i < transform.childCount; i++)
        {
            Slot[i] = transform.GetChild(i);
            Debug.Log(transform.GetChild(i));
            Debug.Log(transform.childCount);
        }*/
    }

    void Awake()
    {

    }

    void Update()
    {
    }
}

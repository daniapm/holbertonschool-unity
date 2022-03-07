using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private Transform transf;
    private Vector3 offset;
    public GameObject player;
    public Toggle InvertedYMode;
    public bool isInverted = false;
    private int inverted;
    public float speed = 5.0f;

    void Start()
    {
        if (InvertedYMode)
            isInverted = true;
        transf = GetComponent<Transform>();
        offset = transf.position - player.transform.position;
    }

    void Update()
    {
        if (isInverted)
        {
            inverted = -1;
        }
        else
        {
            inverted = 1;
        }
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * speed, Vector3.left) * offset;
        transf.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
}

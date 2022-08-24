using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public GameObject player;
    public float offset;
    private Vector3 playerPosition;

    // Update is called once per frame
    void Start()
    {
    }

    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3 (playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        transform.position = playerPosition;
    }
}
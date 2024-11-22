using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float yMin;
    [SerializeField] float yMax;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}

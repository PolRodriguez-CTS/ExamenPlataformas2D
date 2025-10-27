using UnityEngine;

public class Star : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    void Awake()
    {
        _sceneLoader = FindFirstObjectByType<SceneLoader>().GetComponent<SceneLoader>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _sceneLoader.Victory();
            Destroy(gameObject);
        }
    }
}

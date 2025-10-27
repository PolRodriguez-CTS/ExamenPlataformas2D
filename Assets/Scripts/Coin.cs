using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager _gameManager;

    void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>().GetComponent<GameManager>();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _gameManager.AddCoin();
            Destroy(gameObject);
        }
    }
}

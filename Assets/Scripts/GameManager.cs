using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _coins;
    [SerializeField] private Text _coinsText;

    void Start()
    {
        _coins = 0;
        _coinsText.text = ": 0";
    }

    public void AddCoin()
    {
        _coins += 1;
        _coinsText.text = ": " + _coins.ToString();
    }
}

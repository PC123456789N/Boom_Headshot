using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    int score, shots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        shots = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreseScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }

    public void IncreaseShots()
    {
        shots++;
    }

    public int GetShots()
    {
        return shots;
    }
}

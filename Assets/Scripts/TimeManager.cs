using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 1f;

    private float originalFixedUpdate;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        originalFixedUpdate = Time.fixedDeltaTime;
    }

    private void Start()
    {
        gameManager.OnPlayerJoinedNotice += GameManager_OnPlayerJoinedNotice;
    }

    private void GameManager_OnPlayerJoinedNotice(Player player)
    {
        player._PlayerHit += Player__PlayerHit;
    }

    private void Player__PlayerHit()
    {
        DoSlowmotion();
    }

    private void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        if (Time.timeScale != 1.0f)
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            Time.fixedDeltaTime = Time.timeScale * .02f;
        }
    }
    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}

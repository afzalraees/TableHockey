using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize
{
    public static float GetScreenToWorldHeight
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
            var height = edgeVector.y * 2;
            return height;
        }
    }
    public static float GetScreenToWorldWidth
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
            var width = edgeVector.x * 2;
            return width;
        }
    }
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UIManager uiManager;
    public PlayerMovement player;
    public EnemyScript enemy;
    public PuckManager puck;

    public Transform bg;

    public int score;
    public int record;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this);
    }

    private void Start()
    {
        Time.timeScale = 0;
        float width = ScreenSize.GetScreenToWorldWidth;
        bg.localScale = Vector3.one * width;
        LoadRecord();
    }

    void LoadRecord()
    {
        if(PlayerPrefs.HasKey("Record"))
        {
            record = PlayerPrefs.GetInt("Record");
            Debug.Log(record);
            uiManager.record.text = record.ToString();
        }
        else
            PlayerPrefs.SetInt("Record", record);
    }

    public void Goal()
    {
        score++;
        uiManager.UpdateScore(score);
        player.transform.position = player.centrePos;
        enemy.transform.position = enemy.centrePos;
        enemy.isActive = false;
        puck.transform.position = Vector3.down;
        puck.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if(score % 5 == 0)
        {
            enemy.speed += 0.25f;
        }
        if(score > record)
        {
            record = score;
        }
    }

    public void ResetPlay()
    {
        player.transform.position = player.centrePos;
        enemy.transform.position = enemy.centrePos;
        puck.transform.position = Vector3.down;
        puck.rb.velocity = Vector3.zero;
        score = 0;
        enemy.speed = 1;
        Time.timeScale = 1;
    }


}

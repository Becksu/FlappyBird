using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int m_point;
    public bool isEndGame;
    private bool isStartFirstTime;

    [SerializeField] private Text txtPoint;
    [SerializeField] private Text txtEnd;
    [SerializeField] private GameObject m_panel;
    [SerializeField] private Button button;
    [SerializeField] private Sprite bntIdle;
    [SerializeField] private Sprite bntHover;
    [SerializeField] private Sprite bntClick;



    //[SerializeField] private float scalelengt;
    // Start is called before the first frame update
    void Start()
    {
        OnInit();

    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButtonDown(0)&& isStartFirstTime)
            {
                StartGame();
            }
        }
        else
        {
            if ((Input.GetMouseButtonDown(0)))
            {
                Time.timeScale = 1;
            }
           
        }
    }

    public void RestartButtonClick()
    {
        button.GetComponent<Image>().sprite = bntClick;
    }
    public void RestartButtonHover()
    {
        button.GetComponent<Image>().sprite = bntHover;
    }
    public void RestartButtonIdle()
    {
        button.GetComponent<Image>().sprite = bntIdle;
    }
    public void OnInit()
    {
        isEndGame = false;
        Time.timeScale = 0f;
        m_panel.SetActive(false);
        isStartFirstTime = true;


    }
    public void StartGame()
    {
        EditorSceneManager.LoadScene(0);
    }
    public void ReStartGame()
    {
        StartGame();
    }
    public void EndGame() 
    {
        //Time.timeScale += (1f / scalelengt) * Time.unscaledDeltaTime;
        //Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        Time.timeScale = 0;
        isEndGame = true;
        m_panel.SetActive(true);
        txtEnd.text = "Your point /n" + m_point.ToString();
        isStartFirstTime = false;
    }
    
    public void GetPoint()
    {
        m_point++;
        txtPoint.text = "Point " + m_point.ToString();
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float birdpower;
    [SerializeField] private Rigidbody2D m_bird;
    [SerializeField] private GameController m_controller;
    [SerializeField] private AudioClip fly_audio;
    [SerializeField] private AudioClip gameover_audio;

    [SerializeField] private AudioSource audioSource;

    private bool endGame;

    private void Start()
    {
        
        audioSource.clip = fly_audio;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!m_controller.isEndGame)
            {
                audioSource.Play();
            }
           
            m_bird.AddForce(new Vector2(0, birdpower));
       
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            m_controller.GetPoint();
        }
    }
    public void EndGame()
    {
        audioSource.clip = gameover_audio;
        audioSource.Play();
        m_controller.EndGame();
    }
}

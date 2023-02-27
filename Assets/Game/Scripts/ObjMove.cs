using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float oldpos;

    private GameObject m_gameobject;
   
    
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
      
        MoveObj();
      
    }

    public void OnInit()
    {
        m_gameobject = gameObject;
       
    }
    public void MoveObj()
    {
        m_gameobject.transform.Translate( new Vector3(-1 * Time.deltaTime * speed, 0, 0));   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Reset"))
        {
            m_gameobject.transform.position = new Vector3(oldpos,Random.Range(minY,maxY),0);
        }
       
    }
}

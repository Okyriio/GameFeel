using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    private Health _health;
   
    [SerializeField] private ScreenShake _cam;
    
    public ScreenShake Cam
    {
        get => _cam;
        set => _cam = value;
    }

    void Start()
    {
       
        _health = GetComponent<Health>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            _health.Hurt(1);
            Cam.TriggerShortShake();
        }
    }
}

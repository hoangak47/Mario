using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform Player;
    private float minX = 0, maxX = 28;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            Vector3 Vitri = transform.position;
            Vitri.x = Player.position.x;
            if (Vitri.x < minX) Vitri.x = 0;
            if (Vitri.x > maxX) Vitri.x = maxX;
            transform.position = Vitri;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    float m_shootTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputer();
    }

    private void UpdateInputer()
    {
        m_shootTimer -= Time.deltaTime;

        Vector3 ms = Input.mousePosition;
        ms = Camera.main.ScreenToWorldPoint(ms);

        Vector3 myPos = this.transform.position;

        Vector2 targetDir = ms - myPos;
        float angle = Vector2.Angle(targetDir, Vector3.up);

        if (ms.x > myPos.x)
        {
            angle = -angle;
        }

        this.transform.eulerAngles = new Vector3(0, 0, angle);

        if (Input.GetMouseButton(0))
        {
            if (m_shootTimer <= 0)
            {
                m_shootTimer = 0.1f;

                Fire.Create(this.transform.TransformPoint(0, 1, 0), new Vector3(0, 0, angle));
            }
        }
    }
}

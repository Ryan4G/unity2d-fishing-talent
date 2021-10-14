using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float m_moveSpeed = 10.0f;

    public static Fire Create(Vector3 pos, Vector3 angle)
    {
        GameObject prefab = Resources.Load<GameObject>("fire");

        GameObject fireSprite = (GameObject)Instantiate(prefab, pos, Quaternion.Euler(angle));

        Fire f = fireSprite.AddComponent<Fire>();
        Destroy(fireSprite, 2.0f);
        return f;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Fish f = collision.GetComponent<Fish>();
        if (f == null)
        {
            return;
        }
        else
        {
            f.SetDamage(1);
        }

        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0, m_moveSpeed * Time.deltaTime, 0));
    }
}

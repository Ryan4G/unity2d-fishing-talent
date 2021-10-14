using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public float timer = 0;
    public int max_fish = 30;

    public int fish_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 2.0f;

            if (fish_count >= max_fish)
            {
                return;
            }

            int index = Mathf.FloorToInt(UnityEngine.Random.value * 3.0f + 1);

            if (index > 3)
            {
                index = 3;
            }

            fish_count++;

            GameObject fishprefab = (GameObject)Resources.Load($"fish{index}");

            float cameraz = Camera.main.transform.position.z;

            Vector3 randpos = new Vector3(UnityEngine.Random.value, UnityEngine.Random.value, -cameraz);
            randpos = Camera.main.ViewportToWorldPoint(randpos);

            Fish.Target target = UnityEngine.Random.value > 0.5f ? Fish.Target.Left : Fish.Target.Right;
            Fish f = Fish.Create(fishprefab, target, randpos);

            f.OnDeath += OnDeath;
        }
    }

    void OnDeath(Fish fish)
    {
        fish_count--;
    }
}

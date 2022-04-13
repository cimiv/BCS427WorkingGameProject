using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameState state;
    public float speed = 10.0f;
    public float minDist = 1f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnGameStateChanged += GMOnGameStateChanged;

        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
    }

    private void GMOnGameStateChanged(GameState obj)
    {
        state = obj;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GMOnGameStateChanged;

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        transform.LookAt(target);

        float dist = Vector3.Distance(transform.position, target.position);

        if (dist > minDist && state == GameState.Playing)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Rigidbody>().CompareTag("Player"))
        {
            GameManager.Instance.playerHealth -= 1;
            Destroy(gameObject); // this will reduce hp by 1 and then destroy the "enemy"
        }
    }
}

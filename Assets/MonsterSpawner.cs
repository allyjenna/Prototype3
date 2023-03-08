using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject monsterPrefab;
    public int enemyCount;
    //public float speed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 15)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-14, 14), 0, Random.Range(0, 22));
            GameObject newMonster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
            newMonster.GetComponent<FollowPlayer>().player = player;
            newMonster.AddComponent<Animator>();
            newMonster.GetComponent<Animator>().runtimeAnimatorController = animator.runtimeAnimatorController;
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            enemyCount += 1;
        }
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        direction = direction.normalized;
        //transform.Translate(direction * speed * Time.deltaTime, Space.World);
        animator.SetFloat("Speed", distance);
    }
}

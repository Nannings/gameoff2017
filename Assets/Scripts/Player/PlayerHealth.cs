using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Transform healthPacksContainer;
    public GameObject healthPackPrefab;

    public int healthPacksNumber = 4;

	void Start ()
    {
        for (int i = 0; i < healthPacksNumber; i++)
            AddHealthPack();
	}

    void Update()
    {
        if (IsDead())
            SceneManager.LoadScene("Game");
    }

    void AddHealthPack()
    {
        if (healthPackPrefab != null)
        {
            Instantiate(healthPackPrefab, healthPacksContainer);
        }
    }

    void RemoveHealthPack()
    {
        Destroy(GameObject.FindGameObjectWithTag("HealthPack"));
        healthPacksNumber--;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "EnemyBullet")
        {
            RemoveHealthPack();
            Destroy(coll.gameObject);
        }
    }

    private bool IsDead()
    {
        return healthPacksNumber <= 0;
    }
}
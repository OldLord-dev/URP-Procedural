using UnityEngine;

public class Tree : MonoBehaviour
{
   // [SerializeField]
   // public Event onAsteroidDestroyed;
    [SerializeField]
   // private TreeData treeData;
    //private SpriteRenderer spriteRenderer;
    //private Rigidbody2D rb;
    //private Vector2 randomDirection;
    void Start()
    {

    }

    private void OnEnable()
    {
    //    if (asteroidData.AsteroidsSpriteSet.Sprites.Count > 0 && spriteRenderer)
    //    {
    //        spriteRenderer.sprite = asteroidData.AsteroidsSpriteSet.Sprites[Random.Range(0, asteroidData.AsteroidsSpriteSet.Sprites.Count)];
    //    }
    //    transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), new Vector3(0, 0, 1)) * transform.rotation;
    //    randomDirection = Random.insideUnitCircle.normalized * asteroidData.AsteroidSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        //rb.velocity = randomDirection;
    }

    //private void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.CompareTag("Bullet"))
    //    {
    //        GameManager.score += asteroidData.AsteroidPoints;
    //        gameObject.SetActive(false);
    //    }
    //    else
    //        gameObject.SetActive(false);

    //    onAsteroidDestroyed.Occurred();
    //}


}

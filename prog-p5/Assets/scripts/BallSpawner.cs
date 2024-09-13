using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject prefab;
    private float elapsedTime = 0f;

    private void Start()
    {
        // Maak in één keer 100 ballen aan in de Start
        for (int i = 0; i < 100; i++)
        {
            Color randColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
            Vector3 randPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(1f, 10f), Random.Range(-10f, 10f));
            GameObject ball = CreateBall(randColor, randPosition);
            DestroyBall(ball);
        }
    }

    private void Update()
    {
     
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1f)
        {
            Color randColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
            Vector3 randPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(1f, 10f), Random.Range(-10f, 10f));

            GameObject ball = CreateBall(randColor, randPosition);
            DestroyBall(ball);

            elapsedTime = 0f;
        }
    }

    //CreateBall met Color en position
    private GameObject CreateBall(Color c, Vector3 position)
    {
        GameObject ball = Instantiate(prefab, position, Quaternion.identity);
        Material material = ball.GetComponent<MeshRenderer>().material;
        material.SetColor("_Color", c);

        return ball;
    }

    //DestroyBall om het object na 3 seconden te vernietigen
    private void DestroyBall(GameObject ball)
    {
        Destroy(ball, 3f);
    }
}

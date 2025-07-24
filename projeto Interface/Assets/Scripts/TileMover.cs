using UnityEngine;

public class TileMover : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}

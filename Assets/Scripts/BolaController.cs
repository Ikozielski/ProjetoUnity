using UnityEngine;

public class BolaController : MonoBehaviour
{
    public float velocidadeInicial = 5f;
    public float incrementoPorToque = 0.01f; // 1% por toque na raquete
    public float cooldownToque = 0.1f;

    Rigidbody2D rb;
    float ultimoToque = -1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sacar();
    }

    void Sacar()
    {
        float angulo;
        do
        {
            angulo = Random.Range(0f, 360f);
        }
        while (PertoDoAnguloReto(angulo));

        float radianos = angulo * Mathf.Deg2Rad;
        Vector2 direcao = new Vector2(Mathf.Cos(radianos), Mathf.Sin(radianos));
        rb.linearVelocity = direcao * velocidadeInicial;
    }

    bool PertoDoAnguloReto(float angulo)
    {
        return Mathf.Abs(Mathf.DeltaAngle(angulo, 90f)) < 10f
            || Mathf.Abs(Mathf.DeltaAngle(angulo, 270f)) < 10f;
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (Time.time - ultimoToque < cooldownToque)
            return;
        ultimoToque = Time.time;

        if (colisao.gameObject.CompareTag("Raquete") || colisao.gameObject.CompareTag("Parede"))
        {
            rb.linearVelocity *= (1f + incrementoPorToque);
        }
    }

    void OnTriggerEnter2D(Collider2D area)
    {
        if (area.CompareTag("Gol"))
        {
            transform.position = Vector3.zero;
            Sacar();
        }
    }
}

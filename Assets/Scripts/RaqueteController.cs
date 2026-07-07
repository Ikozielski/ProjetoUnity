using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    public float velocidadeY = 10f;

    Vector3 posicao;
    float limiteY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float alturaCamera = Camera.main.orthographicSize;
        float metadeRaquete = GetComponent<SpriteRenderer>().bounds.extents.y;
        limiteY = alturaCamera - metadeRaquete;
    }

    // Update is called once per frame
    void Update()
    {
        posicao = transform.position;
        posicao.y += Input.GetAxisRaw("Vertical") * velocidadeY * Time.deltaTime;
        posicao.y = Mathf.Clamp(posicao.y, -limiteY, limiteY);
        transform.position = posicao;
    }
}

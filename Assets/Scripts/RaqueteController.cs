using UnityEngine;
using UnityEngine.InputSystem;

public class RaqueteController : MonoBehaviour
{
    public float velocidadeY = 1f;

    Vector3 posicao;
    float limiteY;

    void MoverRaquete()
    {
        float direcao = 0f;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            direcao = 1f;
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            direcao = -1f;

        posicao = transform.position;
        posicao.y += direcao * velocidadeY * Time.deltaTime;
        posicao.y = Mathf.Clamp(posicao.y, -limiteY, limiteY);
        transform.position = posicao;
    }

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
        MoverRaquete();
    }
}

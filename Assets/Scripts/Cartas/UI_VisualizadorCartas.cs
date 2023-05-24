using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_VisualizadorCartas : MonoBehaviour
{
    [Header("Animación")]
    public Animator camara;
    public CanvasGroup canvasGroup;

    [Header("Configuración UI")]
    public Text ui_nombre;
    public Text ui_descripcion;

    [Header("Skins Mesh Renderer")]
    public MeshRenderer meshRenderer_Carta;

    [HideInInspector] public bool _visualizando;
    [HideInInspector] public int _index;

    public ES_Logro_Contenedor[] cartas;

    private void Start()
    {        
        Cerrar(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cerrar(true);
        }
    }

    public void Visualizar_Carta(int index)
    {
        if (!_visualizando && gameObject.activeSelf)
        {            
            _index = index;
            StartCoroutine(Visualizar(cartas[index]));
        }
    }

    public void Cerrar(bool reproducirSonidoCerrar)
    {
        StopAllCoroutines();

        _visualizando = false;

        camara.gameObject.SetActive(false);
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;

        if (reproducirSonidoCerrar)
        {
            // SD_SonidosMenu.sonidosMenu.ReproducirSonido(SD_SonidosMenu.sonidosMenu.seleccionar_2, 0.6f);
        }
    }


    private IEnumerator Visualizar(ES_Logro_Contenedor logroContenedor)
    {
        _visualizando = true;

        ui_nombre.text = logroContenedor.nombre;

        meshRenderer_Carta.gameObject.SetActive(true);
        meshRenderer_Carta.materials[1].mainTexture = logroContenedor.textura;

        camara.gameObject.SetActive(true);
        camara.Rebind();
        camara.Play("Animacion");
        canvasGroup.blocksRaycasts = true;

        float tiempoTransicion = 1f;
        float tiempo = 0;

        while (tiempo < 1f)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, tiempo);
            tiempo += Time.deltaTime / tiempoTransicion;
            yield return null;
        }
        _visualizando = false;
    }
}

[System.Serializable]
public class ES_Logro_Contenedor
{
    public string nombre;
    [TextArea(1, 2)] public string descripcion_logro;
    [TextArea(1, 2)] public string descripcion_extra;
    public Texture textura;
}

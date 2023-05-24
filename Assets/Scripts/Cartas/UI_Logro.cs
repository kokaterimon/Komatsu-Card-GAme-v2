using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Logro : MonoBehaviour, IPointerClickHandler
{
    //[Header("Referencias")]
    private UI_VisualizadorCartas visualizadorCartas;

    public int cartaIndex;

    // Variables sentinela
    private Image imagen;
    private Color colorActivado = Color.white;
    private Color colorDesactivado = new Color(0.3f, 0.3f, 0.3f, 1f);

    //private bool _desbloqueada;

    private void Awake()
    {
        ObtenerReferencias();

        //Bloqueada();

        //visualizadorSkins.Configurar(UI_VisualizadorSkins.Configuracion.Con_Interaccion);
        //visualizadorLogros.visualizador_Logros_Aplicar_Cambios += Comprobar_Desbloqueo;
    }

    private void ObtenerReferencias()
    {
        //visualizadorLogros = FindObjectOfType<UI_VisualizadorLogros>();
        visualizadorCartas = FindObjectOfType<UI_VisualizadorCartas>();
        imagen = GetComponent<Image>();
    }

    //private void Comprobar_Desbloqueo()
    //{
    //    /*if (ES_EstadoJuego.estadoJuego.DatosControlador.Consultar_Logro_Desbloqueado(logroIndex))
    //    {
    //        Desbloqueada();
    //    }
    //    else
    //    {
    //        Bloqueada();
    //    }*/
    //}

    private void Boton_VisualizarCarta()
    {
        //visualizadorCartas.Configurar(logroIndex, UI_VisualizadorLogros.Configuracion.Solo_Ver);
        visualizadorCartas.Visualizar_Carta(cartaIndex);
    }

    //public void Boton_VisualizarPoder()
    //{
    //    visualizadorLogros.Configurar(logroIndex, UI_VisualizadorLogros.Configuracion.Poder);
    //    visualizadorLogros.Visualizar_Logro(logroIndex);
    //}

    //private void Boton_VisualizarHuevoDeOro()
    //{
    //    visualizadorLogros.Configurar(logroIndex, UI_VisualizadorLogros.Configuracion.HuevoDeOro);
    //    visualizadorLogros.Visualizar_Logro(logroIndex);
    //}

    //private void Desbloqueada()
    //{
    //    imagen.color = colorActivado;
    //    _desbloqueada = true;
    //}

    //private void Bloqueada()
    //{
    //    //imagen.color = colorDesactivado;
    //    _desbloqueada = false;
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        Boton_VisualizarCarta();
    }
}

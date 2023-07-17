using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlujoPantallas : MonoBehaviour
{
    #region Variables
    public TransitionSettings transition;
    public float delaytransition;

    [Range(0.1f, 3f)] public float delayMenu;

    #endregion

    #region Funciones
    public void CargarScena(string sceneName)
    {
        TransitionManager.Instance().Transition(sceneName, transition, delaytransition);
    }

    public void FadedTransition(GameObject objActivar)
    {
        TransitionManager.Instance().Transition(transition, delaytransition);

        StartCoroutine(SeguirFaded(objActivar));
    }
    public void OcultarMenu(GameObject objDesactivar)
    {
        StartCoroutine(VolverFaded(objDesactivar));
    }

    public void SalirJuego()
    {
        TransitionManager.Instance().Transition(transition, delaytransition);
        StartCoroutine(EsperarSalir());
    }


    #endregion

    #region Corrutinas
    IEnumerator SeguirFaded(GameObject activador)
    {
        yield return new WaitForSeconds(delayMenu);
        activador.SetActive(true);
    }

    IEnumerator VolverFaded(GameObject desactivador)
    {
        yield return new WaitForSeconds(delayMenu);
        desactivador.SetActive(false);
    }
    IEnumerator EsperarSalir()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
        Debug.Log("Saliendo.....");
        
    }

    #endregion

}

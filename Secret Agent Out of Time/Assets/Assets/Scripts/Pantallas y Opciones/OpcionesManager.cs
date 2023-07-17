using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpcionesManager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject canvasOpciones;
    [Space(3)]
    [SerializeField] Image brilloPanel;
    [SerializeField] Toggle casillaPcompleta;
    [SerializeField] TMP_Dropdown calidadImagenDD;
    [SerializeField] TMP_Dropdown resolucionesDD;
    [Space(3)]
    Resolution[] arrayResoluciones;

    [Header("Sliders")]
    [SerializeField] Slider sliderVolumen;  
    [SerializeField] Slider sliderBrillo;

    [Header("Valores Sliders")]
    [SerializeField] float valorSliderVol;
    [SerializeField] float valorSliderBri;

    [Header("Valores Variables")]
    [SerializeField] int calidadImagen;


    private void Awake()
    {
        var dontDestroy = FindObjectsOfType<OpcionesManager>();
        if (dontDestroy.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        sliderVolumen.value = PlayerPrefs.GetFloat("AudioVolumen", 0.5f);
        AudioListener.volume = sliderVolumen.value;

        sliderBrillo.value = PlayerPrefs.GetFloat("BrilloValor", 0.35f);
        brilloPanel.color = new Color(brilloPanel.color.r, brilloPanel.color.g, brilloPanel.color.b, valorSliderBri);

        calidadImagen = PlayerPrefs.GetInt("CalidadImagen", 3);
        calidadImagenDD.value = calidadImagen;
        OnCambiarCalidadImagen();

        if (Screen.fullScreen)
        {
            casillaPcompleta.isOn = true;
        }
        else
        {
            casillaPcompleta.isOn = false;
        }

        OnRevisarResolucion();
    }

    public void OnChangeSliderBri(float valorBrillo)
    {
        valorSliderBri = valorBrillo;
        PlayerPrefs.SetFloat("BrilloValor", valorSliderBri);
        brilloPanel.color = new Color(brilloPanel.color.r, brilloPanel.color.g, brilloPanel.color.b, valorSliderBri);
    }

    public void OnChangeSliderVol(float valorVolumen)
    {
        valorSliderVol = valorVolumen;
        PlayerPrefs.SetFloat("AudioVolumen", valorSliderVol);
        AudioListener.volume = sliderVolumen.value;
    }

    public void OnPantallaCompleta(bool isPcompleta)
    {
        Screen.fullScreen = isPcompleta;
    }
    public void OnCambiarCalidadImagen()
    {
        QualitySettings.SetQualityLevel(calidadImagenDD.value);
        PlayerPrefs.SetInt("CalidadImagen", calidadImagenDD.value);
        calidadImagen = calidadImagenDD.value;
    }

    public void OnRevisarResolucion()
    {
        arrayResoluciones = Screen.resolutions;
        resolucionesDD.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionAtual = 0;

        for (int i = 0; i < arrayResoluciones.Length; i++)
        {
            string opcion = arrayResoluciones[i].width + " x " + arrayResoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && arrayResoluciones[i].width == Screen.currentResolution.width &&
                arrayResoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionAtual = i;
            }
        }
        resolucionesDD.AddOptions(opciones);
        resolucionesDD.value = resolucionAtual;
        resolucionesDD.RefreshShownValue();

        resolucionesDD.value = PlayerPrefs.GetInt("ResolucionIndex", 3);
    }

    public void OnCambiarResolucion(int resolucionIndex) 
    {
        PlayerPrefs.SetInt("ResolucionIndex", resolucionesDD.value);

        Resolution resolution = arrayResoluciones[resolucionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}



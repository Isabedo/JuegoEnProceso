using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texto_canvas;
    [SerializeField] private TMP_InputField texto_input;
    [SerializeField] private Button boton_canvas;
    [SerializeField] private Canvas canvas;
    
    
    void Start()
    {
        canvas.enabled = true;
        Textos("Hola, cual es tu nombre?");
        boton_canvas.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnButtonClick()
    {
        Validacion(texto_input.text);
    }
    private void Textos(string contenido)
    {
        texto_canvas.text = contenido;
    }
    private void Validacion(string respuesta)
    {
        if (string.IsNullOrWhiteSpace(respuesta))
        {
            
            Textos("Porfavor igresa un nombre valido");
            
            return;
        }else if (respuesta != null)
        {
            
            texto_canvas.text = "Hola "+ respuesta + " Bienvenido al juego";
            
            
            StartCoroutine(DesactivarCanvasConRetraso(2f));
        }
    }
    private IEnumerator DesactivarCanvasConRetraso(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        canvas.enabled = false;
    }



}

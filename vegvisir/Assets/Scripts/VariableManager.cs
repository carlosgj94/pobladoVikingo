using UnityEngine;
using System.Collections;

public class VariableManager : MonoBehaviour {
    [SerializeField]
    private EstadisticasManager estadisticas;
	public int sangre;
	public int hambre;
	public int fiesta;
	public int poblacion;
	public int dias;
    void OnLevelWasLoaded()
    {
        
        if(PlayerPrefs.GetInt("Dias")>0){
            //Debug.Log(PlayerPrefs.GetInt("Dias"));
            sangre = PlayerPrefs.GetInt("Sangre");
            hambre = PlayerPrefs.GetInt("Hambre");
            fiesta = PlayerPrefs.GetInt("Fiesta");
            poblacion = PlayerPrefs.GetInt("Poblacion");
            dias = PlayerPrefs.GetInt("Dias");

            estadisticas.refresh();
        }
        else
        {
			Debug.Log ("Reinicio aldea");
            sangre = 0;
            hambre = 0;
            fiesta = 0;
            poblacion = 1000;
            dias = 0;
			PlayerPrefs.SetInt ("Poblacion", 1000);
			PlayerPrefs.SetInt ("Hambre", 0);
			PlayerPrefs.SetInt ("Sangre", 0);
			PlayerPrefs.SetInt ("Fiesta", 0);
			PlayerPrefs.SetInt ("Dias", 0);
        }
    }
	public void aumentarSangre(int cantidad){
		sangre += cantidad;
        estadisticas.refresh();
        PlayerPrefs.SetInt("Sangre", sangre);
    }
	public void disminuirSangre(int cantidad){
        if (sangre >= cantidad)
        {
            sangre -= cantidad;
        }
        else
        {
            sangre = 0;
        }
        estadisticas.refresh();
        PlayerPrefs.SetInt("Sangre", sangre);
    }


	public void aumentarHambre(int cantidad){
		hambre += cantidad;
        estadisticas.refresh();
        PlayerPrefs.SetInt("Hambre", hambre);
    }
	public void disminuirHambre(int cantidad){
        if (hambre >= cantidad)
        {
            hambre -= cantidad;
        }
        else
        {
            hambre = 0;
            
        }
        estadisticas.refresh();
        PlayerPrefs.SetInt("Hambre", hambre);
    }


	public void aumentarFiesta(int cantidad){
		fiesta += cantidad;
        estadisticas.refresh();
        PlayerPrefs.SetInt("Fiesta", fiesta);
    }
	public void disminuirFiesta(int cantidad){
        if (fiesta >= cantidad)
        {
            fiesta -= cantidad;
        }
        else
        {
            fiesta = 0;
        }
        PlayerPrefs.SetInt("Fiesta", fiesta);
    }


	public void aumentarPoblacion(int cantidad){
		poblacion += cantidad;
        estadisticas.refresh();
        PlayerPrefs.SetInt("Poblacion", poblacion);
    }
	public void disminuirPoblacion(int cantidad){
        if (poblacion >= cantidad)
        {
            poblacion -= cantidad;
        }
        else
        {
            poblacion = 0;
        }
        PlayerPrefs.SetInt("Poblacion", poblacion);
    }

	public void variablesNuevoDia(){
		
		int random = Random.Range (0,3);

		if (random == 0){
            aumentarSangre(1);
		}else if(random == 1){
            aumentarHambre(1);
		}else if(random == 2) {
            aumentarFiesta(1);
		}

		int variacionPoblacion = (int)Mathf.Round((poblacion * Random.Range(-5,5))/100);
        aumentarPoblacion(variacionPoblacion);

        estadisticas.refresh();
        dias++;
        PlayerPrefs.SetInt("Dias", dias);
        

	}

}

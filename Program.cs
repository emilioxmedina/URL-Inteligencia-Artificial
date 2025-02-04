using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// Ejemplo de perceptron para implementar la puerta logica de XOR

namespace Perceptron {

	class Program {

		static void Main(string[] args) {
			// Conjunto de datos
			double[,] datos = { 
				{ 0, 0, 0, 0, 0, 0 },
				{ 0, 1, 0, 0, 1, 1 },
				{ 1, 0, 0, 1, 0, 1 },
				{ 1, 1, 1, 1, 1, 0 }
			};
			// Generacion de los valores de peso y umbral
			Random aleatorio = new Random();
			double[] pesos = {aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble(), aleatorio.NextDouble()};
			// Etapas de aprendizaje
			bool aprendizaje =	true;

            int salidaInt;
            int epocas = 0;

            while (aprendizaje) {
                aprendizaje = false;

                for (int i = 0; i < 4; i++) {
                    double salidaDoub = datos[i, 0] * pesos[0] + datos[i, 1] * pesos[1] + datos[i, 2] * pesos[2] + datos[i, 3] * pesos[3] + datos[i, 4] * pesos[4] + pesos[5];
                    
                    if (salidaDoub > 0) salidaInt = 1; else salidaInt = 0;

                    if (salidaInt != datos[i, 5]) {
                        pesos[0] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        pesos[1] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        pesos[2] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        pesos[3] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        pesos[4] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        pesos[5] = aleatorio.NextDouble() - aleatorio.NextDouble();
                        aprendizaje = true;
                    }
                }
                epocas++;
            }
            

            for (int i = 0; i < 4; i++) {
                double salidaDoub = datos[i, 0] * pesos[0] + datos[i, 1] * pesos[1] + datos[i, 2] * pesos[2] + datos[i, 3] * pesos[3] + datos[i, 4] * pesos[4] + pesos[5];

                if (salidaDoub > 0) salidaInt = 1; else salidaInt = 0;

                Console.WriteLine("Entradas: " + datos[i, 0].ToString() + " XOR " + datos[i, 1].ToString() + " = " + datos[i, 5].ToString()  + " Perceptron: " + salidaInt.ToString());
            }

            Console.WriteLine("Epocas: " + epocas.ToString());
            Console.WriteLine("Pesos utiles: p0= " + pesos[0].ToString() + "p1= " + pesos[1].ToString() + "p2= " + pesos[2].ToString() + "p3= " + pesos[3].ToString() + "p4= " + pesos[4].ToString() + " Umbral: " + pesos[5].ToString());
		}
	}
}
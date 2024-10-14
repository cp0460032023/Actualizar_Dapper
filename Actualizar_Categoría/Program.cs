using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actualizar_Categoría
{
    // Clase estática que contiene el punto de entrada principal de la aplicación.
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// Este método se ejecuta al iniciar la aplicación.
        /// </summary>
        [STAThread] // Indica que la aplicación utiliza un modelo de subprocesos de un solo hilo.
        static void Main()
        {
            // Habilita el estilo visual para la aplicación.
            Application.EnableVisualStyles();
            // Establece el formato de texto compatible con versiones anteriores.
            Application.SetCompatibleTextRenderingDefault(false);
            // Inicia la aplicación y muestra el formulario principal.
            Application.Run(new Form1());
        }
    }
}

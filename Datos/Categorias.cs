using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    // Clase que representa la entidad 'Categoría' en la base de datos.
    public class Categorias
    {
        // Propiedad que almacena el identificador único de la categoría.
        public int CategoryID { get; set; }

        // Propiedad que almacena el nombre de la categoría.
        public string CategoryName { get; set; }

        // Propiedad que almacena una descripción de la categoría.
        public string Description { get; set; }

        // Propiedad que almacena una imagen de la categoría en forma de arreglo de bytes.
        public byte[] Picture { get; set; }
    }
}

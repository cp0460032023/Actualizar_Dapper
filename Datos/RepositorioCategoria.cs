using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    // Clase que actúa como repositorio para gestionar las categorías en la base de datos.
    public class RepositorioCategoria
    {
        // Método que obtiene todas las categorías de la base de datos.
        public List<Categorias> ObtenerTodo()
        {
            // Establece una conexión a la base de datos utilizando el método de la clase BaseDeDatos.
            using (var conexion = BaseDeDatos.GetSqlConnection())
            {
                // Consulta SQL para seleccionar todas las columnas de la tabla 'Categories'.
                String SelectAll = "";
                SelectAll = SelectAll + "SELECT [CategoryID] " + "\n";
                SelectAll = SelectAll + "      ,[CategoryName] " + "\n";
                SelectAll = SelectAll + "      ,[Description] " + "\n";
                SelectAll = SelectAll + "      ,[Picture] " + "\n";
                SelectAll = SelectAll + "  FROM [dbo].[Categories]";

                // Ejecuta la consulta y convierte el resultado en una lista de objetos 'Categorias'.
                var Categoriass = conexion.Query<Categorias>(SelectAll).ToList();
                return Categoriass; // Retorna la lista de categorías.
            }
        }

        // Método que obtiene una categoría específica por su ID.
        public Categorias ObtenerPoeID(int id)
        {
            using (var conexion = BaseDeDatos.GetSqlConnection())
            {
                // Consulta SQL para seleccionar una categoría específica por su 'CategoryID'.
                String SelectID = "";
                SelectID = SelectID + "SELECT [CategoryID] " + "\n";
                SelectID = SelectID + "      ,[CategoryName] " + "\n";
                SelectID = SelectID + "      ,[Description] " + "\n";
                SelectID = SelectID + "      ,[Picture] " + "\n";
                SelectID = SelectID + "  FROM [dbo].[Categories] " + "\n";
                SelectID = SelectID + "  WHERE CategoryID = @CategoryID";

                // Ejecuta la consulta y obtiene la primera categoría que coincida con el ID proporcionado.
                var Categoriass = conexion.QueryFirstOrDefault<Categorias>(SelectID, new { CategoryID = id });
                return Categoriass; // Retorna la categoría encontrada o null si no existe.
            }
        }

        // Método que actualiza una categoría existente en la base de datos.
        public int ActualizarCategoria(Categorias categoria)
        {
            using (var conexion = BaseDeDatos.GetSqlConnection())
            {
                // Consulta SQL para actualizar los campos de la categoría.
                string UpdateaCate = "";
                UpdateaCate += "UPDATE [dbo].[Categories] ";
                UpdateaCate += "SET CategoryName = @CategoryName, ";
                UpdateaCate += "Description = @Description, ";
                UpdateaCate += "Picture = @Picture ";
                UpdateaCate += "WHERE CategoryID = @CategoryID;";

                // Ejecuta la consulta de actualización y obtiene el número de filas afectadas.
                var filasActualizadas = conexion.Execute(UpdateaCate, new
                {
                    CategoryID = categoria.CategoryID,
                    CategoryName = categoria.CategoryName,
                    Description = categoria.Description,
                    Picture = categoria.Picture
                });

                return filasActualizadas; // Retorna el número de filas que fueron actualizadas.
            }
        }
    }
}


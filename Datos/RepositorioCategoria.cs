using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioCategoria
    {
        public List<Categorias> ObtenerTodo()
        {
            using (var conexion = BaseDeDatos.GetSqlConnection())
            {
                String SelectAll = "";
                SelectAll = SelectAll + "SELECT [CategoryID] " + "\n";
                SelectAll = SelectAll + "      ,[CategoryName] " + "\n";
                SelectAll = SelectAll + "      ,[Description] " + "\n";
                SelectAll = SelectAll + "      ,[Picture] " + "\n";
                SelectAll = SelectAll + "  FROM [dbo].[Categories]";

                var Categoriass = conexion.Query<Categorias>(SelectAll).ToList();
                return Categoriass;
            }
        }

        public Categorias ObtenerPoeID(int id)
        {
            using (var conexion = BaseDeDatos.GetSqlConnection())
            {

                String SelectID = "";
                SelectID = SelectID + "SELECT [CategoryID] " + "\n";
                SelectID = SelectID + "      ,[CategoryName] " + "\n";
                SelectID = SelectID + "      ,[Description] " + "\n";
                SelectID = SelectID + "      ,[Picture] " + "\n";
                SelectID = SelectID + "  FROM [dbo].[Categories] " + "\n";
                SelectID = SelectID + "  WHERE CategoryID = @CategoryID";

                var Categoriass = conexion.QueryFirstOrDefault<Categorias>(SelectID, new { CategoryID = id });
                return Categoriass;
            }
        }

        public int ActualizarCategoria(Categorias categoria)
        {
            using (var conexion = BaseDeDatos.GetSqlConnection())
            {
                string UpdateaCate = "";
                UpdateaCate += "UPDATE [dbo].[Categories] ";
                UpdateaCate += "SET CategoryName = @CategoryName, ";
                UpdateaCate += "Description = @Description, ";
                UpdateaCate += "Picture = @Picture ";
                UpdateaCate += "WHERE CategoryID = @CategoryID;";

                var filasActualizadas = conexion.Execute(UpdateaCate, new
                {
                    CategoryID = categoria.CategoryID,
                    CategoryName = categoria.CategoryName,
                    Description = categoria.Description,
                    Picture = categoria.Picture
                });

                return filasActualizadas;
            }
        }
    }
}

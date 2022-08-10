using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dal_acceso;


namespace LogicaNegocios
{
    public class LN
    {
        public ClassAccSQL acceso;
        private string conexion;

        public LN(string cdn) //Constructor
        {
            conexion = cdn;
            acceso = new ClassAccSQL(cdn);
        }

        public string Open() //Metodo abrir conexion
        {
            string msj = "";
            acceso.AbrirConexion(ref msj);
            return msj;
        }


        //Metodo Ver Usuario 
        public DataTable Usuario(ref string msj)
        {
            string query = "SELECT * FROM usuarios;";
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaP = new List<SqlParameter>();
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaP);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }

        //Metodo Insertar 

        public Boolean InsertarUsuarios(int id, string nom, string col, int num, int cpo, string nct, string tel)
        {
            Boolean salida = false;
            string msj = "";
            string query = "INSERT INTO usuarios (id_usuario, nombre, colonia, numero, cp, nom_centroTrabajo, telefono)" +
                           "VALUES (@id, @nom, @col, @num, @cpo, @nct, @tel);";
            List<SqlParameter> listaP = new List<SqlParameter>();

            listaP.Add(new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Value = id,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "nom",
                SqlDbType = SqlDbType.VarChar,
                Value = nom,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "col",
                SqlDbType = SqlDbType.VarChar,
                Value = col,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "num",
                SqlDbType = SqlDbType.Int,
                Value = num,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "cpo",
                SqlDbType = SqlDbType.Int,
                Value = cpo,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "nct",
                SqlDbType = SqlDbType.VarChar,
                Value = nct,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "tel",
                SqlDbType = SqlDbType.VarChar,
                Value = tel,
            });

       
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }

        //Metodo Modificar 

        public void ModificarUsuario(string id, string nom, string col, int num, int cpo, string nct, string tel)
        {
            string query = "UPDATE usuarios SET nombre= @nom, colonia=@col, numero=@num, cp=@cpo, nom_centroTrabajo=@nct, telefono=@tel where id_usuario = @id";
            string msj = "";
            List<SqlParameter> listaP = new List<SqlParameter>();

            listaP.Add(new SqlParameter()
            {
                ParameterName = "nom",
                SqlDbType = SqlDbType.VarChar,
                Value = nom,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "col",
                SqlDbType = SqlDbType.VarChar,
                Value = col,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "num",
                SqlDbType = SqlDbType.Int,
                Value = num,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "cpo",
                SqlDbType = SqlDbType.Int,
                Value = cpo,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "nct",
                SqlDbType = SqlDbType.VarChar,
                Value = nct,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "tel",
                SqlDbType = SqlDbType.VarChar,
                Value = tel,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Value = id,
            });
            acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
        }

        //Metodo Eliminar 

        public Boolean BorrarUsuario(string id)
        {
            string query = "DELETE FROM usuarios where id_usuario = " + id;
            string msj = "";
            Boolean salida = false;
            List<SqlParameter> listaP = new List<SqlParameter>();
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }


        //Metodo Ver Publicacion 
        public DataTable Publicacion(ref string msj)
        {
            string query = "SELECT * FROM publicaciones;";
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaP = new List<SqlParameter>();
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaP);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }
    }
}

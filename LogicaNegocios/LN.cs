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


        //Metodo Ver Material 
        public DataTable VerMaterial(ref string msj)
        {
            string query = "SELECT M.Descripcion_Mat, M.Marca, M.Presentacion, T.Tipo From Material M, TipoMaterial T WHERE M.ID_Tipo=T.ID_Tipo";
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

        public DataTable VerObra(ref string msj)
        {
            string query = " SELECT M.Nom_Obra, M.Direccion, M.Fecha_Inicio, M.Fecha_Termino From Obra M";
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

        public DataTable VerProvee(ref string msj)
        {
            string query = " SELECT M.Recibio, M.Entrega, M.Cantidad, M.Fecha_Entre, M.Precio From Provee_De_Materi_Obra M";
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

        //Metodo Insertar TABLA MATERIAL

        public Boolean InsertarMaterial(int id, string descri, string marc, string presen, int idTip)
        {
            Boolean salida = false;
            string msj = "";
            string query = "INSERT INTO usuarios (ID_Material, Descripcion_Mat, Presentacion, ID_Tipo )" +
                           "VALUES (@id, @descri, @marc, @presen, @idTip);";
            List<SqlParameter> listaP = new List<SqlParameter>();

            listaP.Add(new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Value = id,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "descri",
                SqlDbType = SqlDbType.VarChar,
                Value = descri,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "marc",
                SqlDbType = SqlDbType.VarChar,
                Value = marc,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "presen",
                SqlDbType = SqlDbType.VarChar,
                Value = presen,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "idTipo",
                SqlDbType = SqlDbType.Int,
                Value = idTip,
            });

       
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }

        //Metodo Modificar Proveedor

        public void ModificarUsuario( string recibi, string entre, int cant, string feEn, int pre, int idO, int idM)
        {
            string query = "UPDATE Provee_De_Materi_Obra SET Recibio= @recibi, Entrega=@entre, Cantidad=@cant, Fecha_Entre=@feEn, Precio=@pre, ID_Obra=@idO, ID_Material=@idM where Recibio = @recibi";
            string msj = "";
            List<SqlParameter> listaP = new List<SqlParameter>();

            listaP.Add(new SqlParameter()
            {
                ParameterName = "recibi",
                SqlDbType = SqlDbType.VarChar,
                Value = recibi,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "entre",
                SqlDbType = SqlDbType.VarChar,
                Value = entre,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "cant",
                SqlDbType = SqlDbType.Int,
                Value = cant,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "feEn",
                SqlDbType = SqlDbType.VarChar,
                Value = feEn,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "pre",
                SqlDbType = SqlDbType.VarChar,
                Value = pre,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "idO",
                SqlDbType = SqlDbType.Int,
                Value = idO,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "idM",
                SqlDbType = SqlDbType.Int,
                Value = idM,
            });
            acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
        }

        //Metodo Eliminar Obra

        public Boolean BorrarObra(string id)
        {
            string query = "DELETE FROM Obra where Nom_Obra = " + id;
            string msj = "";
            Boolean salida = false;
            List<SqlParameter> listaP = new List<SqlParameter>();
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }

        public DataTable VerDueno(ref string msj)
        {
            string query = " Select Nombre_Dueno FROM Dueno";
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

        public DataTable VerDuenoObra(ref string msj)
        {
            string query = "SELECT D.Nombre_Dueno, O.Nom_Obra, O.Fecha_Inicio, O.Fecha_Termino From Obra O, Dueno D WHERE D.ID_Dueno=O.ID_Dueno";
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

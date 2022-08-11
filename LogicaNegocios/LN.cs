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
        public DataTable VerTipoMaterial(ref string msj)
        {
            string query = "select * from TipoMaterial";
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
        public DataTable VerDueno()
        {
            string query = "select * from Dueno";
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaP = new List<SqlParameter>();
            string mensaje = "";
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref mensaje), ref mensaje, listaP);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }
        public DataTable VerEncargado()
        {
            string query = "select * from EncargadoObra";
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaP = new List<SqlParameter>();
            string mensaje = "";
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref mensaje), ref mensaje, listaP);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }

        public DataTable VerObra()
        {
            string query = " SELECT M.ID_Obra, M.Nom_Obra, M.Direccion, M.Fecha_Inicio, M.Fecha_Termino From Obra M";
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaP = new List<SqlParameter>();
            string msj = "";
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
        public DataTable VerProvedor()
        {
            string query = "select * from Proveedor";
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaP = new List<SqlParameter>();
            string msj = "";
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaP);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }

        //Metodo Insertar TABLA MATERIAL

        public Boolean InsertarMaterial(string descri, string marc, string presen, int idTip)
        {
            Boolean salida = false;
            string msj = "";
            string query = "INSERT INTO Material VALUES(@desc,@marca,@pres,@tipo)";
            List<SqlParameter> listaP = new List<SqlParameter>();
            listaP.Add(new SqlParameter("@desc", descri));
            listaP.Add(new SqlParameter("@marca", marc));
            listaP.Add(new SqlParameter("@pres", presen));
            listaP.Add(new SqlParameter("@tipo", idTip));
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }
        public Boolean InsertartObra(string nom, string dicc, string inico, string fin, int idnueno, int idencargado)
        {
            Boolean salida = false;
            string msj = "";
            string query = "INSERT INTO Obra VALUES(@nom,@dire,@ini,@fin,@idnueno,@idencargado)";
            List<SqlParameter> listaP = new List<SqlParameter>();
            listaP.Add(new SqlParameter("@nom", nom));
            listaP.Add(new SqlParameter("@dire", dicc));
            listaP.Add(new SqlParameter("@ini", inico));
            listaP.Add(new SqlParameter("@fin", fin));
            listaP.Add(new SqlParameter("@idnueno", idnueno));
            listaP.Add(new SqlParameter("@idencargado", idencargado));
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }
        public Boolean InsertaProvedor(string recibido, string entrega, int cantidad, string fecha, double precio, int idobra, int idmaterial, int idprovedor)
        {
            Boolean salida = false;
            string msj = "";
            string query = "INSERT INTO Provee_De_Materi_Obra VALUES(@recibido,@entrega,@cantidad,@fecha,@precio,@idobra,@idmaterial,@idprovedor)";
            List<SqlParameter> listaP = new List<SqlParameter>();
            listaP.Add(new SqlParameter("@recibido", recibido));
            listaP.Add(new SqlParameter("@entrega", entrega));
            listaP.Add(new SqlParameter("@cantidad", cantidad));
            listaP.Add(new SqlParameter("@fecha", fecha));
            listaP.Add(new SqlParameter("@precio", precio));
            listaP.Add(new SqlParameter("@idobra", idobra));
            listaP.Add(new SqlParameter("@idmaterial", idmaterial));
            listaP.Add(new SqlParameter("@idprovedor", idprovedor));
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }


        //Metodo Modificar Proveedor

        public void ModificarUsuario(string recibi, string entre, int cant, string feEn, int pre, int idO, int idM)
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

        public Boolean BorrarObra(int id)
        {
            string msj = "";
            Boolean salida = false;
            List<SqlParameter> listaP = new List<SqlParameter>();
            listaP.Add(new SqlParameter("@id", id));
            string query = "DELETE FROM Obra WHERE ID_Obra = @id";
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

        public DataTable VerDuenoObra(int id)
        {
            string query = "SELECT D.Nombre_Dueno, O.Nom_Obra, O.Fecha_Inicio, O.Fecha_Termino From Obra O inner join Dueno D on D.ID_Dueno = O.ID_Dueno where O.ID_Dueno = @id";
            DataTable salida = null;
            DataSet ds = null;
            string msj = "";
            List<SqlParameter> listaP = new List<SqlParameter>();
            listaP.Add(new SqlParameter("@id", id));
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaP);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }


        public DataTable VerMateria2()
        {
            string query = " Select * FROM Material";
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaP = new List<SqlParameter>();
            string msj = "";
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaP);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocios;
using System.Configuration;
using LogicaNegocios.Entidades;

namespace PresentacionWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        LN bl = null;
        string idDetalle = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) //Si es la primera ves que carga la aplicación
            {
                string cdn = ConfigurationManager.ConnectionStrings["conlocal"].ConnectionString;
                bl = new LN(cdn);
                Session["bl"] = bl;
            }
            else //Si viene de un postBack
            {

                bl = (LN)Session["bl"];
            }

            //Mostrar Grid
            mostrarUsuarios();
            mostrarPublicacion();

        }

        public void mostrarUsuarios()
        {
            string msj = "";
            GridView1.DataSource = bl.Usuario(ref msj);
            GridView1.DataBind();
        }

        public void mostrarPublicacion()
        {
            string msj = "";
            GridView2.DataSource =bl.Publicacion(ref msj);
            GridView2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         
            Usuario temp2 = new Usuario();
            Boolean recibe = false;
            string msj = "";
            int i=0, nu = 0, cp = 0;
            string n = "", c = "", ct = "", t = "";
            
            int fpp = 0, fm = 0;

            i = Convert.ToInt16(TextBox1.Text);
            n = TextBox2.Text;
            c = TextBox3.Text;
            nu = Convert.ToInt16(TextBox4.Text);
            cp = Convert.ToInt16(TextBox5.Text);
            ct = TextBox6.Text;
            t = TextBox7.Text;
            
            //fp = Convert.ToInt16(ViewState["ID_Profe"]);
            
            recibe = bl.InsertarUsuarios(i, n, c, nu, cp, ct, t);
             
            if (recibe == true)
            {
                //ViewState["id_usuario"] = 0;
                
                TextBoxStatus.Text = "Nuevo registro agregado exitosamente";
            }
            else
            {
                TextBoxStatus.Text = "Error!, no se agrego el registro";
            }
        }

       
        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                Session["id_usuario"] = GridView1.SelectedRow.Cells[1].Text; //Se guarda el id del profe en una variable de sesion
  
        }

        protected void ButtonBorrarUsu_Click(object sender, EventArgs e)
        {
            idDetalle = GridView1.SelectedRow.Cells[1].Text;
            string resp = "";
            Boolean recibe = false;
            Boolean recibe2 = false;
            recibe = bl.BorrarUsuario(idDetalle);
            

            if (recibe)
            {
                TextBoxStatus.Text = "Se elimino exitosamente";
                //Response.Redirect("WebFormProfes.aspx"); //Redireccionamos
            }
            else
            {
                TextBoxStatus.Text = "ERROR! No se pudo eliminar";
            }
            //Visibles();
        }
    }
}
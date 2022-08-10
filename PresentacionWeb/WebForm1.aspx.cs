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
            Material();
            mostrarObra();
            mostrarProvee();
            mostrarDueno();

        }

        public void Material()
        {
            string msj = "";
            GridView1.DataSource = bl.VerMaterial(ref msj);
            GridView1.DataBind();
        }

        public void mostrarObra()
        {
            string msj = "";
            GridView2.DataSource =bl.VerObra(ref msj);
            GridView2.DataBind();
        }

        public void mostrarProvee()
        {
            string msj = "";
            GridView3.DataSource = bl.VerProvee(ref msj);
            GridView3.DataBind();
        }

        public void mostrarDueno()
        {
            string msj = "";
            GridView4.DataSource = bl.VerDueno(ref msj);
            GridView4.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         
            Usuario temp2 = new Usuario();
            Boolean recibe = false;
            string msj = "";
            int id = 0, idt = 0, fp=0 ;
            string d = "", m = "",  p = "";
            
            int ft = 0;

            //id = Convert.ToInt16(TextBox1.Text);
            d = TextBox2.Text;
            m = TextBox3.Text;
            p = TextBox4.Text;
            idt = Convert.ToInt16(TextBox5.Text);
            
            
            //ft = Convert.ToInt16(ViewState["ID_Profe"]);
            
            recibe = bl.InsertarMaterial(id, d, m, p, idt);
             
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
            
                /*Session["Nom_Obra"] = GridView1.SelectedRow.Cells[1].Text;*/ //Se guarda el id del profe en una variable de sesion
  
        }

        protected void ButtonBorrarUsu_Click(object sender, EventArgs e)
        {
            idDetalle = GridView1.SelectedRow.Cells[1].Text;
            string resp = "";
            Boolean recibe = false;
            Boolean recibe2 = false;
           // recibe = bl.BorrarUsuario(idDetalle);
            

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

        protected void ButtonBoPu_Click(object sender, EventArgs e)
        {
            idDetalle = GridView2.SelectedRow.Cells[1].Text;
            string resp = "";
            Boolean recibe = false;
            
            recibe = bl.BorrarObra(idDetalle);


            if (recibe == true)
            {
                TextBoxStatus.Text = "Se elimino exitosamente";
                //Response.Redirect("WebFormProfes.aspx"); //Redireccionamos
            }
            else
            {
                TextBoxStatus2.Text = "ERROR! No se pudo eliminar";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Nom_Obra"] = GridView2.SelectedRow.Cells[1].Text;
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Nombre_Dueno"] = GridView4.SelectedRow.Cells[1].Text;
        }

        protected void ButtonMObras_Click(object sender, EventArgs e)
        {
            //Mostrar Obras
            mostrarDuenoObra();


        }

        public void mostrarDuenoObra()
        {
            string msj = "";
            GridView5.DataSource = bl.VerDuenoObra(ref msj);
            GridView5.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocios;
using System.Configuration;
using LogicaNegocios.Entidades;
using System.Data;

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

            if (!IsPostBack)
            {
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("Selecciona una opción");
                string mensaje = "";
                DataTable tipoM = bl.VerTipoMaterial(ref mensaje);

                foreach (DataRow row in tipoM.Rows)
                {
                    DropDownList1.Items.Add(new ListItem()
                    {
                        Value = row[0].ToString(),
                        Text = row[1].ToString() + " - " + row[2].ToString()
                    });
                }


                DropDownList2.Items.Clear();
                DropDownList2.Items.Add("Selecciona una opción");
                DataTable dueno = bl.VerDueno();

                foreach (DataRow row in dueno.Rows)
                {
                    DropDownList2.Items.Add(new ListItem()
                    {
                        Value = row[0].ToString(),
                        Text = row[1].ToString() + " - " + row[2].ToString() + " - " + row[3].ToString()
                    });
                }


                DropDownList3.Items.Clear();
                DropDownList3.Items.Add("Selecciona una opción");
                DataTable encargado = bl.VerEncargado();

                foreach (DataRow row in encargado.Rows)
                {
                    DropDownList3.Items.Add(new ListItem()
                    {
                        Value = row[0].ToString(),
                        Text = row[1].ToString() + " - " + row[2].ToString() + " - " + row[3].ToString()
                    });
                }

                DropDownList4.Items.Clear();
                DropDownList4.Items.Add("Selecciona una opción");
                DataTable obraDel = bl.VerObra();

                foreach (DataRow row in obraDel.Rows)
                {
                    DropDownList4.Items.Add(new ListItem()
                    {
                        Value = row[0].ToString(),
                        Text = row[1].ToString() + " - " + row[2].ToString() + " - " + row[3].ToString() + " - " + row[4].ToString()
                    });
                }


                DropDownList5.AutoPostBack = true;
                DropDownList5.Items.Clear();
                DropDownList5.Items.Add("Selecciona una opción");
                DataTable dueno2 = bl.VerDueno();

                foreach (DataRow row in dueno2.Rows)
                {
                    DropDownList5.Items.Add(new ListItem()
                    {
                        Value = row[0].ToString(),
                        Text = row[1].ToString() + " - " + row[2].ToString() + " - " + row[3].ToString() + " - " + row[4].ToString()
                    });
                }

                DropDownList6.Items.Clear();
                DropDownList6.Items.Add("Selecciona una opción");
                DataTable obra2 = bl.VerObra();

                foreach (DataRow row in obra2.Rows)
                {
                    DropDownList6.Items.Add(new ListItem()
                    {
                        Value = row[0].ToString(),
                        Text = row[1].ToString() + " - " + row[2].ToString() + " - "
                    });
                }

                DropDownList7.Items.Clear();
                DropDownList7.Items.Add("Selecciona una opción");
                DataTable material = bl.VerMateria2();

                foreach (DataRow row in material.Rows)
                {
                    DropDownList7.Items.Add(new ListItem()
                    {
                        Value = row[0].ToString(),
                        Text = row[1].ToString() + " - " + row[2].ToString() + " - " + row[3].ToString()
                    });
                }

                DropDownList8.Items.Clear();
                DropDownList8.Items.Add("Selecciona una opción");
                DataTable proovedor = bl.VerProvedor();

                foreach (DataRow row in proovedor.Rows)
                {
                    DropDownList8.Items.Add(new ListItem()
                    {
                        Value = row[0].ToString(),
                        Text = row[1].ToString() + " - " + row[2].ToString() + " - " + row[3].ToString() + " - " + row[4].ToString()
                    });
                }
            }

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
            GridView2.DataSource = bl.VerObra(ref msj);
            GridView2.DataBind();
        }

        public void mostrarProvee()
        {
            string msj = "";
            GridView3.DataSource = bl.VerProvee(ref msj);
            GridView3.DataBind();
        }



        protected void Button1_Click(object sender, EventArgs e)
        {

            Boolean recibe = false;
            int idt = 0;
            string d = "", m = "", p = "";
            try
            {
                if (DropDownList1.SelectedIndex == 0)
                {
                    TextBoxStatus.Text = "Selecciona una opción";
                }
                else
                {
                    d = TextBox2.Text;
                    m = TextBox3.Text;
                    p = TextBox4.Text;
                    idt = Convert.ToInt16(DropDownList1.SelectedValue);
                    recibe = bl.InsertarMaterial(d, m, p, idt);

                    if (recibe == true)
                    {
                        TextBoxStatus.Text = "Nuevo registro agregado exitosamente";
                        Response.Redirect("WebForm1.aspx");
                    }
                    else
                    {
                        TextBoxStatus.Text = "Error!, no se agrego el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                TextBoxStatus.Text = "Error!," + ex.Message;
            }
        }


        protected void Button1_Click4(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList6.SelectedIndex != 0 || DropDownList7.SelectedIndex != 0 || DropDownList8.SelectedIndex != 0)
                {
                    bool respuesta = bl.InsertaProvedor(TextBoxRecibio.Text, TextBoxEntrega.Text, Int32.Parse(TextBoxCantidad.Text), TextBoxFechaEn.Text, Int32.Parse(TextBoxPrecio.Text), Int32.Parse(DropDownList6.SelectedValue), Int32.Parse(DropDownList7.SelectedValue), Int32.Parse(DropDownList8.SelectedValue));
                    if (respuesta)
                        Response.Redirect("WebForm1.aspx");
                    else
                        TextBoxStatus3.Text = "No lo hizo, falta elementos";
                }
                else
                {
                    TextBoxStatus3.Text = "Selecciona una opción";
                }
            }
            catch (Exception ex)
            {
                TextBoxStatus3.Text = "Error!," + ex.Message;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*Session["Nom_Obra"] = GridView1.SelectedRow.Cells[1].Text;*/ //Se guarda el id del profe en una variable de sesion
            Response.Write(GridView1.SelectedRow.Cells[1].Text);

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
            string resp = "";
            Boolean recibe = false;
            if (DropDownList4.SelectedIndex != 0)
            {
                recibe = bl.BorrarObra(Int32.Parse(DropDownList4.SelectedValue));
                if (recibe == true)
                {
                    TextBoxStatus.Text = "Se elimino exitosamente";
                    Response.Redirect("WebForm1.aspx"); //Redireccionamos
                }
                else
                    TextBoxStatus2.Text = "ERROR! No se pudo eliminar, interfieren otras tablas";
            }
            else
                TextBoxStatus2.Text = "Selecciona una opción";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Nom_Obra"] = GridView2.SelectedRow.Cells[1].Text;
        }


        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList5.SelectedIndex != 0)
            {
                GridView6.DataSource = bl.VerDuenoObra(Int32.Parse(DropDownList5.SelectedValue));
                GridView6.DataBind();
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Boolean recibe = false;
            try
            {
                if (DropDownList2.SelectedIndex == 0 || DropDownList3.SelectedIndex == 0)
                {
                    TextBoxStatus2.Text = "Selecciona una opción";
                }
                else
                {
                    recibe = bl.InsertartObra(TextBox8.Text, TextBox9.Text, TextBox10.Text, TextBox11.Text, Int32.Parse(DropDownList2.SelectedValue), Int32.Parse(DropDownList3.SelectedValue));

                    if (recibe == true)
                    {
                        TextBoxStatus2.Text = "Nuevo registro agregado exitosamente";
                        Response.Redirect("WebForm1.aspx");
                    }
                    else
                    {
                        TextBoxStatus2.Text = "Error!, no se agrego el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                TextBoxStatus2.Text = "Error!," + ex.Message;
            }
        }
    }
}
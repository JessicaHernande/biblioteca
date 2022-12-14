<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PresentacionWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
</head>
<body>
    <nav class="navbar navbar-expand-lg bg-light">
        <div class="container-fluid">
            <a class="navbar-brand disabled" href="#">AccesoDatos</a>

            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="WebForm1.aspx">Usuarios</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="WebForm2.aspx">Publicaciones</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <%--Fin del navbar--%>
    <form id="form1" runat="server" class="container mt-4">
        <div class="row">
            <div class="col-8 ">
                <h1>Material</h1>

                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br />

            </div>
            <%--fin div col-8 --%>
            <div class="col-4">


                <br />
                <%--ID:
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />--%>
                Descripccion Material:
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                Marca:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <br />
                Presentacion:
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <br />
                ID Tipo:
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <br />
                &nbsp;<br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonInsertarUsu" runat="server" OnClick="Button1_Click" Text="Insertar" />
                &nbsp;
                &nbsp;
                <br />
                <br />
                <asp:TextBox ID="TextBoxStatus" runat="server" Width="286px"></asp:TextBox>


            </div>
            <%--fin div col-4--%>

            <div class="col-8 ">
                <h1>Obra</h1>
                <p>
                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </p>
            </div>
            <%--fin div col-8 --%>

            <div class="col-4">

                <br />
                nombre obra:
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                <br />
                Dirección:
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                <br />
                Fecha inicio:
                <asp:TextBox ID="TextBox10" type="date" runat="server"></asp:TextBox>
                <br />
                Fecha Fin:
                <asp:TextBox ID="TextBox11" type="date" runat="server"></asp:TextBox>
                <br />
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>

                <br />
                <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>

                &nbsp;&nbsp;
                <asp:Button ID="ButtonInsPu" runat="server" OnClick="Button1_Click1" Text="Insertar" />
                &nbsp;
                &nbsp;
                <asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList>
                <asp:Button ID="ButtonBoPu" runat="server" Text="Borrar" OnClick="ButtonBoPu_Click" />
                <br />
                <br />
                <asp:TextBox ID="TextBoxStatus2" runat="server" Width="294px"></asp:TextBox>
                <br />
                <br />

            </div>
            <%--fin div col-4 --%>

            <div class="col-8 ">
                <h1>Proveedor</h1>
                <p>
                    <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </p>
            </div>
            <%--fin div col-8 --%>

            <div class="col-4">

                <br />
                Recibio:
                <asp:TextBox ID="TextBoxRecibio" runat="server"></asp:TextBox>
                <br />
                Entrega:
                <asp:TextBox ID="TextBoxEntrega" runat="server"></asp:TextBox>
                <br />
                Cantidad:
                <asp:TextBox ID="TextBoxCantidad" type="number" runat="server"></asp:TextBox>
                <br />
                Fecha de entrega:
                <asp:TextBox ID="TextBoxFechaEn" type="date" runat="server"></asp:TextBox>
                <br />
                Precio:
                <asp:TextBox ID="TextBoxPrecio" type="number" runat="server"></asp:TextBox>
                <br />

                obra:<asp:DropDownList ID="DropDownList6" runat="server"></asp:DropDownList>
                <br />
                material:<asp:DropDownList ID="DropDownList7" runat="server"></asp:DropDownList>
                <br />
                prooverdor:<asp:DropDownList ID="DropDownList8" runat="server"></asp:DropDownList>
                <br />
                &nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click4" Text="Insertar" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" Text="Actualizar" OnClick="Button2_Click" />
                &nbsp;
                <br />
                <br />
                <asp:TextBox ID="TextBoxStatus3" runat="server" Width="294px"></asp:TextBox>
                <br />
                <br />

            </div>


            <div class="col-8 ">
                <h1>Consultas</h1>
                <p>

                    <asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged"></asp:DropDownList>

                    <asp:GridView ID="GridView6" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </p>
            </div>
            <%--fin div col-8 --%>
        </div>
        <%--Fin row--%>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
</body>
</html>

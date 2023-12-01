<%@ Page Title="" Language="C#" MasterPageFile="~/master/cliente.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Cliente.carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            // Obtener el elemento TextBox de fecha
            var fechaInput = document.getElementById('<%= txtFechaC.ClientID %>');

            // Obtener la fecha actual en formato yyyy-MM-dd en la zona horaria UTC
            var fechaActualUTC = new Date().toISOString().split('T')[0];

            // Ajustar la fecha actual al huso horario de Lima (UTC-5)
            var fechaActualLima = new Date(fechaActualUTC);
            fechaActualLima.setHours(fechaActualLima.getHours() - 5);

            // Formatear la fecha actual en formato yyyy-MM-dd
            var fechaActualPeru = fechaActualLima.toISOString().split('T')[0];

            // Establecer el valor mínimo para bloquear fechas anteriores
            fechaInput.setAttribute('min', fechaActualPeru);
        });
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container pt-3 pb-3">
        <h4>Carrito de Servicios</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="row">
                    <asp:Repeater ID="Repeater1"  runat="server">
                        <ItemTemplate>

                            <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4 mb-3">
                                <div class="container bg-white redondear">
                                    <div class="row">
                                        <div class="col-4 p-2">
                                            <asp:Image ID="Image1" ImageUrl='<%#"../"+Eval("Imagen")%>' CssClass="w-100" runat="server" />
                                        </div>
                                        <div class="col-8 p-2 align-items-center text-dark">
                                            <label class="w-100"><%#Eval("Nombre") %></label>
                                            <div class="row mt-2">
                                                <div class="col-8">
                                                    <span>
                                                        <i class='bx bxs-like'></i>
                                                        <label for="" class="fs-8">100</label>
                                                    </span>
                                                    <span>
                                                        <i class="bi bi-share-fill"></i>
                                                        <label for="" class="fs-8">100</label>
                                                    </span>
                                                </div>
                                                <div class="col-4 text-end">
                                                    <asp:Button ID="Button1" CommandName="Quitar" OnCommand="QuitarCarrito" CommandArgument='<%#Eval("Ids")+"|"+Eval("Idc") %>' CssClass="btn btn-dark text-light" runat="server" Text="-" />
                                                </div>
                                            </div>
                                            <label for="" class="text-precio fw-bold">S/ <%#Eval("Precio") %></label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Label ID="lblNoti" runat="server" CssClass="form-label"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-md-6 col-lg-3 col-xl-3 mt-3">
                        <label class="form-label">Fecha de la cita</label>
                        <asp:TextBox ID="txtFechaC" TextMode="Date" CssClass="form-control w-100" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 col-md-6 col-lg-3 col-xl-3 mt-3">
                        <label class="form-label">Hora de la cita</label>
                        <asp:TextBox ID="txtHoraC" TextMode="Time" CssClass="form-control w-100" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 col-md-6 col-lg-4 col-xl-4 mt-3">
                        <div class="row">
                        <div class="col-9">
                            <label class="form-label">Selecciona vehiculo</label>
                        <asp:DropDownList ID="ddlCarro" CssClass="form-select w-100" runat="server">
                            <asp:ListItem Value="gg">Seleccionar...</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <button type="button" class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#exampleModal"><i class="bi bi-plus-circle"></i></button>
                        </div>
                            </div>
                    </div>
                    <div class="col-sm-6 col-md-6 col-lg-2 col-xl-2 mt-3">
                        <label class="form-label">Enviar</label>
                        <asp:Button ID="btnRegistrar" CommandName="Registrar" OnCommand="RegistrarCita" CssClass="btn btn-secondary w-100" runat="server" Text="Registrar" />
                    </div>
                </div>

                <!-- modal -->
                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Agregar Vehiculo</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <div class="row mb-3">
            <div class="col-6">
                <label class="focus-label">Numero de Placa</label>
                <asp:TextBox ID="txtPlacaN" MaxLength="7" placeholder="placa" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <label class="focus-label">Marca</label>
                <asp:TextBox ID="txtMarcaN" placeholder="Marca" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
          <div class="row mb-3">
            <div class="col-6">
                <label class="focus-label">Color</label>
                <asp:TextBox ID="txtColorN" placeholder="color" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <label class="focus-label">Año</label>
                <asp:TextBox ID="txtYear" placeholder="año" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
          <div class="mb-3">
                <label class="focus-label">Modelo</label>
                <asp:TextBox ID="txtModeloN" placeholder="modelo" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
      </div>
      <div class="modal-footer">
          <asp:Button ID="Button2" CssClass="btn btn-secondary" CommandName="aggVehiculo" OnCommand="AgregarVehiculo" data-bs-dismiss="modal" runat="server" Text="Agregar Vehiculo" />
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>


            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    
</asp:Content>

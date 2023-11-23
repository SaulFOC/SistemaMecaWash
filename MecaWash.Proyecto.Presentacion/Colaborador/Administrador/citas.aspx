<%@ Page Title="" Language="C#" MasterPageFile="~/master/colaborador.Master" AutoEventWireup="true" CodeBehind="citas.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Colaborador.Administrador.citas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        .sombra {
            box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.12);
        }

        .menu-linea {
            color: var(--text-color);
            background: transparent;
            border: none;
            width: 100%;
            border-bottom: 4px solid var(--text-color);
        }

            .menu-linea:hover,
            .menu-linea:active,
            .menu-linea:focus {
                color: var(--text-color);
                background: transparent;
                transform: var(--tran-03);
                border-bottom: 4px solid var(--caja-text);
            }

        .linea {
            color: var(--caja-text);
            border-bottom: 4px solid var(--caja-text);
        }

        .btn-secundario {
            background: var(--color-precio);
            color: var(--color-white);
        }

            .btn-secundario:hover,
            .btn-secundario:active,
            .btn-secundario:focus {
                background: var(--text-color);
                color: var(--color-white);
                scale: 1.07;
                transform: var(--tran-03);
            }

        .st {
            position: sticky;
            top: 0;
            z-index: 100;
            background: var(--body-color);
        }

        #ordenesActivas {
            display: none;
        }

        @media screen and (max-width: 468px) {

            .st {
                top: 63px;
            }
        }
    </style>

    <div class="container">
        <div class="row px-3 st">
            <div class="col-6 p-0">
                <div class="container p-0 w-100 mt-3 mb-3 text-center">
                    <button id="btnNueva" class="menu-linea linea fs-5">
                        Nueva Cita
                    </button>
                </div>
            </div>
            <div class="col-6 p-0">
                <div class="container p-0 w-100 mt-3 mb-3 text-center">
                    <button id="btnActivas" class="menu-linea fs-5">
                        Citas Aceptadas
                    </button>
                </div>
            </div>
        </div>
        <div class="row" id="nuevaOrden">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4 mb-3">
                                <div class="container bg-white redondear p-3">
                                    <div class="pb-2">
                                        <label><i class="bi bi-person-bounding-box"></i> <%#Eval("Nombre") %></label><br />
                                    </div>
                                    <div class="row pb-2">
                                        <div class="col-6">
                                            <label><i class="bi bi-calendar-date"></i> <%#Eval("Fecha") %></label>
                                        </div>
                                        <div class="col-6">
                                            <label><i class="bi bi-watch"></i> <%#Eval("Hora") %></label>
                                        </div>
                                    </div>
                                    <div class="pb-2">
                                        <label><i class="bi bi-car-front-fill"></i> <%#Eval("Vehiculo") %></label>
                                    </div>
                                    
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                        </div>

                    <asp:Label ID="lblNoti" runat="server" CssClass="form-label"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row" id="ordenesActivas">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="Repeater2" runat="server">
                    </asp:Repeater>
                    <asp:Label ID="lblNoti2" runat="server" CssClass="form-label"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script>
        document.getElementById('btnNueva').addEventListener('click', function () {
            document.getElementById('nuevaOrden').style.display = 'flex';
            document.getElementById('ordenesActivas').style.display = 'none';
            document.getElementById('btnNueva').classList.add('linea');
            document.getElementById('btnActivas').classList.remove('linea');
        });
        document.getElementById('btnActivas').addEventListener('click', function () {
            document.getElementById('nuevaOrden').style.display = 'none';
            document.getElementById('ordenesActivas').style.display = 'flex';
            document.getElementById('btnNueva').classList.remove('linea');
            document.getElementById('btnActivas').classList.add('linea');
        });
    </script>
</asp:Content>

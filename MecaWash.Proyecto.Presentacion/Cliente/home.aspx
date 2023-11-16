<%@ Page Title="" Language="C#" MasterPageFile="~/master/cliente.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Cliente.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script async src="https://unpkg.com/es-module-shims@1.6.3/dist/es-module-shims.js"></script>
    <script type="importmap">
      {
        "imports": {
          "three": "https://unpkg.com/three@v0.153.0/build/three.module.js",
          "three/addons/": "https://unpkg.com/three@v0.153.0/examples/jsm/"
        }
      }
    </script>
    <style>
        canvas {
            width: 100% !important;
            height: 100% !important;
        }

        .posicion {
            position: absolute;
            top: 3rem;
            left: 3rem;
            width:35%;
            cursor: move;
            background-color:transparent;
            border-radius: 15px;
            border: 2px solid #0094ff;
        }

        @media screen and (max-width: 720px) {
            .posicion {
                position: absolute;
                top: 5rem;
                left: 2%;
                width:96%;
            }
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container posicion">
                    <h4 class="pt-3">Inicio</h4>
                    <select id="opciones" class="form-select">
                        <option value="../assets/modelos/auto/scene.gltf">Carro</option>
                        <option value="../assets/modelos/bus/scene.gltf">Bus</option>
                        <option value="../assets/modelos/moto/scene.gltf">Moto</option>
                    </select>
                    <div class="container mt-3">
                        <table id="accesoriosTable" class="table">
                            <thead>
                                <tr>
                                    <th>Servicio</th>
                                    <th>Precio</th>
                                </tr>
                            </thead>
                            <tbody id="accesoriosBody"></tbody>
                        </table>
                    </div>
                </div>
                <script type="module" src="../assets/js/carros.js"></script>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

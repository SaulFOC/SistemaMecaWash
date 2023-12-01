<%@ Page Title="" Language="C#" MasterPageFile="~/master/cliente.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="MecaWash.Proyecto.Presentacion.Cliente.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        body {
            color: #ccc;
        }

        canvas {
            width: 100% !important;
            height: 100% !important;
        }

        .draggable {
            position: absolute;
            top: 3rem;
            left: 3rem;
            width: 30%;
            cursor: move;
            background: #18191a;
            border-radius: 10px;
            border: 2px solid #FFB900;
        }

        a {
            color: #08f;
        }

        .colorPicker {
            display: inline-block;
            margin: 0 10px
        }

        .o {
            cursor: pointer;
        }

        .oculta {
            display: none;
        }

        @media screen and (max-width: 720px) {
            .draggable {
                position: absolute;
                top: 5rem;
                left: 2%;
                width: 96%;
            }
        }
    </style>

    <div class="container">
        <div class="container draggable text-center pb-3">
            <h4 class="pt-3">Taller de Pintura <i id="swith" class="bi bi-caret-up-fill o"></i></h4>
            <div id="info" class="container w-100">
                <span class="colorPicker">
                    <input id="body-color" type="color" value="#ff0000"><br />
                    Cuerpo</span>
                <span class="colorPicker">
                    <input id="details-color" type="color" value="#ffffff"><br />
                    Aros</span>
                <span class="colorPicker">
                    <input id="glass-color" type="color" value="#ffffff"><br />
                    Vidrios</span>
            </div>
            <div id="contenedorCitas" class="mt-3 pe-3 ps-3 text-start">
                <div id="contB" class="oculta bg-white redondear pt-2 pb-2">
                    <div class="row">
                        <div class="col-3 pt-1 pb-1 pe-3 ps-3">
                            <div id="colorP" style="width: 100%; border: 1px solid #ccc; height: 100%; background: #ff0000; border-radius: 6px;"></div>
                        </div>
                        <div class="col-6">
                            <label class="fw-bold ">Color Principal</label><br />
                            <span id="colorPText">#ff0000</span>
                        </div>
                        <div class="col-3">
                            <button onclick="ocultar('contB','txtColorB')" type="button" class="btn btn-danger"><i class="bi bi-trash-fill"></i></button>
                        </div>
                    </div>
                </div>
                <div id="contA" class="oculta bg-white redondear mt-2 pt-2 pb-2">
                    <div class="row">
                        <div class="col-3 pt-1 pb-1 pe-3 ps-3">
                            <div id="colorA" style="width: 100%; border: 1px solid #ccc; height: 100%; background: #ffffff; border-radius: 6px;"></div>
                        </div>
                        <div class="col-6">
                            <label class="fw-bold ">Color Aros</label><br />
                            <span id="colorAText">#ffffff</span>
                        </div>
                        <div class="col-3">
                            <button onclick="ocultar('contA','txtColorA')" type="button" class="btn btn-danger"><i class="bi bi-trash-fill"></i></button>
                        </div>
                    </div>
                </div>
                <div id="contV" class="oculta bg-white redondear mt-2 pt-2 pb-2">
                    <div class="row">
                        <div class="col-3 pt-1 pb-1 pe-3 ps-3">
                            <div id="colorV" style="width: 100%; border: 1px solid #ccc; height: 100%; background: #ffffff; border-radius: 6px;"></div>
                        </div>
                        <div class="col-6">
                            <label class="fw-bold ">Color Vidrios</label><br />
                            <span id="colorVText">#ffffff</span>
                        </div>
                        <div class="col-3">
                            <button onclick="ocultar('contV','txtColorV')" type="button" class="btn btn-danger"><i class="bi bi-trash-fill"></i></button>
                        </div>
                    </div>
                </div>
                <div class="mt-3 text-center">
                    <button type="button" id="mandar" data-bs-toggle="modal" data-bs-target="#exampleModal" class="btn btn-secondary">Solicitar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Agendar Pintado</h5>
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">X</button>
                        </div>
                        <div class="modal-body">
                            <div class="row mb-2">
                                <div class="col-6">
                                    <label class="form-label">Fecha</label>
                                    <asp:TextBox ID="fInicio" TextMode="Date" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                    <label class="form-label">Hora</label>
                                    <asp:TextBox ID="hor" TextMode="Time" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-6">
                                    <label class="form-label">Selecciona Vehiculo</label>
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-select" runat="server" ClientIDMode="Static"></asp:DropDownList>
                                </div>
                                <div class="col-6">
                                    <a class="btn btn-secondary" target="myFrame" href="perfil.aspx"><i class="bi bi-plus-circle"></i></a>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-6">
                                    <label class="form-label">Pintado Carroceria</label>
                                    <asp:TextBox ID="txtColorB" ReadOnly="true" CssClass="oculta form-control" ClientIDMode="Static" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                    <label class="form-label">Pintado de Aros</label>
                                    <asp:TextBox ID="txtColorA" ReadOnly="true" CssClass="oculta form-control" ClientIDMode="Static" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-2">
                                <label class="form-label">Pintado de lunas</label>
                                <asp:TextBox ID="txtColorV" ReadOnly="true" CssClass="oculta form-control" ClientIDMode="Static" runat="server"></asp:TextBox>
                            </div>



                        </div>
                        <div class="modal-footer">
                            <div>
                                <asp:Button ID="Button1" data-bs-dismiss="modal" OnCommand="RegistrarCita" CommandName="aggColor" CssClass="btn btn-secondary" runat="server" Text="Aggregar Cita" />
                            </div>
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="container"></div>

    <script type="importmap">
			{
				"imports": {
					"three": "https://unpkg.com/three@v0.153.0/build/three.module.js",
          			"three/addons/": "https://unpkg.com/three@v0.153.0/examples/jsm/"
				}
			}
    </script>
    <script type="module">

        import * as THREE from 'three';

        import Stats from 'three/addons/libs/stats.module.js';

        import { OrbitControls } from 'three/addons/controls/OrbitControls.js';

        import { GLTFLoader } from 'three/addons/loaders/GLTFLoader.js';
        import { DRACOLoader } from 'three/addons/loaders/DRACOLoader.js';
        import { RGBELoader } from 'three/addons/loaders/RGBELoader.js';

        let camera, scene, renderer;
        let stats;

        let grid;
        let controls;

        const wheels = [];

        function init() {

            const container = document.getElementById('container');

            renderer = new THREE.WebGLRenderer({ antialias: true });
            renderer.setPixelRatio(window.devicePixelRatio);
            renderer.setSize(window.innerWidth, window.innerHeight);
            renderer.setAnimationLoop(render);
            renderer.toneMapping = THREE.ACESFilmicToneMapping;
            renderer.toneMappingExposure = 0.85;
            container.appendChild(renderer.domElement);

            window.addEventListener('resize', onWindowResize);

            stats = new Stats();

            //

            camera = new THREE.PerspectiveCamera(40, window.innerWidth / window.innerHeight, 0.1, 100);
            camera.position.set(4.25, 1.4, - 4.5);

            controls = new OrbitControls(camera, container);
            controls.maxDistance = 9;
            controls.maxPolarAngle = THREE.MathUtils.degToRad(90);
            controls.target.set(0, 0.5, 0);
            controls.update();

            scene = new THREE.Scene();
            scene.background = new THREE.Color(0x333333);
            scene.environment = new RGBELoader().load('../assets/textures/equirectangular/venice_sunset_1k.hdr');
            scene.environment.mapping = THREE.EquirectangularReflectionMapping;
            scene.fog = new THREE.Fog(0x333333, 10, 15);

            grid = new THREE.GridHelper(20, 40, 0xffffff, 0xffffff);
            grid.material.opacity = 0.2;
            grid.material.depthWrite = false;
            grid.material.transparent = true;
            scene.add(grid);

            // materials

            const bodyMaterial = new THREE.MeshPhysicalMaterial({
                color: 0xff0000, metalness: 1.0, roughness: 0.5, clearcoat: 1.0, clearcoatRoughness: 0.03
            });

            const detailsMaterial = new THREE.MeshStandardMaterial({
                color: 0xffffff, metalness: 1.0, roughness: 0.5
            });

            const glassMaterial = new THREE.MeshPhysicalMaterial({
                color: 0xffffff, metalness: 0.25, roughness: 0, transmission: 1.0
            });

            const bodyColorInput = document.getElementById('body-color');
            bodyColorInput.addEventListener('input', function () {

                bodyMaterial.color.set(this.value);

            });

            const detailsColorInput = document.getElementById('details-color');
            detailsColorInput.addEventListener('input', function () {

                detailsMaterial.color.set(this.value);

            });

            const glassColorInput = document.getElementById('glass-color');
            glassColorInput.addEventListener('input', function () {

                glassMaterial.color.set(this.value);

            });

            // Car

            const shadow = new THREE.TextureLoader().load('../assets/models/gltf/ferrari_ao.png');

            const dracoLoader = new DRACOLoader();
            dracoLoader.setDecoderPath('../assets/jsm/libs/draco/gltf/');

            const loader = new GLTFLoader();
            loader.setDRACOLoader(dracoLoader);

            loader.load('../assets/models/gltf/ferrari.glb', function (gltf) {

                const carModel = gltf.scene.children[0];

                carModel.getObjectByName('body').material = bodyMaterial;

                carModel.getObjectByName('rim_fl').material = detailsMaterial;
                carModel.getObjectByName('rim_fr').material = detailsMaterial;
                carModel.getObjectByName('rim_rr').material = detailsMaterial;
                carModel.getObjectByName('rim_rl').material = detailsMaterial;
                carModel.getObjectByName('trim').material = detailsMaterial;

                carModel.getObjectByName('glass').material = glassMaterial;

                wheels.push(
                    carModel.getObjectByName('wheel_fl'),
                    carModel.getObjectByName('wheel_fr'),
                    carModel.getObjectByName('wheel_rl'),
                    carModel.getObjectByName('wheel_rr')
                );

                // shadow
                const mesh = new THREE.Mesh(
                    new THREE.PlaneGeometry(0.655 * 4, 1.3 * 4),
                    new THREE.MeshBasicMaterial({
                        map: shadow, blending: THREE.MultiplyBlending, toneMapped: false, transparent: true
                    })
                );
                mesh.rotation.x = - Math.PI / 2;
                mesh.renderOrder = 2;
                carModel.add(mesh);

                scene.add(carModel);

            });

        }

        function onWindowResize() {

            camera.aspect = window.innerWidth / window.innerHeight;
            camera.updateProjectionMatrix();

            renderer.setSize(window.innerWidth, window.innerHeight);

        }

        function render() {

            controls.update();

            const time = - performance.now() / 1000;

            for (let i = 0; i < wheels.length; i++) {

                wheels[i].rotation.x = time * Math.PI * 2;

            }

            grid.position.z = - (time) % 1;

            renderer.render(scene, camera);

            stats.update();

        }

        init();

        //recuperar el color que se elige en el color picker cuando se cambia el color
        function getColor() {
            var color = document.getElementById("body-color").value;
            console.log("body: " + color);
            document.getElementById("colorPText").innerHTML = color;
            document.getElementById("txtColorB").value = color;
            document.getElementById("contB").classList.remove("oculta");
            document.getElementById("txtColorB").classList.remove("oculta");
            document.getElementById("colorP").style.background = color;
        }
        //para detalles y glass
        function getColorD() {
            var color = document.getElementById("details-color").value;
            console.log("llantas: " + color);
            document.getElementById("colorAText").innerHTML = color;
            document.getElementById("txtColorA").value = color;
            document.getElementById("contA").classList.remove("oculta");
            document.getElementById("txtColorA").classList.remove("oculta");
            document.getElementById("colorA").style.background = color;
        }
        function getColorG() {
            var color = document.getElementById("glass-color").value;
            console.log("ventanas: " + color);
            document.getElementById("colorVText").innerHTML = color;
            document.getElementById("txtColorV").value = color;
            document.getElementById("contV").classList.remove("oculta");
            document.getElementById("txtColorV").classList.remove("oculta");
            document.getElementById("colorV").style.background = color;
        }

        //ejecutar la funcion getColor() cuando se cambia el color
        document.getElementById("body-color").addEventListener("change", getColor);
        document.getElementById("details-color").addEventListener("change", getColorD);
        document.getElementById("glass-color").addEventListener("change", getColorG);

    </script>
    <script src="https://cdn.jsdelivr.net/npm/interactjs/dist/interact.min.js"></script>
    <script>
        //para hacer dorp drag
        const position = { x: 0, y: 0 }

        interact('.draggable').draggable({
            listeners: {
                start(event) {
                    console.log(event.type, event.target)
                },
                move(event) {
                    position.x += event.dx
                    position.y += event.dy

                    event.target.style.transform =
                        `translate(${position.x}px, ${position.y}px)`
                },
            }
        });

        //para ocultar y mostrar
        var swith = document.getElementById('swith');
        var citas = document.getElementById('contenedorCitas');

        //agregar la clase oculta si se hace click a swith y quitarla si se vuelve a hacer click
        swith.addEventListener('click', function () {
            citas.classList.toggle('oculta');
            //cambiar de icono
            if (swith.classList.contains('bi-caret-up-fill')) {
                swith.classList.remove('bi-caret-up-fill');
                swith.classList.add('bi-caret-down-fill');
            } else {
                swith.classList.remove('bi-caret-down-fill');
                swith.classList.add('bi-caret-up-fill');
            }

        });

        //funcion para ocultar
        function ocultar(valor, valor2) {
            let color = document.getElementById(valor);
            let colorM = document.getElementById(valor2);
            color.classList.add('oculta');
            colorM.classList.add('oculta');
            colorM.value = "";
        }
    </script>
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            // Obtener el elemento TextBox de fecha
            var fechaInput = document.getElementById('<%= fInicio.ClientID %>');

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
</asp:Content>

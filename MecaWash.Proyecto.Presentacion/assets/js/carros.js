import * as THREE from 'three';
import { GLTFLoader } from 'three/addons/loaders/GLTFLoader.js';
import { OrbitControls } from 'three/addons/controls/OrbitControls.js';

function cargarVehiculo(modelo) {
    //switsh para cambiar tamaño de acuerdo al modelo
    let tam;
    switch (modelo) {
        case "../assets/modelos/auto/scene.gltf":
            tam = 60;
            break;
        case "../assets/modelos/moto/scene.gltf":
            tam = 36;
            break;
        case "../assets/modelos/bus/scene.gltf":
            tam = 33;
            break;

        default:
            tam = 75;
            break;
    }

    //crear escena
    const scene = new THREE.Scene();

    //crear camara
    const camera = new THREE.PerspectiveCamera(tam, window.innerWidth / window.innerHeight, 0.1, 1000);
    //cambiar angulo de camara
    camera.position.x = 5;
    camera.position.y = 0;
    camera.position.z = 5;

    //crear render
    const renderer = new THREE.WebGLRenderer({ alpha: true });
    renderer.setClearColor(0x000000, 0); // the default
    renderer.setSize(window.innerWidth, window.innerHeight);
    document.body.appendChild(renderer.domElement);

    //crear controles
    const controls = new OrbitControls(camera, renderer.domElement);
    controls.enableDamping = true;
    controls.campingFactor = 0.25;
    controls.enableZoom = true;

    //crear luz direccional
    const directionalLight = new THREE.DirectionalLight(0xffffff, 1);
    directionalLight.position.set(1, 1, 1);
    scene.add(directionalLight);

    //crear luz puntual
    const pointLight = new THREE.PointLight(0xffffff, 1);
    pointLight.position.set(1, 1, 1);
    scene.add(pointLight);

    //crear luz spot
    const spotLight = new THREE.SpotLight(0xffffff, 3, 100, 0.22, 1);
    spotLight.position.set(0, 25, 0);
    spotLight.castShadow = true;
    spotLight.shadow.bias = -0.0001;
    scene.add(spotLight);


    //crear luz hemisferica
    const hemisphereLight = new THREE.HemisphereLight(0xffffff, 1);
    hemisphereLight.position.set(1, 1, 1);
    scene.add(hemisphereLight);

    //crear luz ambiente
    const ambientLight = new THREE.AmbientLight(0xffffff, 1);
    scene.add(ambientLight);


    //cargar modelo a la escena
    const loader = new GLTFLoader();
    loader.load(modelo, function (gltf) {

        scene.add(gltf.scene);
    }, undefined, function (error) {
        console.error(error);
    });

    //crear animacion
    const animate = function () {
        requestAnimationFrame(animate);

        controls.update();
        renderer.render(scene, camera);
    };


    animate();
}

var miVariable = "../assets/modelos/auto/scene.gltf";

// Obtener el elemento select
var selectElement = document.getElementById('opciones');
cargarVehiculo(miVariable);

//borrar animacion anterior
function borrar() {
    const canvas = document.querySelector('canvas');
    const parent = canvas.parentElement;
    parent.removeChild(canvas);
}

// Agregar un evento change al select
selectElement.addEventListener("change", function () {
    // Destruir el canvas existente si existe
    borrar();
    // Cambiar la variable al valor seleccionado
    miVariable = selectElement.value;

    // Llamar a la función cargarVehiculo con la nueva variable
    cargarVehiculo(miVariable);
    filtrarAccesorios();
});

var accesoriosJSON = {
    "categorias": [
        {
            "nombre": "Moto",
            "accesorios": [
                { "servicio": "Escape Personalizado", "precio": 1000 },
                { "servicio": "Parabrisas", "precio": 200 },
                // ... Otros accesorios para motos
            ]
        },
        {
            "nombre": "Auto",
            "accesorios": [
                { "servicio": "Sistema de Navegación GPS", "precio": 500 },
                { "servicio": "Asientos de Cuero", "precio": 800 },
                // ... Otros accesorios para autos
            ]
        },
        {
            "nombre": "Bus",
            "accesorios": [
                { "servicio": "Aire Acondicionado", "precio": 10000 },
                { "servicio": "Sistemas de Entretenimiento para Pasajeros", "precio": 5000 },
                // ... Otros accesorios para buses
            ]
        }
    ]
};

function filtrarAccesorios() {
    // Obtener el valor seleccionado del select
    var categoriaSeleccionada = document.getElementById("opciones").value;
    let cate;
    switch (categoriaSeleccionada) {
        case "../assets/modelos/auto/scene.gltf":
            cate = "Auto";
            break;
        case "../assets/modelos/moto/scene.gltf":
            cate = "Moto";
            break;
        case "../assets/modelos/bus/scene.gltf":
            cate = "Bus";
            break;

        default:
            cate = "Auto";
            break;
    }
    // Filtrar los accesorios según la categoría seleccionada
    var accesoriosFiltrados = accesoriosJSON.categorias.find(function (categoria) {
        return categoria.nombre === cate;
    });
    // Mostrar los accesorios en la lista
    mostrarAccesorios(accesoriosFiltrados.accesorios);
}

function mostrarAccesorios(accesorios) {
    var tableBody = document.getElementById("accesoriosBody");
    tableBody.innerHTML = ""; // Limpiar el cuerpo de la tabla antes de mostrar los nuevos accesorios

    accesorios.forEach(function (accesorio) {
        var row = tableBody.insertRow();
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);

        cell1.textContent = accesorio.servicio;
        cell2.textContent = `$${accesorio.precio}`;
    });
}

// Mostrar los accesorios iniciales al cargar la página
filtrarAccesorios();

const posi = document.getElementsByClassName("posicion")[0]; // Agrega [0] para seleccionar el primer elemento con la clase "posicion"
let offsetx, offsety;

const move = (e) => {
    posi.style.left = `${e.clientX - offsetx}px`;
    posi.style.top = `${e.clientY - offsety}px`;
}

posi.addEventListener("mousedown", (e) => {
    offsetx = e.clientX - posi.offsetLeft;
    offsety = e.clientY - posi.offsetTop;
    document.addEventListener("mousemove", move); // Corrige "mosusemove" a "mousemove"
});

posi.addEventListener("mouseup", () => {
    document.removeEventListener("mousemove", move);
});



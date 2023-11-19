using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MecaWash.Libreria.Entidad;
using MecaWash.Libreria.Negocio;
using System.Data;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;

namespace MecaWash.Proyecto.Presentacion
{
    public partial class _default : System.Web.UI.Page
    {
        ECliente objE = new ECliente();
        NCliente objN = new NCliente();
        apis NApi = new apis();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["ClienteCookie"] != null)
            {
                Response.Redirect("/Cliente");
            }
            InitializeCulture();
        }

        protected void LoguearCliente2(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Loguear")
            {
                DataTable dt2 = new DataTable();
                string correo, clave;
                correo = txtCorreo.Text;
                clave = txtClave.Text;
                objE.CorreoElectronico = correo;
                objE.clave = clave;
                dt2 = objN.LoguearCliente(objE);

                if (dt2.Rows.Count > 0)
                {
                    if (dt2.Rows[0]["Estado"].ToString() == "1")
                    {
                        string valoresSerializados = JsonConvert.SerializeObject(new { id = dt2.Rows[0]["IDCliente"], dni = dt2.Rows[0]["DNI"], nombre = dt2.Rows[0]["Nombre"], direccion = dt2.Rows[0]["Direccion"], email = correo });
                        HttpCookie cookie = new HttpCookie("ClienteCookie");
                        cookie.Value = valoresSerializados;
                        cookie.Expires = DateTime.Now.AddDays(10); // Puedes ajustar la expiración según tus necesidades
                        Response.Cookies.Add(cookie);
                        Response.Redirect("/Cliente");
                    }else if (dt2.Rows[0]["Estado"].ToString() == "2")
                    {
                        EnviarCorreo();
                        Response.Redirect("/verificarcorreo.aspx");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Correo o clave incorrecta!');", true);
                }
            }
        }
        protected void ConsultaDNI(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "BuscarNombre")
            {
                consultarcliente();
            }
        }
        private void consultarcliente()
        {
            try
            {
                if (txtDNI.Text.Length == 8)
                {
                    dynamic respuesta = NApi.Get("https://dniruc.apisperu.com/api/v1/dni/" + txtDNI.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6Im1hcnRpbmNhY2VyZXMyNTQzQGdtYWlsLmNvbSJ9.2L9dqF_KgPP7WLepsD50TlrK3w7i2VjDd0IekWz8cVE");
                    txtNombreR.Text = respuesta.nombres.ToString() + " " + respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Error DNI desconocido!');", true);
            }
        }
        protected void RegistraCliente(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "RegistrarC")
                {
                    string dni, nom, dir, tel, correo, clave;
                    dni = txtDNI.Text;
                    nom = txtNombreR.Text;
                    dir = txtDireccionR.Text;
                    tel = txtCelularR.Text;
                    correo = txtCorreoR.Text;
                    clave = txtClaveR.Text;

                    objE.Dni = dni;
                    objE.Nombre = nom;
                    objE.Direccion = dir;
                    objE.Telefono = tel;
                    objE.CorreoElectronico = correo;
                    objE.clave = clave;
                    objE.Estado = 2;

                    bool respuesta = objN.ExisteCuenta(objE);
                    if (respuesta == true)
                    {
                        objN.RegistrarCliente(objE);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Exito", "notiExito('Registrado!','Su cuenta ah sido creada con exito!');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Error ya existe una cuenta!');", true);
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Error llenar todos los campos!');", true);
            }
        }

        protected void EnviarCorreo()
        {
            try
            {
                // Configuración del cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient("smtp.zoho.com");
                clienteSmtp.Port = 465;
                clienteSmtp.Credentials = new NetworkCredential("soporteboofast@zohomail.com", "Mireyra135#");
                clienteSmtp.EnableSsl = true;

                // Crear el mensaje de correo
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("soporteboofast@zohomail.com");
                mensaje.To.Add("destinatario@ejemplo.com");
                mensaje.Subject = "Bienvenido a MecWash";
                mensaje.Body = "Contenido del Correo";

                // Enviar el correo
                clienteSmtp.Send(mensaje);

            }
            catch
            {
                
            }
        }
    }
}
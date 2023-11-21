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
using System.Threading.Tasks;

namespace MecaWash.Proyecto.Presentacion
{
    public partial class _default : System.Web.UI.Page
    {
        ECliente objE = new ECliente();
        NCliente objN = new NCliente();
        apis NApi = new apis();
        ECarrito eC = new ECarrito();
        NCarrito nC = new NCarrito();
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

                        //llenar cookie carrito si existe carrito
                        llenarCookie(int.Parse(dt2.Rows[0]["IDCliente"].ToString()));

                        Response.Redirect("/Cliente");
                    }else if (dt2.Rows[0]["Estado"].ToString() == "2")
                    {
                        string nombre = dt2.Rows[0]["Nombre"].ToString();
                        string codigo = dt2.Rows[0]["codigo"].ToString();
                        string id= dt2.Rows[0]["IDCliente"].ToString();
                        EnviarCorreo(nombre, correo, codigo);
                        Response.Redirect("/verificarcorreo.aspx?id="+id);
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

        protected void EnviarCorreo(string nombre,string correo,string codigo)
        {
            try
            {
                string cuerpo = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html dir='ltr' xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' lang='und' style='font-family:Montserrat, sans-serif'><head><meta charset='UTF-8'><meta content='width=device-width, initial-scale=1' name='viewport'><meta name='x-apple-disable-message-reformatting'><meta http-equiv='X-UA-Compatible' content='IE=edge'><meta content='telephone=no' name='format-detection'><title>Nueva plantilla de correo electr%C3%B3nico 2023-11-19</title> <!--[if (mso 16)]><style type='text/css'>     a {text-decoration: none;}     </style><![endif]--> <!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]--> <!--[if gte mso 9]><xml> <o:OfficeDocumentSettings> <o:AllowPNG></o:AllowPNG> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml>" +
"<![endif]--> <!--[if !mso]><!-- --><link href='https://fonts.googleapis.com/css2?family=Krona+One&display=swap' rel='stylesheet'><link href='https://fonts.googleapis.com/css2?family=Montserrat&display=swap' rel='stylesheet'> <!--<![endif]--> <!--[if !mso]><!-- --><link href='https://fonts.googleapis.com/css?family=Merriweather:400,400i,700,700i' rel='stylesheet'><link href='https://fonts.googleapis.com/css?family=Merriweather+Sans:400,400i,700,700i' rel='stylesheet'> <!--<![endif]--><style type='text/css'>.rollover div { font-size:0;}.rollover:hover .rollover-first { max-height:0px!important; display:none!important;} .rollover:hover .rollover-second { max-height:none!important; display:block!important;}#outlook a { padding:0;}.es-button { mso-style-priority:100!important; text-decoration:none!important;}" +
"a[x-apple-data-detectors] { color:inherit!important; text-decoration:none!important; font-size:inherit!important; font-family:inherit!important; font-weight:inherit!important; line-height:inherit!important;}.es-desk-hidden { display:none; float:left; overflow:hidden; width:0; max-height:0; line-height:0; mso-hide:all;}@media only screen and (max-width:600px) {p, ul li, ol li, a { line-height:150%!important } h1, h2, h3, h1 a, h2 a, h3 a { line-height:120% } h1 { font-size:30px!important; text-align:center } h2 { font-size:26px!important; text-align:center } h3 { font-size:20px!important; text-align:center } .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a { font-size:30px!important } .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a { font-size:26px!important } .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a { font-size:20px!important } .es-menu td a { font-size:12px!important }" +
".es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a { font-size:12px!important } .es-content-body p, .es-content-body ul li, .es-content-body ol li, .es-content-body a { font-size:14px!important } .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a { font-size:12px!important } .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a { font-size:12px!important } *[class='gmail-fix'] { display:none!important } .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3 { text-align:center!important } .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 { text-align:right!important } .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 { text-align:left!important } .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img { display:inline!important } .es-button-border { display:inline-block!important }" +
 "a.es-button, button.es-button { font-size:20px!important; display:inline-block!important } .es-adaptive table, .es-left, .es-right { width:100%!important } .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header { width:100%!important; max-width:600px!important } .es-adapt-td { display:block!important; width:100%!important } .adapt-img { width:100%!important; height:auto!important } .es-m-p0 { padding:0!important } .es-m-p0r { padding-right:0!important } .es-m-p0l { padding-left:0!important } .es-m-p0t { padding-top:0!important } .es-m-p0b { padding-bottom:0!important } .es-m-p20b { padding-bottom:20px!important } .es-mobile-hidden, .es-hidden { display:none!important } tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden { width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important }" +
 "tr.es-desk-hidden { display:table-row!important } table.es-desk-hidden { display:table!important } td.es-desk-menu-hidden { display:table-cell!important } .es-menu td { width:1%!important } table.es-table-not-adapt, .esd-block-html table { width:auto!important } table.es-social { display:inline-block!important } table.es-social td { display:inline-block!important } .es-m-p5 { padding:5px!important } .es-m-p5t { padding-top:5px!important } .es-m-p5b { padding-bottom:5px!important } .es-m-p5r { padding-right:5px!important } .es-m-p5l { padding-left:5px!important } .es-m-p10 { padding:10px!important } .es-m-p10t { padding-top:10px!important } .es-m-p10b { padding-bottom:10px!important } .es-m-p10r { padding-right:10px!important } .es-m-p10l { padding-left:10px!important } .es-m-p15 { padding:15px!important } .es-m-p15t { padding-top:15px!important } .es-m-p15b { padding-bottom:15px!important } .es-m-p15r { padding-right:15px!important }" +
 ".es-m-p15l { padding-left:15px!important } .es-m-p20 { padding:20px!important } .es-m-p20t { padding-top:20px!important } .es-m-p20r { padding-right:20px!important } .es-m-p20l { padding-left:20px!important } .es-m-p25 { padding:25px!important } .es-m-p25t { padding-top:25px!important } .es-m-p25b { padding-bottom:25px!important } .es-m-p25r { padding-right:25px!important } .es-m-p25l { padding-left:25px!important } .es-m-p30 { padding:30px!important } .es-m-p30t { padding-top:30px!important } .es-m-p30b { padding-bottom:30px!important } .es-m-p30r { padding-right:30px!important } .es-m-p30l { padding-left:30px!important } .es-m-p35 { padding:35px!important } .es-m-p35t { padding-top:35px!important } .es-m-p35b { padding-bottom:35px!important } .es-m-p35r { padding-right:35px!important } .es-m-p35l { padding-left:35px!important } .es-m-p40 { padding:40px!important } .es-m-p40t { padding-top:40px!important }" +
 ".es-m-p40b { padding-bottom:40px!important } .es-m-p40r { padding-right:40px!important } .es-m-p40l { padding-left:40px!important } .es-desk-hidden { display:table-row!important; width:auto!important; overflow:visible!important; max-height:inherit!important } }</style>" +
 "</head> <body style='width:100%;font-family:Montserrat, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0'><div dir='ltr' class='es-wrapper-color' lang='und' style='background-color:#0D2225'> <!--[if gte mso 9]><v:background xmlns:v='urn:schemas-microsoft-com:vml' fill='t'> <v:fill type='tile' color='#0d2225'></v:fill> </v:background><![endif]--><table class='es-wrapper' width='100%' cellspacing='0' cellpadding='0' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#0D2225'><tr>" +
"<td valign='top' style='padding:0;Margin:0'><table cellpadding='0' cellspacing='0' class='es-header' align='center' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top'><tr><td align='center' style='padding:0;Margin:0'><table bgcolor='#0f1011' class='es-header-body' align='center' cellpadding='0' cellspacing='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#0f1011;width:600px' role='none'><tr><td align='left' style='padding:0;Margin:0;padding-left:20px;padding-right:20px;padding-top:30px'><table cellpadding='0' cellspacing='0' width='100%' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr>" +
"<td class='es-m-p0r' valign='top' align='center' style='padding:0;Margin:0;width:560px'><table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td align='center' style='padding:0;Margin:0'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:'merriweather sans', 'helvetica neue', helvetica, arial, sans-serif;line-height:36px;color:#FFFFFF;font-size:24px'><strong><font color='#fff'>MecWash</font></strong> </p><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:'merriweather sans', 'helvetica neue', helvetica, arial, sans-serif;line-height:36px;color:#FFFFFF;font-size:24px'><b><font color='#fff'>Software</font></b></p></td></tr></table></td></tr></table></td></tr></table></td></tr></table>" +
 "<table cellpadding='0' cellspacing='0' class='es-content' align='center' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'><tr><td align='center' style='padding:0;Margin:0'><table bgcolor='#0f1011' class='es-content-body' align='center' cellpadding='0' cellspacing='0' background='https://xnhzoe.stripocdn.email/content/guids/CABINET_34ad95b423c6803288e09f9a846d2be17a85b2adbe6709a3e7ea35f3ca16bd7d/images/group_sRl.png' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#0F1011;background-repeat:no-repeat;width:600px;background-image:url(https://xnhzoe.stripocdn.email/content/guids/CABINET_34ad95b423c6803288e09f9a846d2be17a85b2adbe6709a3e7ea35f3ca16bd7d/images/group_sRl.png);background-position:400px 40px' role='none'><tr>" +
"<td align='left' style='Margin:0;padding-bottom:20px;padding-left:20px;padding-right:20px;padding-top:40px'><table cellpadding='0' cellspacing='0' width='100%' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td align='center' valign='top' style='padding:0;Margin:0;width:560px'><table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td align='left' class='es-m-txt-l' style='padding:0;Margin:0;padding-top:20px;padding-bottom:20px'><h1 style='Margin:0;line-height:60px;mso-line-height-rule:exactly;font-family:'Krona One', sans-serif;font-size:40px;font-style:normal;font-weight:bold;color:#FFFFFF'><font color='#fff'>Bienvenido a tu cuenta de <font color='#35ccd0'>MecWash</font> </font></h1></td></tr><tr>" +
"<td align='left' class='es-m-txt-l' style='padding:0;Margin:0;padding-bottom:20px'><h3 style='Margin:0;line-height:30px;mso-line-height-rule:exactly;font-family:'Krona One', sans-serif;font-size:20px;font-style:normal;font-weight:normal;color:#FFFFFF'><font color='#fff'>Hola " + nombre + ",</font></h3></td></tr><tr><td align='left' style='padding:0;Margin:0'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Montserrat, sans-serif;line-height:21px;color:white;font-size:14px'>Te has registrado a MecWash, tu app de mecánica automotriz favorita, con el correo " + correo + "</p></td></tr></table></td></tr></table></td></tr> <tr><td align='left' style='padding:20px;Margin:0'><table cellpadding='0' cellspacing='0' width='100%' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr>" +
"<td align='center' valign='top' style='padding:0;Margin:0;width:560px'><table cellpadding='0' cellspacing='0' width='100%' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:separate;border-spacing:0px;border-left:1px solid #35ccd0;border-right:1px solid #35ccd0;border-top:1px solid #35ccd0;border-bottom:1px solid #35ccd0;border-radius:15px' role='presentation'><tr><td align='center' style='padding:0;Margin:0'> <!--[if mso]><a href='https://boomerang.software' target='_blank' hidden> <v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns:w='urn:schemas-microsoft-com:office:word' esdevVmlButton href='https://boomerang.software' style='height:51px; v-text-anchor:middle; width:252px' arcsize='29%' stroke='f' fillcolor='#35ccd0'> <w:anchorlock></w:anchorlock>"+
 "</v:roundrect></a><![endif]--> <!--[if !mso]><!-- --><span class='msohide es-button-border' style='border-style:solid;border-color:#2CB543;background:#35CCD0;border-width:0px;display:inline-block;border-radius:15px;width:auto;mso-hide:all'></td></tr></table></td></tr></table></td></tr></table></td></tr></table>" +
 "<table cellpadding='0' cellspacing='0' class='es-content' align='center' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'><tr><td align='center' style='padding:0;Margin:0'><table bgcolor='#ffffff' class='es-content-body' align='center' cellpadding='0' cellspacing='0' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#0F1011;width:600px'><tr><td align='left' style='padding:0;Margin:0;padding-top:20px;padding-left:20px;padding-right:20px'><table cellpadding='0' cellspacing='0' width='100%' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'>" +
"<td align='center' valign='top' style='padding:0;Margin:0;width:560px'><table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td align='center' style='padding:0;Margin:0'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Montserrat, sans-serif;line-height:24px;color:#FFFFFF;font-size:16px'>Codigo de Verificación</p> </td></tr></table></td></tr></table></td></tr></table></td></tr></table> <table cellpadding='0' cellspacing='0' class='es-content' align='center' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'><tr>" +
"<td align='center' style='padding:0;Margin:0'><table bgcolor='#ffffff' class='es-content-body' align='center' cellpadding='0' cellspacing='0' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#0F1011;width:600px'><tr><td align='left' style='padding:0;Margin:0;padding-top:20px;padding-left:20px;padding-right:20px'><table cellpadding='0' cellspacing='0' width='100%' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td align='center' valign='top' style='padding:0;Margin:0;width:560px'><table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr>" +
"<td align='center' style='padding:0;Margin:0'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:Montserrat, sans-serif;line-height:33px;color:#FFFFFF;font-size:22px'><strong><u>" + codigo + "</u> </strong></p></td></tr></table></td></tr></table></td></tr></table></td></tr></table> <table cellpadding='0' cellspacing='0' class='es-content' align='center' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'><tr><td align='center' style='padding:0;Margin:0'><table bgcolor='#ffffff' class='es-content-body' align='center' cellpadding='0' cellspacing='0' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#0F1011;width:600px'><tr>" +
"<td align='left' style='padding:0;Margin:0;padding-left:20px;padding-right:20px;padding-top:30px'><table cellpadding='0' cellspacing='0' width='100%' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td align='center' valign='top' style='padding:0;Margin:0;width:560px'><table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td align='center' style='padding:0;Margin:0;padding-bottom:5px;padding-top:30px;font-size:0'><table border='0' width='100%' height='100%' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td style='padding:0;Margin:0;border-bottom:2px solid #ffffff;background:none;height:1px;width:100%;margin:0px'></td> </tr></table></td></tr></table></td></tr>" +
"<tr><td align='center' valign='top' style='padding:0;Margin:0;width:560px'><table cellpadding='0' cellspacing='0' width='100%' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td align='center' style='padding:0;Margin:0;padding-top:5px;padding-bottom:30px;font-size:0'><table border='0' width='100%' height='100%' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td style='padding:0;Margin:0;border-bottom:2px solid #ffffff;background:none;height:1px;width:100%;margin:0px'></td></tr></table></td></tr></table></td></tr></table></td></tr> <tr>" +
"<td align='left' style='padding:0;Margin:0;padding-top:20px;padding-left:20px;padding-right:20px'><table cellpadding='0' cellspacing='0' width='100%' role='none' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tbody class='ui-droppable-hover'><tr><td align='center' valign='top' style='padding:0;Margin:0;width:560px'><table cellpadding='0' cellspacing='0' width='100%' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:separate;border-spacing:0px;border-radius:10px' role='presentation'><tr><td align='center' style='padding:0;Margin:0;font-size:0px'><img class='adapt-img' src='https://www.mapfre.cl/media/pastillas-y-discos-de-freno-un-cambio-necesario-para-tu-seguridad.jpg' alt style='display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic' width='545' height='257'></td></tr> <tr>" +
"<td align='center' style='padding:0;Margin:0;padding-bottom:5px;padding-top:30px;font-size:0'><table border='0' width='100%' height='100%' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr><td style='padding:0;Margin:0;border-bottom:2px solid #ffffff;background:none;height:1px;width:100%;margin:0px'></td></tr></table></td></tr></table></td></tr></table></td></tr></table></td></tr></table></td></tr></table></div></body></html>";

                // Configuración del cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient("smtp.zoho.com");
                clienteSmtp.Port = 587;
                clienteSmtp.Credentials = new NetworkCredential("soporteboofast@zohomail.com","Mireyra135#");
                clienteSmtp.EnableSsl = true;

                // Crear el mensaje de correo
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("soporteboofast@zohomail.com");
                mensaje.To.Add(correo);
                mensaje.Subject = "Bienvenido a MecWash";
                mensaje.Body = cuerpo;

                mensaje.IsBodyHtml = true;
                clienteSmtp.Send(mensaje);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "notiError('Error correo no valido!');", true);
            }
        }

        protected void llenarCookie(int idc)
        {
            DataTable dtC = new DataTable();
            eC.IDCliente = idc;
            dtC = nC.listarCarrito(eC);

            HttpCookie carritoCookie = Request.Cookies["Carrito"];

            if (carritoCookie == null)
            {
                carritoCookie = new HttpCookie("Carrito");
                carritoCookie.Expires = DateTime.Now.AddDays(10); // Puedes ajustar la duración de la cookie.
            }

            List<CarritoServicio> carrito = new List<CarritoServicio>();

            foreach (DataRow row in dtC.Rows)
            {
                // Obtener los valores de las columnas necesarias del DataTable
                int idServicio = Convert.ToInt32(row["IDServicio"]);
                decimal precio = Convert.ToDecimal(row["precio"]);
                string imagen = row["imagen"].ToString(); // Ajusta el nombre de la columna según tu DataTable
                string nom = row["TipoServicio"].ToString(); // Ajusta el nombre de la columna según tu DataTable

                // Crear un nuevo producto y agregarlo a la lista
                CarritoServicio nuevoProducto = new CarritoServicio(idc, idServicio, precio, imagen, nom);
                carrito.Add(nuevoProducto);
            }

            // Serializa la lista de productos y actualiza la cookie.
            carritoCookie.Value = JsonConvert.SerializeObject(carrito);
            Response.Cookies.Set(carritoCookie);
        }


    }
}
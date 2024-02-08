using cinchiglemasus.Modelos;
using System.Net;

namespace cinchiglemasus.Vistas;

public partial class ActualizarEliminar : ContentPage
{
    private Estudiante datos;
	public ActualizarEliminar(Estudiante datos)
	{
		InitializeComponent();
        this.datos = datos;
        lblCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtCurso.Text = datos.curso;
        txtParalelo.Text = datos.paralelo;
        txtNota.Text = datos.nota.ToString();
        
        	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
            
        {
            string codigo = lblCodigo.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string curso = txtCurso.Text;
            string paralelo = txtParalelo.Text;
            string nota = txtNota.Text;
            string url = "http://192.168.17.53:8080/moviles/post.php" + codigo + "&nombre=" + nombre + "&apellido" + apellido + "&curso" + curso + "&paralelo" + paralelo + "&nota" + nota;
            WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(url, "PUT", parametros);
            Navigation.PushAsync(new Vistas.Principal());
        } 
        catch (Exception ex) 
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = lblCodigo.Text;
            string url = "http://192.168.17.53:8080/moviles/post.php" + codigo;
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(url, "Delete", parametros);
            Navigation.PushAsync(new Vistas.Principal());

        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, ex.Message, "CERRAR");
        }
    }
}
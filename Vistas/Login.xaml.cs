namespace cinchiglemasus.Vistas;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void btnIngreso_Clicked(object sender, EventArgs e)
    {
        // Obtener los datos de conexi�n
        string usuario = txtUsuario.Text;
        string contrasena = txtContrase�a.Text;

        // Validar los datos de conexi�n
        bool esValido = false;
        for (int i = 0; i < usuarios.Length; i++)
        {
            if (usuario == usuarios[i] && contrasena == contrasenas[i])
            {
                esValido = true;
                break;
            }
        }

        // Si los datos son v�lidos, mostrar un mensaje de bienvenida
        if (esValido)
        {
            DisplayAlert("Bienvenido", "Usuario conectado: " + usuario, "Aceptar");
            Navigation.PushAsync(new Vistas.Principal());
        }
        // Si los datos son no v�lidos, mostrar un mensaje de error
        else
        {
            DisplayAlert("Error", "Usuario/Contrase�a incorrectos", "Cancel");
        }
    }

    // Vectores con los datos de conexi�n
    static string[] usuarios = { "Admin", "Estudiante", "Cristian" };
    static string[] contrasenas = { "admin", "estudiante123", "Cristian123" };

    }

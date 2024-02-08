namespace cinchiglemasus.Vistas;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void btnIngreso_Clicked(object sender, EventArgs e)
    {
        // Obtener los datos de conexión
        string usuario = txtUsuario.Text;
        string contrasena = txtContraseña.Text;

        // Validar los datos de conexión
        bool esValido = false;
        for (int i = 0; i < usuarios.Length; i++)
        {
            if (usuario == usuarios[i] && contrasena == contrasenas[i])
            {
                esValido = true;
                break;
            }
        }

        // Si los datos son válidos, mostrar un mensaje de bienvenida
        if (esValido)
        {
            DisplayAlert("Bienvenido", "Usuario conectado: " + usuario, "Aceptar");
            Navigation.PushAsync(new Vistas.Principal());
        }
        // Si los datos son no válidos, mostrar un mensaje de error
        else
        {
            DisplayAlert("Error", "Usuario/Contraseña incorrectos", "Cancel");
        }
    }

    // Vectores con los datos de conexión
    static string[] usuarios = { "Admin", "Estudiante", "Cristian" };
    static string[] contrasenas = { "admin", "estudiante123", "Cristian123" };

    }

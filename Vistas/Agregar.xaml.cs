namespace cinchiglemasus.Vistas;

public partial class Agregar : ContentPage
{
	public Agregar()
	{
		InitializeComponent();
	}

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			var httpClient = new HttpClient();
			var parametros = new List<KeyValuePair<string, string>>
			{ new KeyValuePair<string, string>("nombre", txtNombre.Text),
			new KeyValuePair<string, string>("apellido", txtApellido.Text),
			new KeyValuePair<string, string>("curso", txtCurso.Text),
			new KeyValuePair<string, string>("paralelo", txtParalelo.Text),
			new KeyValuePair<string, string>("nota", txtNota.Text),
			};
			var content = new FormUrlEncodedContent(parametros);
			var response = await httpClient.PostAsync("http://192.168.17.53:8080/moviles/post.php", content);
			if (response.IsSuccessStatusCode)
			{
				await DisplayAlert("Exito", "Estudiante agregado correctamente", "OK");
				await Navigation.PushAsync(new Vistas.Principal());
			}
			else
			{
				await DisplayAlert("Error", "No puede agregar estudiante", "OK");
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("ERROR", ex.Message, "OK");
		}
    }
}
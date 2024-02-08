using cinchiglemasus.Modelos;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace cinchiglemasus.Vistas;

public partial class Principal : ContentPage
{

    private const string Url = "http://192.168.17.53:8080/moviles/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> estud;

    public Principal()
	{
		InitializeComponent();
        Obtener();
	}
    public async void Obtener()
    {
        try
        {
            var content = await cliente.GetStringAsync(Url);
            List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
            estud = new ObservableCollection<Estudiante>(mostrarEst);
            listaEstudiantes.ItemsSource = estud;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener los Datos:" + ex.Message);
        }
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if(e.SelectedItem != null)
        {
            var objetoestudiante = (Estudiante)e.SelectedItem;
            Navigation.PushAsync(new ActualizarEliminar(objetoestudiante));
            listaEstudiantes.SelectedItem = null;
        }

    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Vistas.Agregar());
    }
}
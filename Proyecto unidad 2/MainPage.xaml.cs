using Proyecto_unidad_2.Models;
using Proyecto_unidad_2.Services;


namespace Proyecto_unidad_2;

public partial class MainPage : ContentPage
{
    private readonly DatabaseService _dbService = new();

    public MainPage()
    {
        InitializeComponent();
        CargarPersonas();
    }

    private async void CargarPersonas()
    {
        var personas = await _dbService.ObtenerPersonasAsync();
        PersonasCollection.ItemsSource = personas;
    }

    private async void OnAgregarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgregarPage());
    }
    /*
    private async void OnEditarClicked(object sender, EventArgs e)
    {
        var persona = (sender as Button)?.CommandParameter as Persona;
        if (persona != null)
        {
            await Navigation.PushAsync(new EditarPage(persona));
        }
    }

    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        var persona = (sender as Button)?.CommandParameter as Persona;
        if (persona != null)
        {
            bool confirm = await DisplayAlert("Confirmar", $"¿Eliminar a {persona.Nombre}?", "Sí", "No");
            if (confirm)
            {
                await _dbService.EliminarPersonaAsync(persona.id_nombre);
                CargarPersonas(); // Refrescar
            }
        }
    }
    */
}

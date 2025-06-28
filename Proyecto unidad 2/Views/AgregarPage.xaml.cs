using Proyecto_unidad_2.Services;
using Proyecto_unidad_2.Models;
namespace Proyecto_unidad_2;

public partial class AgregarPage : ContentPage
{
    private readonly DatabaseService _dbService = new();

    public AgregarPage()
    {
        InitializeComponent();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nombreEntry.Text) ||
            string.IsNullOrWhiteSpace(correoEntry.Text) ||
            string.IsNullOrWhiteSpace(telefonoEntry.Text))
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
            return;
        }

        var nuevaPersona = new Persona
        {
            Nombre = nombreEntry.Text,
            Correo = correoEntry.Text,
            Telefono = telefonoEntry.Text
        };

        await _dbService.AgregarPersonaAsync(nuevaPersona);
        await DisplayAlert("Éxito", "Persona agregada correctamente.", "OK");
        await Navigation.PopAsync(); // Regresar a la página anterior
    }
}
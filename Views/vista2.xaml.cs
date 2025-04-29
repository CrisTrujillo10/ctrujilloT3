using System.Diagnostics.Metrics;

namespace ctrujilloT3.Views;

public partial class vista2 : ContentPage
{
    public vista2(string tipoIdentificacion, string numeroIdentificacion, string nombres, string apellidos,
        DateTime fecha, string correo, decimal salario)
    {
        InitializeComponent();
        lblTipoIdentificacion.Text = tipoIdentificacion;
        lblNumeroIdentificacion.Text = numeroIdentificacion;
        lblNombres.Text = nombres;
        lblApellidos.Text = apellidos;
        lblFecha.Text = fecha.ToString("yyyy/MM/dd");
        lblCorreo.Text = correo;
        lblSalario.Text = $"${salario:F2}";

        decimal aporteIESS = salario * 0.0945m;
        lblAporteIESS.Text = $"Aporte IESS: ${aporteIESS:F2}";
    }

    private void btnExportar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string tipoIdentificacion = lblTipoIdentificacion.Text;
            string numeroIdentificacion = lblNumeroIdentificacion.Text;
            string nombres = lblNombres.Text;
            string apellidos = lblApellidos.Text;
            string fecha = lblFecha.Text;
            string correo = lblCorreo.Text;
            string salario = lblSalario.Text;
            string aporteIESS = lblAporteIESS.Text;

            string contenido = $"Tipo de Identificación: {tipoIdentificacion}\n" +
                               $"Número de Identificación: {numeroIdentificacion}\n" +
                               $"Nombres: {nombres}\n" +
                               $"Apellidos: {apellidos}\n" +
                               $"Fecha: {fecha}\n" +
                               $"Correo: {correo}\n" +
                               $"Salario: {salario}\n" +
                               $"{aporteIESS}\n";

            string contactos = @"C:\Desarrollo de Aplicaciones Moviles\Contactos";

            string path = Path.Combine(contactos, "contactos.txt");

            File.WriteAllText(path, contenido);

            DisplayAlert("Éxito", "Datos exportados correctamente", "Cerrar");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Hubo un error al exportar: {ex.Message}", "Cerrar");
        }
    }
}
using System.Text.RegularExpressions;

namespace ctrujilloT3.Views;

public partial class vista1 : ContentPage
{
	public vista1()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                    string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                     ||
                    string.IsNullOrWhiteSpace(txtSalario.Text))
                {
                    DisplayAlert("Error", "Por favor, ingrese todos los datos", "OK");
                    return;
                }

                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string Edad = txtEdad.Text.Trim();
                string Salario = txtSalario.Text.Trim();

                if (!Regex.IsMatch(nombre, "^[a-zA-Z·ÈÌÛ˙¡…Õ”⁄Ò— ]+$") ||
                    !Regex.IsMatch(apellido, "^[a-zA-Z·ÈÌÛ˙¡…Õ”⁄Ò— ]+$"))
                {
                    DisplayAlert("Error", "Ingrese de nuevo los nombres y apellidos", "OK");
                    return;
                }

                if (!int.TryParse(Edad, out int edad))
                {
                    DisplayAlert("Error", "Ingrese de nuevo la edad", "OK");
                    return;
                }

                if (!decimal.TryParse(Salario, out decimal salario))
                {
                    DisplayAlert("Error", "Ingrese de nuevo el salario", "OK");
                    return;
                }

                decimal aporteIESS = salario * 0.0945m;

                string mensaje = $"Bienvenido {nombre} {apellido}\n" +
                                 $"Tienes {edad} aÒos\n" +
                                 $"Tu aporte mensual es: ${aporteIESS:F2}";

                lblResultado.Text = mensaje;
                DisplayAlert("Alerta de Salario", mensaje, "Cerrar");
            }

            catch (Exception ex)
            {
                DisplayAlertException(ex);
            }
        }

    }
}
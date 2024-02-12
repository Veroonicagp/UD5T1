namespace UD5T1;

public partial class MainPage : ContentPage
{
    decimal cuenta;
    int propina;
    int personas = 1;

    public MainPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    private void CalcularTotal()
    {
        //Propina total
        var propinaTotal = cuenta * propina / 100;

        //propina por persona
        var propinaPorPersona = propinaTotal / personas;
        lblPropinaPorPersona.Text = $"{propinaPorPersona:C}";

        //Subtototal
        var subtotal = cuenta / personas;
        lblSubTotal.Text = $"{subtotal:C}";

        //Total
        var totalPorPersona = (cuenta + propinaTotal) / personas;
        lblTotal.Text = $"{totalPorPersona:C}";
    }

    /// <summary>
    /// valor de la cuenta y calcula el total 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TxtCuenta_Completed(object sender, EventArgs e)
    {
        cuenta = decimal.Parse(txtCuenta.Text);
        CalcularTotal();
    }


    /// <summary>
    /// obtenemos el valor propina y calculamos el total
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SldPropina_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        propina = (int)sldPropina.Value;
        lblPropina.Text = $"Propina: {propina.ToString()}%";
        CalcularTotal();

    }


    /// <summary>
    /// manda informacion del boton al slider
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            var porcentaje = int.Parse(btn.Text.Replace("%", string.Empty));
            sldPropina.Value = porcentaje;
        }
    }

    /// <summary>
    /// obtenemos el click del boton y restamos
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnMenos_Clicked(object sender, EventArgs e)
    {
        if (personas > 1)
        {
            personas--;
            lblPersonas.Text = $"{personas}";
            CalcularTotal();
        }
    }

    /// <summary>
    ///  obtenemos el click del boton y sumamos una persona
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnMas_Cliked(object sender, EventArgs e)
    {
        personas++;
        lblPersonas.Text = $"{personas}";
        CalcularTotal();
    }

}


using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Examen_Mvvm.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private decimal producto1;

        [ObservableProperty]
        private decimal producto2;

        [ObservableProperty]
        private decimal producto3;

        [ObservableProperty]
        private decimal subtotal;

        [ObservableProperty]
        private decimal descuento;

        [ObservableProperty]
        private decimal total;

        [ObservableProperty]
        private string tipoDescuento;

        [RelayCommand]
        public async void Calcular()
        {

            if (Producto1 == 0 && Producto2 == 0 && Producto3 == 0)
            {

                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar al menos un valor para calcular el descuento.",
                    "OK");
                return;
            }


            Subtotal = Producto1 + Producto2 + Producto3;


            if (Subtotal >= 0 && Subtotal < 1000)
            {
                Descuento = 0;
                TipoDescuento = "Sin descuento";
            }
            else if (Subtotal >= 1000 && Subtotal < 5000)
            {
                Descuento = Subtotal * 0.10m;
                TipoDescuento = "10%";
            }
            else if (Subtotal >= 5000 && Subtotal < 10000)
            {
                Descuento = Subtotal * 0.20m;
                TipoDescuento = "20%";
            }
            else
            {
                Descuento = Subtotal * 0.30m;
                TipoDescuento = "30%";
            }


            Total = Subtotal - Descuento;
        }

        [RelayCommand]
        public void Limpiar()
        {
            Producto1 = 0;
            Producto2 = 0;
            Producto3 = 0;
            Subtotal = 0;
            Descuento = 0;
            Total = 0;
            TipoDescuento = string.Empty;
        }
    }
}

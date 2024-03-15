using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using NartyWypo.ViewModels;
using ReactiveUI;

namespace NartyWypo.Views;

public partial class DataFormView : ReactiveWindow<DataFormViewModel>
{
    public DataFormView()
    {
        {
            InitializeComponent();

            void InitializeComponent()
            {
                AvaloniaXamlLoader.Load(this);
            }


        }
    }
}
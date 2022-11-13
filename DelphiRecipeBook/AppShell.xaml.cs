
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DelphiRecipeBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
    }
}
using PharmaceuticalsApp.Ui;
using PharmaceuticalsApp.Ui.ViewModel;
using System.Windows;

namespace PharmaceuticalsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new MainWindow()
            {
                DataContext = new MainWindowViewModel()
            }.Show();

            base.OnStartup(e);
        }
    }
}

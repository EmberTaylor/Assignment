using PharmaceuticalsApp.Ui;
using PharmaceuticalsApp.Ui.ViewModel;
using System.Windows;

namespace PharmaceuticalsApp
{
    //todo:
    //A comprehensive Test Plan and results for your program 
    //(Use of sensible unit testing within your project(s) will mainly satisfy this requirement 
    //though you will need to provide further evidence of specific UI tests)
    //Evidence of your testing strategy is required (test data, expected outcomes, actual outcomes, etc.)

    //todo:
    //Write a report that critically reviews:
    //-your solution, 
    //-the approach taken, 
    //-your thoughts about object oriented programming in C# 
    //-the Visual Studio development environment. 
    //-What you did and didn’t like about them, giving full reasoning. 
    //-Explain the things you thought went well, and why, 
    //-the things that could have gone better, and why. 
    //Give examples, code samples and screen shots to back-up your comments. (Word Limit: 1500 - 2000)

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

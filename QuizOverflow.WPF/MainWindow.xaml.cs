using QuizOverflow.Services.Contracts;
using System.Windows.Navigation;

namespace QuizOverflow.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow(ISeedService seedService)
        {
            seedService.SeedCategories();
            seedService.SeedQuestions();
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

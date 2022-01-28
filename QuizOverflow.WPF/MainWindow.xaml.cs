using QuizOverflow.Services.Contracts;
using System.Threading.Tasks;
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
            Task.Run(() => seedService.SeedCategories()).Wait();
            Task.Run(() => seedService.SeedQuestions()).Wait();
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

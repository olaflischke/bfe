using GefluegelBl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Composition;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using io = System.IO;

namespace GefluegelUi
{
    /// <summary>
    /// Interaction logic for NeuesTier.xaml
    /// </summary>
    public partial class NeuesTier : Window, INotifyPropertyChanged
    {
        CompositionContainer tiercontainer;

        [ImportMany]
        IEnumerable<Lazy<IEiLeger, IEiLegerInfo>> typen;

        public NeuesTier()
        {
            InitializeComponent();
            InitComposition();
            this.Tiere = typen.Select(tp => tp.Value).ToList();
            this.DataContext = this;
        }

        private IEiLeger _tier;

        public IEiLeger Tier
        {
            get { return _tier; }
            set { _tier = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propName="")
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public List<IEiLeger> Tiere { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void btnNeu_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void InitComposition()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            string extensionsDir = io.Path.Combine(io.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Extensions");
            catalog.Catalogs.Add(new DirectoryCatalog(extensionsDir));

            this.tiercontainer = new CompositionContainer(catalog);

            //Fill the imports of this object  
            try
            {
                this.tiercontainer.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                throw new Exception("Fehler beim Laden der Tiertypen", compositionException);
            }
        }

    }
}

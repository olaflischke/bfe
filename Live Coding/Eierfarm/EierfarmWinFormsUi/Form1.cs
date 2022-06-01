using EierfarmBl;

namespace EierfarmWinFormsUi
{
    public partial class frmEierfarm : Form
    {
        public frmEierfarm()
        {
            InitializeComponent();
        }

        private void btnNeuesHuhn_Click(object sender, EventArgs e)
        {
            Huhn huhn = new();

            huhn.EigenschaftGeaendert += this.Gefluegel_EigenschaftGeaendert;

            cbxTiere.Items.Add(huhn);
            cbxTiere.SelectedItem = huhn;
        }

        private void Gefluegel_EigenschaftGeaendert(object? sender, GefluegelEventArgs e)
        {
            //MessageBox.Show($"Tier {((Gefluegel)sender).Name} hat Eigenschaft {e.GeaenderteProperty} geändert.");
            pgdTier.SelectedObject = (Gefluegel)sender;
        }

        private void cbxTiere_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgdTier.SelectedObject = cbxTiere.SelectedItem;
        }

        private void btnNeueGans_Click(object sender, EventArgs e)
        {
            Gans gans = new();

            gans.EigenschaftGeaendert += Gefluegel_EigenschaftGeaendert;

            cbxTiere.Items.Add(gans);
            cbxTiere.SelectedItem = gans;
        }

        private void btnFuettern_Click(object sender, EventArgs e)
        {
            if (cbxTiere.SelectedItem is Gefluegel tier)
            {
                tier.Fressen();
            }
        }

        private void btnEiLegen_Click(object sender, EventArgs e)
        {
            // DirectCast - kann Exceptiosn erzeugen
            //IEileger tier = (IEileger)cbxTiere.SelectedItem;

            // SafeCast - liefert null, wenn Cast fehlschlägt
            IEileger tier = cbxTiere.SelectedItem as IEileger;

            if (tier != null)
            {
                if (tier is Gans gans)
                {
                    gans.EiLegen(); // EiLegen aus der Gans
                }
                else
                    tier.EiLegen(); // EiLegen aus IEileger, egal welcher konkrete Typ!
            }

        }

    }
}
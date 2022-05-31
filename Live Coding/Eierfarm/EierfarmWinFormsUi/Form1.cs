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

            cbxTiere.Items.Add(huhn);
            cbxTiere.SelectedItem = huhn;
        }

        private void cbxTiere_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgdTier.SelectedObject = cbxTiere.SelectedItem;
        }

        private void btnNeueGans_Click(object sender, EventArgs e)
        {
            Gans gans = new();

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
                tier.EiLegen();
            }

        }
    }
}
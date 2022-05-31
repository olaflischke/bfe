namespace EierfarmBl
{
    public class Huhn : Gefluegel
    {
        public Huhn():base("Neues Huhn")
        {
            //this.Id = Guid.NewGuid();
            this.Schuepfdatum = DateOnly.FromDateTime(DateTime.Now.AddDays(-90));
            this.Gewicht = 1000;
        }


        public override void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                Ei ei = new(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < 3000)
            {
                this.Gewicht += 100;
            }
        }
    }
}
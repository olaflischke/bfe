namespace EierfarmBl
{
    public class Huhn : Gefluegel
    {
        public Huhn():base("Neues Huhn")
        {
            //this.Id = Guid.NewGuid();
            this.Schuepfdatum = DateOnly.FromDateTime(DateTime.Now.AddDays(-90));
            this.Weight = 1000;
            this.MindestEiLegeGewicht = 1500;
        }


        //public override void EiLegen()
        //{
        //    if (this.Weight > 1500)
        //    {
        //        Ei ei = new(this);
        //        this.Weight -= ei.Gewicht;
        //        this.Eier.Add(ei);
        //    }
        //}
        public override void Fressen()
        {
            if (this.Weight < 3000)
            {
                this.Weight += 100;
            }
        }
    }
}
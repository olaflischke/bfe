namespace RangesSpansUndMemory
{
    public class ArrayFeatures
    {
        void ArraysInCore()
        {

            string[] leute = { "Theo", "Barbara", "Nicole", "Klaus", "Werner", "Petra" };

            string klaus = leute[3]; // null-basiert von vorn

            string werner = leute[^2]; // "Zweiter von hinten" - 1-basiert!

            Index iKlaus = 3;
            string klaus2 = leute[iKlaus];

            Index iWerner = ^2;
            string werner2 = leute[iWerner];

            Range range = 0..2;
            string[] dieErstenDrei = leute[range];
            string[] abDrei = leute[3..];
            string[] bisDrei = leute[..3];

            int[] zahlen = new int[20000];


        }
    }
}
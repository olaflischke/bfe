using System;
using System.Diagnostics;

namespace SpanAndMemoryTestSamples
{
    public class Tests
    {
        private byte[] data;

        [SetUp]
        public void Setup()
        {
            data = new byte[100000000];
            new Random(42).NextBytes(data);
        }

        //byte[] InitData()
        //{
        //    byte[] data = new byte[1000000];
        //    new Random(42).NextBytes(data);
        //    return data;
        //}

        [Test]
        public void ArraySumTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            int result = SpanSamples.ArraySum(data);

            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}ms");
            stopwatch.Reset();


            Assert.Pass();
        }

        [Test]
        public void SpanSumTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            int result = SpanSamples.SpanSum(data);

            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}ms");
            stopwatch.Reset();


            Assert.Pass();
        }

        [Test]
        public void StringParseTest()
        {
            string numbers = "1, 2, 3, 4, 5, 6, 7";

            Stopwatch stopwatch = Stopwatch.StartNew();

            int r1 = SpanSamples.StringParseSum(numbers);
            Console.WriteLine($"{r1} in {stopwatch.ElapsedTicks}");

            stopwatch.Restart();

            int r2 = SpanSamples.StringParseSumWithSpan(numbers);
            Console.WriteLine($"{r2} in {stopwatch.ElapsedTicks}");

            stopwatch.Restart();

            int r3 = SpanSamples.StringParseSumWithArrayPool(numbers);
            Console.WriteLine($"{r3} in {stopwatch.ElapsedTicks}");
        }
    }
}
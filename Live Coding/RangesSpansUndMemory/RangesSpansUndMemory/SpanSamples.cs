using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanAndMemoryTestSamples
{
    public class SpanSamples
    {
        void SimpleSpan()
        {
            byte[] array = new byte[4];

            // using ctor: public Span(T[] array)
            Span<byte> span = new Span<byte>(array);

            // using AsSpan extension method
            Span<byte> alt = array.AsSpan();

            // using Slice to get exactly that: A slice.
            Span<byte> slice = alt.Slice(start: 1, length: 2);

            // Keep in mind that spans are only a view into the underlying memory and aren't a way to instantiate a block of memory. Span<T> provides read-write access to the memory and ReadOnlySpan<T> provides read-only access. Therefore, creating multiple spans on the same array creates multiple views of the same memory. Like with arrays, you can use the Span<T> indexer to access or modify the underlying data directly.
        }

        void SaveAccessToSpan()
        {
            // Some array to play with
            string[] array = { "a", "b", "c", "d", "e" };

            // Using Span ctor (array, start, length)
            // Note that the spans overlap
            var firstView = new Span<string>(array, 0, 3);
            var secondView = new Span<string>(array, 2, 3);

            firstView[0] = "w";
            // array = { "w", "b", "c", "d", "e" }

            firstView[2] = "x";
            // array = { "w", "b", "x", "d", "e" }

            secondView[0] = "y";
            // array = { "w", "b", "y", "d", "e" }

            // Throws IndexOutOfRangeException
            firstView[4] = "a";

        }

        public static int ArraySum(byte[] data)
        {
            int sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i];
            }
            return sum;
        }

        public static int SpanSum(Span<byte> data)
        {
            int sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i];
            }
            return sum;
        }

        public static int StringParseSum(string data)
        {
            int sum = 0;
            // allocates memory
            string[] splitString = data.Split(',');
            for (int i = 0; i < splitString.Length; i++)
            {
                sum += int.Parse(splitString[i]);
            }
            return sum;
        }

        public static int StringParseSumWithSpan(string data)
        {
            // allocates Memory
            Span<byte> utf8 = Encoding.UTF8.GetBytes(data);
            int sum = 0;
            while (true)
            {
                // Utf8Parser is faster than usual UTF16 strings
                Utf8Parser.TryParse(utf8, out int value, out int bytesConsumed);
                sum += value;
                if (utf8.Length - 1 < bytesConsumed)
                    break;
                // skip ','    
                utf8 = utf8.Slice(bytesConsumed + 1);
            }
            return sum;
        }

        public static int StringParseSumWithArrayPool(string data)
        {
            Encoding encode = Encoding.UTF8;
            ArrayPool<byte> pool = ArrayPool<byte>.Shared;

            int minLength = encode.GetByteCount(data);
            byte[] array = pool.Rent(minLength);
            Span<byte> utf8 = array;
            int bytesWritten = encode.GetBytes(data, utf8);
            utf8 = utf8.Slice(0, bytesWritten);

            int sum = 0;
            while (true)
            {
                // Utf8Parser is faster than usual UTF16 strings
                Utf8Parser.TryParse(utf8, out int value, out int bytesConsumed);
                sum += value;
                if (utf8.Length - 1 < bytesConsumed)
                    break;
                // skip ','    
                utf8 = utf8.Slice(bytesConsumed + 1);
            }

            return sum;
        }

        #region Reverse Array with Span
        public static int HeapAllocReverseArray(int[] data)
        {
            // Heap-allocated array for defensive copy
            int[] array = new int[data.Length];
            Array.Copy(data, array, data.Length);
            Array.Reverse(array);
            return array[0];
        }

        public static int UnsafeStackAllocReverse(int[] data)
        {
            unsafe  // unsafe compiling needs to be enabled in  project settings
            {
                // We lose safety and bounds checks
                int* ptr = stackalloc int[data.Length];
                // No APIs available to copy and reverse
                for (int i = 0; i < data.Length; i++)
                {
                    ptr[i] = data[data.Length - i - 1];
                }
                return ptr[0];
            }
        }

        public static int SafeStackOrHeapAllocReverse(int[] data)
        {
            // Chose an arbitrary small constant
            Span<int> span = data.Length < 128 ?
                        stackalloc int[data.Length] :
                        new int[data.Length];
            data.CopyTo(span);
            span.Reverse();
            return span[0];
        }
        #endregion
    }
}

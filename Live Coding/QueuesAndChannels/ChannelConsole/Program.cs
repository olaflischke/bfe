using System.Threading.Channels;

static class Program
{

    static async Task Main(string[] args)
    {
        var myChannel = Channel.CreateUnbounded<int>();
        for (int i = 0; i < 10; i++)
        {
            await myChannel.Writer.WriteAsync(i);
        }
        while (true)
        {
            var item = await myChannel.Reader.ReadAsync();
            Console.WriteLine(item);
        }
    }

    static async Task ThreadSafeDemo(string[] args)
    {
        var myChannel = Channel.CreateUnbounded<int>();
        _ = Task.Factory.StartNew(async () =>
        {
            for (int i = 0; i < 10; i++)
            {
                await myChannel.Writer.WriteAsync(i);
                await Task.Delay(1000);
            }
        });
        while (true)
        {
            var item = await myChannel.Reader.ReadAsync(); // waiting, not blocking!
            Console.WriteLine(item);
        }
    }

    static async Task ClosingChannel(string[] args)
    {
        var myChannel = Channel.CreateUnbounded<int>();
        _ = Task.Factory.StartNew(async () =>
        {
            for (int i = 0; i < 10; i++)
            {
                await myChannel.Writer.WriteAsync(i);
            }
            myChannel.Writer.Complete(); // Not closed immediately, instead notifies readers of closing after last message
        });
        try
        {
            while (true)
            {
                var item = await myChannel.Reader.ReadAsync();
                Console.WriteLine(item);
                await Task.Delay(1000);
            }
        }
        catch (ChannelClosedException e)
        {
            Console.WriteLine("Channel was closed!");
        }
    }

    static async Task ChannelWithIAsyncEnumerable(string[] args)
    {
        var myChannel = Channel.CreateUnbounded<int>();
        _ = Task.Factory.StartNew(async () =>
        {
            for (int i = 0; i < 10; i++)
            {
                await myChannel.Writer.WriteAsync(i);
            }
            myChannel.Writer.Complete();
        });
        await foreach (var item in myChannel.Reader.ReadAllAsync()) // cleaner exit for closed channel, no exception handling here
        {
            Console.WriteLine(item);
            await Task.Delay(1000);
        }
    }

    static async Task BoundChannel(string[] args)
    {
        // Channel with max. 1.000 messages
        Channel<int> channel1000 = Channel.CreateBounded<int>(1000);

        // Channel with max. 5 messages, telling writers to wait for capacity
        BoundedChannelOptions channelOptions = new BoundedChannelOptions(5)
        {
            FullMode = BoundedChannelFullMode.Wait
        };
        Channel<int> channel5 = Channel.CreateBounded<int>(channelOptions);

        // Write 
        await channel5.Writer.WaitToWriteAsync();

        // Alternative write
        for (int i = 0; i < 10; i++)
        {
            bool success = channel5.Writer.TryWrite(i);

        }
    }

    #region Producer/Consumer
    static async Task ProducerConsumer(string[] args)
    {
        var myChannel = Channel.CreateUnbounded<int>();
        var producer = new MyProducer(myChannel.Writer);
        var consumer = new MyConsumer(myChannel.Reader);
    }

    class MyProducer
    {
        private readonly ChannelWriter<int> _channelWriter;
        public MyProducer(ChannelWriter<int> channelWriter)
        {
            _channelWriter = channelWriter;
        }
    }
    class MyConsumer
    {
        private readonly ChannelReader<int> _channelReader;
        public MyConsumer(ChannelReader<int> channelReader)
        {
            _channelReader = channelReader;
        }
    }

    #endregion
}
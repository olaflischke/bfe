using System.Collections.Concurrent;

namespace QueuesAndChannels
{
    public class SimpleChannel<T>
    {
        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);
        public void Write(T value)
        {
            _queue.Enqueue(value);
            _semaphore.Release();
        }

        public async Task<T> Read(CancellationToken cancelToken = default)
        {
            await _semaphore.WaitAsync(cancelToken).ConfigureAwait(false);
            bool found=_queue.TryDequeue(out T value);
            return value;
        }
    }
}
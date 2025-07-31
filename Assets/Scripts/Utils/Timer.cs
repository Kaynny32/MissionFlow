using System;
using Cysharp.Threading.Tasks;
using System.Threading;

public class Timer
{
    private CancellationTokenSource _cts;

    public async UniTask StartAsync(int millisecondsDelay)
    {
        _cts = new CancellationTokenSource();

        try
        {
            await UniTask.Delay(millisecondsDelay, cancellationToken: _cts.Token);
        }
        catch (OperationCanceledException)
        {
            // Таймер был отменен
        }
    }

    public void Cancel()
    {
        _cts?.Cancel();
        _cts?.Dispose();
    }
}
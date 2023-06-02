using DemoGraphQL.Services;
using HotChocolate.Subscriptions;

namespace DemoGraphQL.Workerrs;

public class BackgroundWorker: BackgroundService
{
    private readonly ILogger<BackgroundWorker> _logger;
    private readonly BookRepository _bookRepository;
    private readonly ITopicEventSender _eventSender;

    private const int IntervalMs = 1_000;

    public BackgroundWorker(ILogger<BackgroundWorker> logger, BookRepository bookRepository, [Service] ITopicEventSender eventSender)
    {
        _logger = logger;
        _bookRepository = bookRepository;
        _eventSender = eventSender;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("BackgroundWorker is starting");

        while (!stoppingToken.IsCancellationRequested)
        {
            await PerformUpdates();
            await Task.Delay(IntervalMs, stoppingToken);
        }
    }

    private async Task PerformUpdates()
    {
        foreach (var books in _bookRepository.GetBooks())
        {
            books.Revision += 1;
            await _eventSender.SendAsync(nameof(Subscriptions.BookUpdates.BooksUpdated), books);
        }
    }
}
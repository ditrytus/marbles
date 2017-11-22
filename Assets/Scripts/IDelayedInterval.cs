public interface IDelayedInterval
{
	float Interval { get; }

	float Delay { get; set; }

    int MaxCount { get; }
}

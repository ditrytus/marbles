public static class DragAndDropPhaseExtensions
{
    public static bool IsOver(this DragAndDropPhase phase)
    {
        return (phase & DragAndDropPhase.Over) > 0;
    }
}
using System;

[Flags]
public enum DragAndDropPhase
{
    Started,
    Accepted,
    Canceled,
    Over = Accepted | Canceled
}
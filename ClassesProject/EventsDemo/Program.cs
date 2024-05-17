var elevator = new Elevator();
elevator.FloorReachedEvent += (int floor) => Console.WriteLine($"A floor {floor} is reached");

//elevator.FloorReachedEvent = null; // no longer possible with events

elevator.Move(3);

var betterElevator = new BetterElevator();
betterElevator.FloorReachedEvent += (object sender, FloorReachedEventArgs args) => Console.WriteLine($"A floor {args.FloorReached} is reached");

betterElevator.Move(3);


Console.ReadLine();

public class FloorReachedEventArgs : EventArgs
{
    public int FloorReached { get; private set; }

    public FloorReachedEventArgs(int floor) => FloorReached = floor;
}

public class BetterElevator
{
    public EventHandler<FloorReachedEventArgs> FloorReachedEvent;
    public int CurrentFloor { get; private set; }
    public int MaxFloor => 5;
    public int MinFloor => 0;
    public int MilisecondsBetweenFloors => 1000;

    public void Move(int destinationFloor)
    {
        if (destinationFloor < MinFloor || destinationFloor > MaxFloor)
            throw new ArgumentException("Invalid floor");

        Task.Run(async () =>
        {
            while (CurrentFloor != destinationFloor)
            {
                await Task.Delay(MilisecondsBetweenFloors);

                CurrentFloor += CurrentFloor < destinationFloor ? 1 : -1;

                FloorReachedEvent?.Invoke(this, new FloorReachedEventArgs(CurrentFloor));

                //Console.WriteLine($"Floor {CurrentFloor} reached"); //DON'T DO it like this
            }
        });

    }
}



//This is old school (legacy code uses this approach, nowadays we have better ways)
public delegate void FloorReached(int floor);
public class Elevator
{
    public event FloorReached FloorReachedEvent;
    public int CurrentFloor { get; private set; }
    public int MaxFloor => 5;
    public int MinFloor => 0;
    public int MilisecondsBetweenFloors => 1000;

    public void Move(int destinationFloor)
    {
        if (destinationFloor < MinFloor || destinationFloor > MaxFloor)
            throw new ArgumentException("Invalid floor");

        Task.Run(async () =>
        {
            while (CurrentFloor != destinationFloor)
            {
                await Task.Delay(MilisecondsBetweenFloors);

                CurrentFloor += CurrentFloor < destinationFloor ? 1 : -1;

                FloorReachedEvent?.Invoke(CurrentFloor);

                //Console.WriteLine($"Floor {CurrentFloor} reached"); //DON'T DO it like this
            }
        });

    }
}
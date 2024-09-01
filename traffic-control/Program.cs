// See https://aka.ms/new-console-template for more information
using Traffic.Interfaces;
using Traffic.Models;
var roadA = new Road();
var roadB = new Road();
var roadC = new Road();
var trafficLight = new TrafficLight(2000, 2000, 5000, State.GREEN);
trafficLight.Attach(roadA);
// trafficLight.Attach(roadB);
// trafficLight.Attach(roadC);

// var trafficLightController = Task.Run(() =>
// {
//     while (true)
//     {
//         trafficLight.SetState(State.GREEN);
//         trafficLight.SetState(State.YELLOW);
//         trafficLight.SetState(State.RED);
//     }
// });

var emergencyCall = Task.Run(async () =>
{
    while (true)
    {
         await Task.Delay(1000);
        //  Console.WriteLine("--------------------------------");
         roadA.HandleEmergency();
    }
});
// await Task.WhenAll(trafficLightController, emergencyCall);
await Task.WhenAll(emergencyCall);

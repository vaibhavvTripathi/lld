// See https://aka.ms/new-console-template for more information
using Traffic.Interfaces;
using Traffic.Models;
var roadA = new Road();
var roadB = new Road();
var roadC = new Road();
var trafficLight = new TrafficLight(2000, 2000, 2000, State.GREEN);
trafficLight.Attach(roadA);
// trafficLight.Attach(roadB);
// trafficLight.Attach(roadC);

var trafficLightController = Task.Run(() =>
{
    while (true)
    {
        trafficLight.SetState(State.GREEN);
        trafficLight.SetState(State.YELLOW);
        trafficLight.SetState(State.RED);
    }
});

var emergencyCall = Task.Run(() =>
{
    while (true)
    {
         Thread.Sleep(1000);
        roadA.HandleEmergency();
    }
});

await Task.WhenAll(trafficLightController, emergencyCall);
// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Example.Models;
using Example.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StateMachine;
using StateMachine.Example;
using StateMachine.Interfaces;

var host = Host
    .CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(ICommand<MusicState, MusicEvent>)))
            .ToList()
            .ForEach(c => services.AddTransient(typeof(ICommand<MusicState, MusicEvent>), c));

        services
            .AddSingleton<IStateConfiguration<MusicState, MusicEvent>, MusicConfig>();
        services
            .AddSingleton<IStateMachine<MusicState, MusicEvent>, StateMachine<MusicState, MusicEvent>>();
        services
            .AddSingleton<IStateMachineRuntime<MusicState, MusicEvent>, StateMachineRuntime<MusicState, MusicEvent>>();

        services.AddTransient<IMusicService, MusicService>();
    })
    .Build();

Console.WriteLine("Hello, World!");

var service = host.Services.GetRequiredService<IMusicService>();

var song = new Song("foo");

service.Play(song);
service.Pause(song);
service.Stop(song);


await host.RunAsync();
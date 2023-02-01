using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

var endpoints = new Dictionary<string, string>
{
    { "DockerApp", "http://localhost:8081/endpoint1" },
    { "NativeApp", "http://localhost:8082/endpoint1" }
};

int numberOfRequests = 10;
int numberOfTests = 5;

await CompareEndpoints(endpoints, numberOfRequests, numberOfTests);

async Task CompareEndpoints(Dictionary<string, string> endpoints, int numberOfRequests, int numberOfTests)
{
    var client = new HttpClient();
    var endpointTimes = new Dictionary<string, double>();

    foreach (var endpoint in endpoints)
    {
        var totalTime = 0.0;

        Console.WriteLine($"Testing endpoint: {endpoint.Key}");

        for (int i = 0; i < numberOfTests; i++)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            for (int j = 0; j < numberOfRequests; j++)
            {
                var response = await client.GetAsync(endpoint.Value);
            }

            stopwatch.Stop();

            totalTime += stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Test {i + 1}: {stopwatch.ElapsedMilliseconds} ms");
        }

        endpointTimes[endpoint.Key] = totalTime / numberOfTests;

        Console.WriteLine($"Average time for endpoint {endpoint.Key}: {endpointTimes[endpoint.Key]} ms");
        Console.WriteLine();
    }

    var endpoint1Time = endpointTimes["DockerApp"];
    var endpoint2Time = endpointTimes["NativeApp"];

    if (endpoint1Time < endpoint2Time)
    {
        Console.WriteLine($"DockerApp is faster { Math.Round(endpoint2Time / endpoint1Time, 2) } times");
    }
    else if (endpoint2Time < endpoint1Time)
    {
        Console.WriteLine($"NativeApp is faster { Math.Round(endpoint1Time / endpoint2Time, 2) } times");
    }
    else
    {
        Console.WriteLine("Both endpoints have the same speed");
    }
}

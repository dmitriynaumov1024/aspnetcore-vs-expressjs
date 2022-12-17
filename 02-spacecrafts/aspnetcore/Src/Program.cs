using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Program
{
    public static Spacecraft[] Crafts;

    public static void Main (string[] args)
    {
        // prepare
        Crafts = Factory<Spacecraft>.GenerateMany(40);

        // create app
        var app = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>()
            .UseUrls("http://0.0.0.0:4000;https://0.0.0.0:5001")
            .Build();
        
        // serve
        app.Run();
    }
}

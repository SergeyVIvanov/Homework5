using Homework5;
using Newtonsoft.Json;
using System.Diagnostics;

var f = F.Get();

Do(f, Serializer.Serialize, "My serialization");
Do(f, JsonConvert.SerializeObject, "Newtonsoft serialization");

static void Do(object obj, Func<object, string> serialize, string serializationMethodcaption)
{
    Console.Write($"{serializationMethodcaption}: ");

    var s = serialize(obj);
    Console.WriteLine(s);

    var duration = MeasureDuration(() =>
    {
        for (int i = 0; i < 100000; i++)
            serialize(obj);
    });

    Console.WriteLine($"{duration} ms");
}

static long MeasureDuration(Action action)
{
    Stopwatch timer = Stopwatch.StartNew();
    action();
    timer.Stop();
    return timer.ElapsedMilliseconds;
}

class F
{
    public int I1 { get; set; }
    public int I2 { get; set; }
    public int I3 { get; set; }
    public int I4 { get; set; }
    public int I5 { get; set; }

    public static F Get() =>
        new() { I1 = 1, I2 = 2, I3 = 3, I4 = 4, I5 = 5 };
}

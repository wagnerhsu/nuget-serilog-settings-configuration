using Volo.Abp.DependencyInjection;

namespace MiniApiDemo;

public class HelloService : ITransientDependency
{
    public string SayHi()
    {
        return "Hi from service";
    }
}

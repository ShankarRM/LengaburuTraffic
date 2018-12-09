using System.Collections;

namespace LengaburuTraffic
{
    public interface IConfigReader
    {
        T GetValue<T>(string key);

        ArrayList  GetValueCollection<T>(string key);

    }
}
namespace DmLib.Win
{
    public interface ISystemVariable
    {
        string Get();

        bool Set(string s);

        bool Add(string dir);

        bool Remove(string dir);

        bool Contains(string dir);
    }
}

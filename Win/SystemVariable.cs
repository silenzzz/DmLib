using System;

namespace DmLib.Win
{
    public class SystemVariable : ISystemVariable
    {
        public string Name { get; }

        public SystemVariable(string name)
        {
            this.Name = name;
        }

        public string Get()
        {
            return Environment.GetEnvironmentVariable(Name);
        }

        public bool Set(string s)
        {
            Environment.SetEnvironmentVariable(Name, s, EnvironmentVariableTarget.User);
            return true;
        }

        public bool Add(string dir)
        {
            Environment.SetEnvironmentVariable(Name, Get() + ";" + dir + ";", EnvironmentVariableTarget.User);
            return true;
        }

        public bool Contains(string dir)
        {
            return Get().Contains(dir);
        }

        public bool Remove(string dir)
        {
            if (Contains(dir))
            {
                string r = Get().Replace(dir, "");
                Set(r);
                return true;
            } else
            {
                return false;
            }
        }
    }
}

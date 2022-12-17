using System;

public abstract class Factory<T>
{
    protected abstract T GenerateImpl();

    static Factory<T> GetFactory()
    {
        string typeName = typeof(T).Name,
               factoryTypeName = typeName+"Factory";
        Type factoryType = Type.GetType(factoryTypeName);
        if (factoryType == null) {
            throw new Exception ($"Unable to find {factoryTypeName} in current assembly");
        } 
        if (! typeof(Factory<T>).IsAssignableFrom(factoryType)) {
            throw new Exception ($"{factoryTypeName} does not extend Factory<{typeName}>");
        }
        return (Factory<T>)(factoryType.GetConstructor(new Type[0]).Invoke(null));
    }

    static Factory<T> _instance;
    public static Factory<T> CachedFactory { 
        get { 
            if (_instance == null) _instance = GetFactory();
            return _instance;
        }
        set {
            _instance = value;
        }
    }

    public static T Generate ()
    {
        return CachedFactory.GenerateImpl();
    }

    public static T[] GenerateMany (int count)
    {
        Factory<T> factoryInstance = CachedFactory;
        T[] result = new T[count];
        for (int i=0; i<count; i++) {
            result[i] = factoryInstance.GenerateImpl();
        }
        return result;
    }
}

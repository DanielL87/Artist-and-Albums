using System.Collections.Generic;

namespace Music.Models
{
  public class Album
  {
    private string _name;
    private int _year;
    private int _id;
    private static List<Album> _instances = new List<Album> {};

    public Album(string name, int year)
    {
      _name = name;
      _year = year;
      _instances.Add(this);
      _id = _instances.Count;
    }

    //Getters

    public string GetName()
    {
        return _name;
    }

    public int GetYear()
    {
        return _year;
    }

    public int GetId()
    {
      return _id;
    }

    public static Album Find(int searchId)
    {
      return _instances[searchId-1];
    }


    public static List<Album> GetAll()
    {
      return _instances;
    }

        public static void ClearAll()
    {
      _instances.Clear();
    }


  }
}     
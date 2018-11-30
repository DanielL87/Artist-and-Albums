using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music.Models;
using System.Collections.Generic;
using System;

namespace Music.Tests
{
  [TestClass]
  public class AlbumTest : IDisposable
  {

    public void Dispose()
    {
        Album.ClearAll();
    }
    
    [TestMethod]
    public void AlbumConstructor_TypeOfAlbum_Type()
    {
        Album newAlbum = new Album("test", 1902);
        Assert.AreEqual(typeof(Album), newAlbum.GetType());
    }

    [TestMethod]
    public void AlbumConstructor_CreatesInstanceOfAlbumName_String()
    {
      string str = "test";
      Album newAlbum = new Album(str, 1902);
      Assert.AreEqual("test", newAlbum.GetName());
    } 

    [TestMethod]
    public void AlbumConstructor_CreatesInstanceOfAlbumYear_Int()
    {
      int number = 1987;
      Album newAlbum = new Album("blue", number);
      Assert.AreEqual(1987, newAlbum.GetYear());
    } 

    [TestMethod]
    public void AlbumList_ReturnList_List()
    {
      string name1 = "The White Album";
      string name2 = "Abbey Road";
      Album var1 = new Album(name1, 1902);
      Album var2 = new Album(name2, 1902);

      List<Album> newList = new List<Album> {var1 , var2};
      List <Album> varlist = Album.GetAll();
      CollectionAssert.AreEqual(varlist, newList);
    }
    
    [TestMethod]
    public void AlbumConstructor_FindInstance_Album()
    {
        Album album1 = new Album("one", 1900);
        Album album2 = new Album("two", 1900);

        Album testAlbum = Album.Find(2);
        Assert.AreEqual(album2, testAlbum);

    }

  }
}
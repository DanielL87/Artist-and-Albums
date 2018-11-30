using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music.Models;
using System.Collections.Generic;
using System;

namespace Music.Tests
{
  [TestClass]
  public class ArtistTest : IDisposable
  {

    public void Dispose()
    {
        Artist.ClearAll();
    }
    
    [TestMethod]
    public void ArtistConstructor_TypeOfArtist_Type()
    {
        Artist newArtist = new Artist("Beatles");
        Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtistName_String()
    {
      string str = "Beatles";
      Artist newArtist = new Artist(str);
      Assert.AreEqual("Beatles", newArtist.GetName());
    } 


    [TestMethod]
    public void ArtistList_ReturnList_List()
    {
      string name1 = "The Beatles";
      string name2 = "Kings of Leon";
      Artist var1 = new Artist(name1);
      Artist var2 = new Artist(name2);

      List<Artist> newList = new List<Artist> {var1 , var2};
      List <Artist> varlist = Artist.GetAll();
      CollectionAssert.AreEqual(varlist, newList);
    }
    
    [TestMethod]
    public void ArtistConstructor_FindInstance_Artist()
    {
        Artist Artist1 = new Artist("one");
        Artist Artist2 = new Artist("two");

        Artist testArtist = Artist.Find(2);
        Assert.AreEqual(Artist2, testArtist);

    }
    
    [TestMethod]
    public void ArtistConstructor_FindAlbumInArtist_Album()
    {
        string description= "Abbey Road";
        Album newAlbum = new Album(description, 1960);
        List<Album> albumList = new List<Album> { newAlbum };
        string artistString = "The Beatles";
        Artist newArtist = new Artist(artistString);

        newArtist.AddAlbum(newAlbum);
        List<Album> result = newArtist.GetAlbums();
        CollectionAssert.AreEqual(albumList, result);

    }
  }
}
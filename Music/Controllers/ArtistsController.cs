using Microsoft.AspNetCore.Mvc;
using Music.Models;
using System.Collections.Generic;
using System;

namespace Music.Controllers
{
    public class ArtistsController : Controller
    {

      [HttpGet("/artists")]
      public ActionResult Index()
      {
        List<Artist> allArtists = Artist.GetAll();
        return View(allArtists);
      }

      [HttpGet("/artists/new")]
      public ActionResult New()
        {
            return View();
        }

        [HttpPost("/artists")]
        public ActionResult Create(string artistName)
        {
            Artist newArtist = new Artist(artistName);
            List<Artist> allArtists = Artist.GetAll();
            return View("Index", allArtists);
        }

        [HttpGet("/artists/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Artist foundArtist = Artist.Find(id);
            List<Album> artistAlbums = foundArtist.GetAlbums();
            model.Add("artist", foundArtist);
            model.Add("albums", artistAlbums);
            return View(model);
        }

        [HttpPost("/artists/{artistId}/albums")]
        public ActionResult Create(int artistId, string albumName, int albumYear)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Artist foundArtist = Artist.Find(artistId);
            Album newAlbum = new Album(albumName, albumYear);
            foundArtist.AddAlbum(newAlbum);
            List<Album> artistAlbums = foundArtist.GetAlbums();
            model.Add("artist", foundArtist);
            model.Add("albums", artistAlbums);
            return View("Show", model);
        }
    }
}

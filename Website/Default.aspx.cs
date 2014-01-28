using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write(Insert());
                //Response.Write(Get().Count);
            }
        }

        private bool Insert()
        {
            MongoDB.Driver.MongoServer server = new MongoDB.Driver.MongoClient("mongodb://127.0.0.1:27017").GetServer();
            MongoDB.Driver.MongoDatabase db = server.GetDatabase("HenryDB");
            MongoDB.Driver.MongoCollection<User> col = db.GetCollection<User>("User");
            MongoDB.Driver.WriteConcernResult result = col.Insert(new User() { Name = "Henry", Age = 27 });
            return result.Ok;
        }

        private IList<User> Get()
        {
            MongoDB.Driver.MongoServer server = new MongoDB.Driver.MongoClient("mongodb://127.0.0.1:27017").GetServer();
            MongoDB.Driver.MongoDatabase db = server.GetDatabase("HenryDB");
            MongoDB.Driver.MongoCollection<User> col = db.GetCollection<User>("User");
            MongoDB.Driver.MongoCursor<User> result = col.FindAll();
            return result.ToList();
        }

        private class User
        {
            public ObjectId _id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
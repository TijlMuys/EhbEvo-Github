using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EhbEvo.Models;

namespace EhbEvoApp.Models
{
    public class FeedView
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
        public SortedDictionary<DateTime, object> FeedItems { get; set; }
        public IEnumerable<Department> Departementen { get; set; }
        public List<string> Filtervalues { get; set; }
        public FeedView()
        {
            //reverse ordering
            this.FeedItems = new SortedDictionary<DateTime, object>(Comparer<DateTime>.Create((x, y) => y.CompareTo(x)));
            this.Filtervalues = new List<string>();
        }

    }
}
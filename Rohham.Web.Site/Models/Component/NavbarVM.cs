using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rohham.Web.Site.Models.Component
{
    //public class NavbarVM
    //{
    //    public string Icon { get; set; }
    //    public List<NavbarItemVM> NavbarItems { get; set; }
    //}
    //public class NavbarItemVM
    //{
    //    public int Id { get; set; }
    //    public bool Active { get; set; }
    //    public string Name { get; set; }
    //    public string Link { get; set; }
    //    public int? ParentId { get; set; }
    //    public List<NavbarItemVM> Childs { get; set; }
    //}

    public static class NavbarVM
    {
        public static string Icon { get; set; }
        public static List<NavbarItemVM> NavbarItems { get; set; }
    }

    public class NavbarItemVM
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int? ParentId { get; set; }
        public List<NavbarItemVM> Childs { get; set; }
    }
}

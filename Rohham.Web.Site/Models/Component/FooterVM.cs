using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rohham.Web.Site.Models.Component
{
    //public class FooterVM
    //{
    //    public string FooterIconUrl { get; set; }
    //    public string ShortDescription { get; set; }
    //    public List<string> Tel { get; set; }
    //    public string Email { get; set; }
    //    public string Address { get; set; }
    //    public string TermsConditions { get; set; }
    //    public string PrivacyPolicy { get; set; }
    //    public string FB { get; set; }
    //    public string TW { get; set; }
    //    public string PN { get; set; }
    //    public string Linkedin { get; set; }
    //    public string Youtube { get; set; }
    //    public List<FooterColumnVM> FooterColumns { get; set; }
    //}

    public static class FooterVM
    {
        public static string FooterIconUrl { get; set; }
        public static string ShortDescription { get; set; }
        public static List<string> Tel { get; set; }
        public static string Email { get; set; }
        public static string Address { get; set; }
        public static string TermsConditions { get; set; }
        public static string PrivacyPolicy { get; set; }
        public static string FB { get; set; }
        public static string TW { get; set; }
        public static string PN { get; set; }
        public static string Linkedin { get; set; }
        public static string Youtube { get; set; }
        public static List<FooterColumnVM> FooterColumns { get; set; }
    }

    public class FooterColumnVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Dictionary<string,string> Link { get; set; }
    }
}
using System;

namespace SportStore.WebUI.Models
{
    /// <summary>
    /// Class that represents paging information for a list of elements being
    /// displayed in a view.
    /// </summary>
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int) Math.Ceiling((decimal) TotalItems/ItemsPerPage); }
        }
    }
}
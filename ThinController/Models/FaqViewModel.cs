using System.Collections.Generic;
using ThinController.EntityFramework;

namespace ThinController.Models
{
    public class FaqViewModel
    {
        public string PageTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }

        public IEnumerable<FAQ> FaqList { get; set; }
    }
}


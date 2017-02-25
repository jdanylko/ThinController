using System.Collections.Generic;

namespace ThinController.Models
{
    public class FaqViewModel
    {
        public string PageTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }

        public IEnumerable<Faq> FaqList { get; set; }
    }
}


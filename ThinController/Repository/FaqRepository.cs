using System.Collections.Generic;
using ThinController.Models;

namespace ThinController.Repository
{
    public class FaqRepository
    {
        public IEnumerable<Faq> GetAll()
        {
            return new List<Faq>
            {
                new Faq()
                {
                    Question = "So How long has the site been up?",
                    Answer = "A short time."
                },
                new Faq
                {
                    Question = "How big is your audience?",
                    Answer = "Just two, my wife and my mother."
                },
                new Faq
                {
                    Question = "How long have you been programming?",
                    Answer = "3 decades."
                }
            };
        }
    }
}
using Lifestyle_Preference_survey.Data;
using Lifestyle_Preference_survey.Interfaces;
using Lifestyle_Preference_survey.Models;

namespace Lifestyle_Preference_survey.Repo
{
    public class RatingRepo : IRating
    {
        private readonly AppBDContext _context;
        public RatingRepo(AppBDContext context)
        {
            _context = context;
        }
        public void Create(Rating rating)
        {
            _context.Add(rating);
            _context.SaveChanges();
        }

        public List<Rating> ListAll()
        {
            return _context.Ratings.ToList();
        }
    }
}

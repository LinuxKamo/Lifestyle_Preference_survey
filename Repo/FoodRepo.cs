using Lifestyle_Preference_survey.Data;
using Lifestyle_Preference_survey.Interfaces;
using Lifestyle_Preference_survey.Models;

namespace Lifestyle_Preference_survey.Repo
{
    public class FoodRepo : IFood
    {
        private readonly AppBDContext _context;
        public FoodRepo(AppBDContext context)
        {
            _context = context;
        }
        public void Create(Foods food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();
        }

        public List<Foods> ListAll()
        {
            return _context.Foods.ToList();
        }
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lifestyle_Preference_survey.Models;
using Lifestyle_Preference_survey.ViewModel;
using Lifestyle_Preference_survey.Interfaces;

namespace Lifestyle_Preference_survey.Controllers;

public class HomeController : Controller
{
    //Declarations
    private readonly ILogger<HomeController> _logger;
    private readonly IFood _food;
    private readonly IUserDetails _user;
    private readonly IRating _rating;

    public HomeController(ILogger<HomeController> logger, IFood food, IUserDetails user, IRating rating)
    {
        _logger = logger;
        _food = food;
        _rating = rating;
        _user = user;
    }



    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }//end

    [HttpPost]
    public IActionResult Index(UserInput survey)
    {
        try
        {
            if (ModelState.IsValid)
            {

                if (_user.ListAll().FirstOrDefault(x => x.Email == survey.Email) != null)
                {
                    TempData["message"] = $"{survey.Fullnames}, Thank you for your submission! You have already submitted the survey.";
                    return RedirectToAction("Index",survey);
                }
                else
                {
                    var userdetails = new UserDetails
                    {
                        Fullnames = survey.Fullnames,
                        Email = survey.Email,
                        DateOfBirth = survey.DateOfBirth,
                        PhoneNumber = survey.PhoneNumber
                    };
                    var userfood = new Foods
                    {
                        Pizza = survey.Pizza!,
                        Other = survey.Other!,
                        PapAndWors = survey.PapAndWors!,
                        Pasta = survey.Pasta!
                    };
                    var userRating = new Rating
                    {
                        Movies = survey.Movies!,
                        Out = survey.Out!,
                        Radio = survey.Radio!,
                        TV = survey.TV!
                    };

                    // Save the user details, food preferences, and ratings to the database
                    _user.Create(userdetails);
                    userfood.User_ID = userdetails.ID; // Set the foreign key
                    _food.Create(userfood);
                    userRating.User_ID = userdetails.ID; // Set the foreign key
                    _rating.Create(userRating);
                    TempData["message"] = $"{survey.Fullnames}, Thank you for your submission!";


                    // Redirect to the results page after successful submission
                    return RedirectToAction("Index");
                }

            }
        }//end try block
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing the survey submission.");
            ModelState.AddModelError(string.Empty, "An error occurred while processing your request. Please try again later.");
        }//end catch block


         // If we reach here, something went wrong, redisplay the form with validation errors
        TempData["error"] = "There was an error with your submission. Please check the the required fields and try again.";
        return View(survey);
    }//end

    [HttpGet]
    public IActionResult ViewSurveryResuls()
    {
        //Declarations
        var results = new SurveyResults();
        var totalfood = _food.ListAll().Count;
        var totalrating = _rating.ListAll().Count;
        var rateList = _rating.ListAll();
        var userlist = _user.ListAll();
        var foodlist = _food.ListAll();


        try
        {
            if (_food.ListAll().Count > 0 || _rating.ListAll().Count > 0 || _user.ListAll().Count > 0)
            {
                //Calculating the percentage of entertainment preferences
                double ratingout = rateList.FindAll(x => x.Out == "agree" || x.Out == "strongly_agree").Count / Convert.ToDouble(rateList.Count);
                double ratingmovies = rateList.FindAll(x => x.Movies == "agree" || x.Movies == "strongly_agree").Count / Convert.ToDouble(rateList.Count);
                double ratingtv = rateList.FindAll(x => x.TV == "agree" || x.TV == "strongly_agree").Count / Convert.ToDouble(_rating.ListAll().Count);
                double ratingradio = rateList.FindAll(x => x.Radio == "agree" || x.Radio == "strongly_agree").Count / Convert.ToDouble(rateList.Count);

                //initializing the results
                results.SurveyNumber = userlist.Count;
                results.PercentOfPizza = PercentConvert(totalfood, foodlist.FindAll(x => x.Pizza == "true").Count);
                results.PercentOfPasta = PercentConvert(totalfood, foodlist.FindAll(x => x.Pasta == "true").Count);
                results.PercentOfPapandWors = PercentConvert(totalfood, foodlist.FindAll(x => x.PapAndWors == "true").Count);
                results.EatOut = Math.Round(ratingout, 1);
                results.TotalMovies = Math.Round(ratingmovies, 1);
                results.Radio = Math.Round(ratingradio, 1);
                results.TV = Math.Round(ratingtv, 1);
                results.Avarage = userlist.Average(x => DateTime.Now.Year - x.DateOfBirth.Year);
                results.Youngest = userlist.Min(x => DateTime.Now.Year - x.DateOfBirth.Year);
                results.Oldest = userlist.Max(x => DateTime.Now.Year - x.DateOfBirth.Year);


                return View(results);
            }
        }//end try block
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while calculating survey results.");
        }

        //something went wrong or list is empty
        return View(results);
    }//end

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }//end

    // This method converts a value to a percentage based on the total.
    private double PercentConvert(double total, double value)
    {
        return (value / total) * 100;
    }
}

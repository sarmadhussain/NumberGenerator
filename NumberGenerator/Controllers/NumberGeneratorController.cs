using NumberGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;

namespace NumberGenerator.Controllers
{
    public class NumberGeneratorController : Controller
    {
        //
        // GET: /NumberGenerator/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetNumberSequence(string number)
        {
            NumberViewModel nvm = new NumberViewModel();
            try
            {
                Int64 input;
                bool isNumber = Int64.TryParse(number, out input);
                if (isNumber)
                {

                    for (Int64 i = 0; i <= input; i++)
                    {
                        string code = "" + i;
                        nvm.allNumbers.Add(i);
                        if ((i & 1) == 0)
                            nvm.evenNumbers.Add(i);
                        else
                        {
                            nvm.oddNumbers.Add(i);
                        }
                        if (i > 0)
                        {
                            if (i % 3 == 0)
                            {
                                code = "C";
                            }
                            if (i % 5 == 0)
                            {
                                code = "E";
                            }
                            // it can be both odd or even number to be divisible by both 3 and 5
                            // e.g. 15 and 30, 35, 60
                            if (i % 3 == 0 && i % 5 == 0)
                            {
                                code = "Z";
                            }
                        }
                        nvm.cezNumbers.Add(code);
                    }
                    if (input == 0)
                        nvm.fibNumbers.Add(0);
                    else //if (input == 1)
                    {
                        nvm.fibNumbers.Add(0);
                        nvm.fibNumbers.Add(1);
                        nvm.fibNumbers.Add(1);
                    }
                    if (input > 1)
                    {
                        while (true)
                        {
                            Int64 sum = nvm.fibNumbers[nvm.fibNumbers.Count - 1] + nvm.fibNumbers[nvm.fibNumbers.Count - 2];
                            if (sum <= input)
                                nvm.fibNumbers.Add(sum);
                            else
                                break;
                        }
                    }
                }
                else
                {
                    nvm.IsError = true;
                    nvm.ErrorMessage = "Invalid input number - Server Error";
                }
            }
            catch (Exception ex)
            {
                nvm.IsError = true;
                nvm.ErrorMessage = ex.Message + " - Server Error";
            }
            return Json(new { nvm });
        }

    }
}

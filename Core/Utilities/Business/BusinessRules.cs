using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {

        public static IResult Run(params IResult[] logics)
        {
            foreach(var logic in logics)
            {
                if(!logic.Success)
                {//parametre ile gönderdiğimiz iş kurallarından başarısız olanları
                 //Business'a haber ediyoruz
                    return logic;
                }
            }
            return null;
        }
    }
}

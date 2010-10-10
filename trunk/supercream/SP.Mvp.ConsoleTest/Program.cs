using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Mvp.FitnesseTests;

namespace SP.Mvp.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var offerDoFixture = new OfferDoFixture();
            offerDoFixture.SaveOffer();
        }
    }
}

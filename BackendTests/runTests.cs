﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace BackendTests
{
    public class runTests
    {
        static void Main(string[] args)
        {
            GradingService gs = new GradingService();
            new userTest(gs).runTests();
            new taskTest(gs).runTests();
            new boardTest(gs).runTests();
        }
    }
}

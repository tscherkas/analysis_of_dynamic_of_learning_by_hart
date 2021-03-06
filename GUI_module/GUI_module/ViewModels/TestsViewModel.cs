﻿using DLH_Interfaces;
using GUI_module.Models;
using GUI_module.Services;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_module.ViewModels
{
    public class TestsViewModel : BaseViewModel
    {
        public IEnumerable<Test> Tests { get; set; }    
        public TestsViewModel(ISurveyService surveyService,
            INavigationService navigationService)
            : base(navigationService)
        {
            this.surveyService = surveyService;
            StartTest = new DelegateCommand<object>(this.OnStartTest);
            loadSurveys();
        }

        public ICommand StartTest { get; set; }

        private void OnStartTest(object obj)
        {
            navigationService.navigateToLogin();
        }

        private void loadSurveys()
        {
            Tests = surveyService.loadSurveys().Select(
                s => new Test {
                    Name = s.name,
                    Description = s.desription
                });
        }

        private ISurveyService surveyService;
    }
}

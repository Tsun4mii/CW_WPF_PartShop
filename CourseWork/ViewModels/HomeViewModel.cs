﻿using CourseWork.Commands;
using CourseWork.Database;
using CourseWork.Models;
using CourseWork.SingletonView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CourseWork.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<Part> Parts { get; set; }
        public Part part;
        public ObservableCollection<Category> categories { get; set; }
        private Command addToCartCommand;
        private Command openFullInfoCommand;
        private Command findByCategory;
        public int id { get; set; }
        private Part selectedPart;
        public Part SelectedPart
        {
            get { return selectedPart; }
            set
            {
                selectedPart = value;
                OnPropertyChanged("SelectedPart");
            }
        }
        private Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");    
            }
        }
        public HomeViewModel()
        {
            using (PartShopDbContext db = new PartShopDbContext())
            {
                Parts = new ObservableCollection<Part>(db.Parts);
                categories = new ObservableCollection<Category>(db.Categories);
                //Parts = db.Parts.ToList();
            }
        }
        public ICommand AddToCartCommand
        {
            get
            {
                return addToCartCommand ??
                  (addToCartCommand = new Command(obj =>
                    {
                        Singleton.getInstance(null).MainViewModel.CurrentViewModel = new SearchViewModel(Parts);
                    }));
            }
        }
        public ICommand FindByCategory
        {
            get
            {
                return findByCategory ??
                  (findByCategory = new Command(obj =>
                  {
                      using (PartShopDbContext db = new PartShopDbContext())
                      {
                          Parts = new ObservableCollection<Part>(db.Parts.Where(x => x.CategoryId == 2));
                          Singleton.getInstance(null).MainViewModel.CurrentViewModel = new SearchViewModel(Parts);
                      }
                  }));
            }
        }
        public ICommand OpenFullInfo
        { 
            get
            {
                return openFullInfoCommand ??
                  (openFullInfoCommand = new Command(obj =>
                  {
                      Singleton.getInstance(null).MainViewModel.CurrentViewModel = new FullInfoViewModel(selectedPart);
                  }));
            }
        }

    }
}
